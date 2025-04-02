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

    }
}