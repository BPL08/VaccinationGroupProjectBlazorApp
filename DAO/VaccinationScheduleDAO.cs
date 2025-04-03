using BO.Entity;
using DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class VaccinationScheduleDAO
    {
        private ApplicationDbContext _dbContext;
        private static VaccinationScheduleDAO instance;

        public VaccinationScheduleDAO()
        {
            _dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        public static VaccinationScheduleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VaccinationScheduleDAO();
                }
                return instance;
            }
        }

        public VaccinationSchedule GetScheduleById(Guid scheduleId)
        {
            return _dbContext.VaccinationSchedules
                .Include(vs => vs.Profile)
                .Include(vs => vs.Center)
                .Include(vs => vs.OrderDetail)
                .SingleOrDefault(vs => vs.VaccinationScheduleId == scheduleId);
        }

        public void AddSchedule(VaccinationSchedule schedule)
        {
            _dbContext.VaccinationSchedules.Add(schedule);
            _dbContext.SaveChanges();
        }

        public void UpdateSchedule(Guid scheduleId, VaccinationSchedule schedule)
        {
            var existingSchedule = GetScheduleById(scheduleId);
            if (existingSchedule != null)
            {
                existingSchedule.FKProfileId = schedule.FKProfileId;
                existingSchedule.FKCenterId = schedule.FKCenterId;
                existingSchedule.FKOrderDetailsId = schedule.FKOrderDetailsId;
                existingSchedule.DoseNumber = schedule.DoseNumber;
                existingSchedule.AppointmentDate = schedule.AppointmentDate;
                existingSchedule.ActualDate = schedule.ActualDate;
                existingSchedule.AdministeredBy = schedule.AdministeredBy;
                existingSchedule.Status = schedule.Status;

                _dbContext.VaccinationSchedules.Update(existingSchedule);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteSchedule(Guid scheduleId)
        {
            var schedule = GetScheduleById(scheduleId);
            if (schedule != null)
            {
                _dbContext.VaccinationSchedules.Remove(schedule);
                _dbContext.SaveChanges();
            }
        }

        public List<VaccinationSchedule> GetAllSchedules()
        {
            return _dbContext.VaccinationSchedules
                .Include(vs => vs.Profile)
                .Include(vs => vs.Center)
                .Include(vs => vs.OrderDetail)
                .ToList();
        }

        public List<VaccinationSchedule> GetSchedulesByProfile(Guid profileId)
        {
            return _dbContext.VaccinationSchedules
                .Include(vs => vs.Profile)
                .Include(vs => vs.Center)
                .Include(vs => vs.OrderDetail)
                .Where(vs => vs.FKProfileId == profileId)
                .ToList();
        }

        public List<VaccinationSchedule> GetSchedulesByCenter(int centerId)
        {
            return _dbContext.VaccinationSchedules
                .Include(vs => vs.Profile)
                .Include(vs => vs.Center)
                .Include(vs => vs.OrderDetail)
                .Where(vs => vs.FKCenterId == centerId)
                .ToList();
        }

        public List<VaccinationSchedule> GetSchedulesByDateRange(DateTime startDate, DateTime endDate)
        {
            return _dbContext.VaccinationSchedules
                .Include(vs => vs.Profile)
                .Include(vs => vs.Center)
                .Include(vs => vs.OrderDetail)
                .Where(vs => vs.AppointmentDate >= startDate && vs.AppointmentDate <= endDate)
                .ToList();
        }

        public List<VaccinationSchedule> GetSchedulesByStatus(int status)
        {
            return _dbContext.VaccinationSchedules
                .Include(vs => vs.Profile)
                .Include(vs => vs.Center)
                .Include(vs => vs.OrderDetail)
                .Where(vs => vs.Status == status)
                .ToList();
        }

        public List<VaccinationSchedule> GetSchedulesByAccountId(Guid accountId)
        {
            return _dbContext.VaccinationSchedules
                .Join(_dbContext.ChildrenProfiles,
                      schedule => schedule.FKProfileId,
                      profile => profile.ProfileId,
                      (schedule, profile) => new { Schedule = schedule, Profile = profile })
                .Where(x => x.Profile.FKAccountId == accountId)
                .Select(x => x.Schedule)
                .ToList();
        }

        public List<VaccinationSchedule> GetSchedulesByProfileName(string profileName)
        {
            if (string.IsNullOrWhiteSpace(profileName))
                return GetAllSchedules();

            return _dbContext.VaccinationSchedules
                .Include(vs => vs.Profile)
                .Include(vs => vs.Center)
                .Include(vs => vs.OrderDetail)
                .Where(vs => vs.Profile != null && vs.Profile.Name.ToLower().Contains(profileName.ToLower()))
                .ToList();
        }

        public List<VaccinationSchedule> GetSchedulesByCenterName(string centerName)
        {
            if (string.IsNullOrWhiteSpace(centerName))
                return GetAllSchedules();

            return _dbContext.VaccinationSchedules
                .Include(vs => vs.Profile)
                .Include(vs => vs.Center)
                .Include(vs => vs.OrderDetail)
                .Where(vs => vs.Center != null && vs.Center.Name.ToLower().Contains(centerName.ToLower()))
                .ToList();
        }
        public OrderDetail GetOrderDetailByVaccinationScheduleId(Guid vaccinationScheduleId)
        {
            return _dbContext.VaccinationSchedules
                .Include(vs => vs.OrderDetail) // Include OrderDetail first
                    .ThenInclude(od => od.Order) // Then include OrderDetail's Order
                .Include(vs => vs.OrderDetail) // Include OrderDetail again for chaining
                    .ThenInclude(od => od.Vaccine) // Then include Vaccine
                .Include(vs => vs.OrderDetail) // Include OrderDetail again for chaining
                    .ThenInclude(od => od.VaccinePackage) // Then include VaccinePackage
                .Where(vs => vs.VaccinationScheduleId == vaccinationScheduleId)
                .Select(vs => vs.OrderDetail)
                .SingleOrDefault();
        }
        public Order FindOrderByVaccinationScheduleId(Guid vaccinationScheduleId)
        {
            try
            {
                var order = _dbContext.VaccinationSchedules
                    .Include(vs => vs.OrderDetail)
                        .ThenInclude(od => od.Order)
                    .Where(vs => vs.VaccinationScheduleId == vaccinationScheduleId)
                    .Select(vs => vs.OrderDetail.Order)
                    .SingleOrDefault();

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding order by vaccination schedule ID: {ex.Message}", ex);
            }
        }
        public bool AreAllSchedulesCompleted(Guid vaccinationScheduleId)
        {
            try
            {
                var schedule = _dbContext.VaccinationSchedules
                    .Include(vs => vs.OrderDetail) 
                    .FirstOrDefault(vs => vs.VaccinationScheduleId == vaccinationScheduleId);
                if (schedule == null)
                {
                    throw new Exception("Vaccination schedule not found");
                }
                var orderId = schedule.OrderDetail.FKOrderId;
                var orderDetailIds = _dbContext.OrderDetails
                    .Where(od => od.FKOrderId == orderId)
                    .Select(od => od.OrderDetailId)
                    .ToList();
                bool hasPendingSchedules = _dbContext.VaccinationSchedules
                    .Where(vs => orderDetailIds.Contains(vs.FKOrderDetailsId))
                    .Any(vs => vs.Status == 0); 
                return !hasPendingSchedules;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking schedule status: {ex.Message}", ex);
            }
        }
    }
}