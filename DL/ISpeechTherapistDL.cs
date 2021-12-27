using DTO;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ISpeechTherapistDL
    {
        Task<TblSpeechTherapist> GetSingleSpeechTherapist(int userId);
        Task<IEnumerable<SpeechTherapistDTO>> GetaAllSpeechTherapists();
        Task PostSpeechTherapist(TblSpeechTherapist speechTherapist);
        Task PutSpeechTherapist(int id,TblSpeechTherapist tblspeechTherapist);
        Task DeleteSpeechTherapist(int id);
       
    }
}