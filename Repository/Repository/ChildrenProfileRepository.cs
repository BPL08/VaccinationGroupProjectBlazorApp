using BO.Entity;
using DAO;
using Repository.Interface;

namespace Repository.Repository
{
    public class ChildrenProfileRepository : IChildrenProfileRepository
    {
        public void AddProfile(ChildrenProfile profile) => ChildrenProfileDAO.Instance.AddProfile(profile);
        public ChildrenProfile GetProfileById(Guid profileId) => ChildrenProfileDAO.Instance.GetProfileById(profileId);
        public List<ChildrenProfile> GetProfilesByAccountId(Guid accountId) => ChildrenProfileDAO.Instance.GetProfilesByAccountId(accountId);
        public List<ChildrenProfile> GetAllProfiles() => ChildrenProfileDAO.Instance.GetAllProfiles();
        public void UpdateProfile(Guid profileId, ChildrenProfile profile) => ChildrenProfileDAO.Instance.UpdateProfile(profileId, profile);
        public void DeleteProfile(Guid profileId) => ChildrenProfileDAO.Instance.DeleteProfile(profileId);
        /*        public void AddChildrenProfile(ChildrenProfile profile) => ChildrenProfileDAO.Instance.AddChildrenProfile(profile);

                public ChildrenProfile GetChildrenProfileById(Guid profileId) => ChildrenProfileDAO.Instance.GetChildrenProfileById(profileId);

                public List<ChildrenProfile> GetAllChildrenProfiles() => ChildrenProfileDAO.Instance.GetAllChildrenProfiles();

                public List<ChildrenProfile> GetChildrenProfilesByParent(int parentId) => ChildrenProfileDAO.Instance.GetChildrenProfilesByParent(parentId);

                public void UpdateChildrenProfile(int profileId, ChildrenProfile profile) => ChildrenProfileDAO.Instance.UpdateChildrenProfile(profileId, profile);

                public void DeleteChildrenProfile(int profileId) => ChildrenProfileDAO.Instance.DeleteChildrenProfile(profileId);

                public List<ChildrenProfile> GetChildrenProfilesByAgeRange(int minAge, int maxAge) => ChildrenProfileDAO.Instance.GetChildrenProfilesByAgeRange(minAge, maxAge);

                public List<ChildrenProfile> GetChildrenProfilesByGender(string gender) => ChildrenProfileDAO.Instance.GetChildrenProfilesByGender(gender);*/
    }
}