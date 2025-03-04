using Abp;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Authorization.Users.DataCleaners
{
    public interface IUserDataCleaner
    {
        Task CleanUserData(UserIdentifier userIdentifier);
    }
}
