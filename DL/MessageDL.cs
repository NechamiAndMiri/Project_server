using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  

namespace DL
{
    public class MessageDL : IMessageDL
    {
        GeneralDBContext generalDBContext = new GeneralDBContext();

      

        async public Task<List<TblMessage>> getMesssage(int speechTherapistID)
        {
             return await generalDBContext.TblMessages.Where(m => m.Patient.SpeechTherapistId == speechTherapistID).Include(m=>m.Patient).ThenInclude(m=>m.User).ToListAsync(); 
        }

        public async Task postMessage( TblMessage value)
        {
           await generalDBContext.TblMessages.AddAsync(value);
           await generalDBContext.SaveChangesAsync();
        }

        public async Task putMessage(int id)
        {
            TblMessage message=await generalDBContext.TblMessages.FindAsync(id);
            var x=generalDBContext.Entry(message);
            message.IsRead = !message.IsRead;
            x.CurrentValues.SetValues(message);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task deleteMessage(int id)
        {
            TblMessage message = await generalDBContext.TblMessages.FindAsync(id);
            generalDBContext.TblMessages.Remove(message);
            await generalDBContext.SaveChangesAsync();
        }
    }
}
