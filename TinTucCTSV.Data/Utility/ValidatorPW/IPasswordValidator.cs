using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TinTucCTSV.Data.Utility.Validator
{
    public interface IPasswordValidator<TUser> where TUser : class
{
    Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password);
}
}