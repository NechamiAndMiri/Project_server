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
        GeneralDBContext generalDBContext;
        public UserDL(GeneralDBContext generalDBContext)
        {
            this.generalDBContext = generalDBContext;
        }

        public async Task<TblUser> getUser(string firstName,string lastName, string password)
        {
        
          List<TblUser> l= await  generalDBContext.TblUsers.Where(x=>x.Password==password&&x.FirstName==firstName&&x.LastName==lastName).ToListAsync();
            return l[0];
        }

        public async Task<TblUser> GetUser(int userId)
        {
            return await generalDBContext.TblUsers.FindAsync(userId);
        }



    
        public async Task PostUser(TblUser tblUser)
        {
            await generalDBContext.TblUsers.AddAsync(tblUser);
            await generalDBContext.SaveChangesAsync();  
        }
    }
}
