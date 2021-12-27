using DTO;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ISpeechTherapistBL
    {
        Task<TblSpeechTherapist> GetSingleSpeechTherapist(int id);
        Task<IEnumerable<SpeechTherapistDTO>> GetaAllSpeechTherapists();
        Task PostSpeechTherapist(TblSpeechTherapist speechTherapist);
        Task PutSpeechTherapist(int id,TblSpeechTherapist tblspeechTherapist);
        Task DeleteSpeechTherapist(int id);
        
    }
}