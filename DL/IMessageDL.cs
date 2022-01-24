using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IMessageDL
    {
        Task<List<TblMessage>> getMesssage(int speechTherapistID);
        Task postMessage( TblMessage value);
        Task putMessage(int id);
        Task deleteMessage(int id);
    }
}