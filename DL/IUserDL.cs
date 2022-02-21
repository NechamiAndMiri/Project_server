using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        public Task<TblUser> getUser(string firstName, string lastName, string password);
        public Task<TblUser> GetUser(int userId);
        Task PostUser(TblUser user);
    }
}