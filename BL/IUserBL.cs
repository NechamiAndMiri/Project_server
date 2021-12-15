using Entities;

namespace BL
{
    public interface IUserBL
    {
        TblUser getUser(string userName, string password);
    }
}