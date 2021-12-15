using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MessageBL : IMessageBL
    {
        IMessageDL messageDL;

        public MessageBL(IMessageDL messageDL)
        {
            this.messageDL = messageDL;
        }

        public async Task DeleteMessage(int id)
        {
            await messageDL.deleteMessage(id);
        }

        public async Task<IEnumerable<TblMessage>> getMessage(int speechTherapistID)
        {
            return await messageDL.getMesssage(speechTherapistID);
           
        }

        async public Task postMessage(TblMessage value)
        {
            await messageDL.postMessage( value);
        }

        public async Task putMessage(int id)
        {
            await messageDL.putMessage(id);
        }
        public async Task deleteMessage(int id)
        {
            await messageDL.deleteMessage(id);
        }
    }
}
