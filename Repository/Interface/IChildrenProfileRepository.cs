using BO.Entity;

namespace Repository.Interface
{
    public interface IChildrenProfileRepository
    {
        void AddProfile(ChildrenProfile profile);
        ChildrenProfile GetProfileById(Guid profileId);
        List<ChildrenProfile> GetProfilesByAccountId(Guid accountId);
        List<ChildrenProfile> GetAllProfiles();
        void UpdateProfile(Guid profileId, ChildrenProfile profile);
        void DeleteProfile(Guid profileId);
        /*        void AddChildrenProfile(ChildrenProfile profile);
                ChildrenProfile GetChildrenProfileById(Guid profileId);
                List<ChildrenProfile> GetAllChildrenProfiles();
                List<ChildrenProfile> GetChildrenProfilesByAccount(string accountId);
                List<ChildrenProfile> GetChildrenProfilesByAgeRange(int minAge, int maxAge);
                List<ChildrenProfile> GetChildrenProfilesByStatus(string status);
                void UpdateChildrenProfile(Guid profileId, ChildrenProfile profile);
                void DeleteChildrenProfile(Guid profileId);
                List<ChildrenProfile> GetChildrenProfilesByBirthDateRange(DateTime startDate, DateTime endDate);
                List<ChildrenProfile> GetChildrenProfilesByGender(string gender);*/
    }
}