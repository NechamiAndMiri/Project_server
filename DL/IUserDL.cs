using Entities;

namespace DL
{
    public interface IUserDL
    {
        TblUser getUser(string userName, string password);
    }
}