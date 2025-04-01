using BO.Entity;
using DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class ChildrenProfileDAO
    {
        private ApplicationDbContext _dbContext;
        private static ChildrenProfileDAO instance;

        public ChildrenProfileDAO()
        {
            _dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        public static ChildrenProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChildrenProfileDAO();
                }
                return instance;
            }
        }

        public ChildrenProfile GetProfileById(Guid profileId)
        {
            return _dbContext.ChildrenProfiles
                .Include(cp => cp.Account)
                .SingleOrDefault(cp => cp.ProfileId == profileId);
        }

        public List<ChildrenProfile> GetProfilesByAccountId(Guid accountId)
        {
            return _dbContext.ChildrenProfiles
                .Include(cp => cp.Account)
                .Where(cp => cp.FKAccountId == accountId)
                .ToList();
        }

        public void AddProfile(ChildrenProfile profile)
        {
            _dbContext.ChildrenProfiles.Add(profile);
            _dbContext.SaveChanges();
        }

        public void UpdateProfile(Guid profileId, ChildrenProfile profile)
        {
            var existingProfile = GetProfileById(profileId);
            if (existingProfile != null)
            {
                existingProfile.ParentName = profile.ParentName;
                existingProfile.Name = profile.Name;
                existingProfile.Gender = profile.Gender;
                existingProfile.DateOfBirth = profile.DateOfBirth;
                existingProfile.Status = profile.Status;

                _dbContext.ChildrenProfiles.Update(existingProfile);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteProfile(Guid profileId)
        {
            var profile = GetProfileById(profileId);
            if (profile != null)
            {
                _dbContext.ChildrenProfiles.Remove(profile);
                _dbContext.SaveChanges();
            }
        }

        public List<ChildrenProfile> GetAllProfiles()
        {
            return _dbContext.ChildrenProfiles
                .Include(cp => cp.Account)
                .ToList();
        }

        public List<ChildrenProfile> GetActiveProfiles()
        {
            return _dbContext.ChildrenProfiles
                .Include(cp => cp.Account)
                .Where(cp => cp.Status == "Active")
                .ToList();
        }
    }
}