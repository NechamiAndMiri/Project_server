using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBL
    {
        Task<TblUser> getUser(string firstName, string lastName, string password);
        Task PostUser(TblUser user);
    }
}