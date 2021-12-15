using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IMessageBL
    {
         Task<IEnumerable<TblMessage>> getMessage(int speechTherapistID);
        Task postMessage(TblMessage value);
        Task putMessage(int id);
        Task deleteMessage(int id);
    }
}