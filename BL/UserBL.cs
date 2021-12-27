using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entities;

namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL userDL;

        public UserBL(IUserDL userDL)
        {
            this.userDL = userDL;
        }

        public async Task<TblUser> getUser(string firstName, string lastName, string password)
        {
           return await userDL.getUser(firstName, lastName, password);
        }

       
    }
}
