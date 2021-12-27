using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{ 

    public class UserDL : IUserDL
    {
        GeneralDBContext generalDBContext = new GeneralDBContext();

        public async Task<TblUser> getUser(string firstName,string lastName, string password)
        {
        
          List<TblUser> l= await  generalDBContext.TblUsers.Where(x=>x.Password==password&&x.FirstName==firstName&&x.LastName==lastName).ToListAsync();
            return l[0];
        }

        public async Task<TblUser> GetUser(int userId)
        {
            return await generalDBContext.TblUsers.FindAsync(userId);
        }



        ///////////////בשביל מה עשינו את זה? בעקרון צריך למחוק//////////////////////
        public async Task PostUser(TblUser tblUser)
        {
            await generalDBContext.TblUsers.AddAsync(tblUser);
            await generalDBContext.SaveChangesAsync();  
        }
    }
}
