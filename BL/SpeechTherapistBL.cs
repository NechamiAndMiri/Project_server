using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using DTO;
using Entities;

namespace BL
{
    public class SpeechTherapistBL: ISpeechTherapistBL
    {
        ISpeechTherapistDL speechTherapistDL;

        public SpeechTherapistBL(ISpeechTherapistDL speechTherapistDL)
        {
            this.speechTherapistDL = speechTherapistDL;
        }


        public async Task<List<SpeechTherapistDTO>> GetaAllSpeechTherapists()
        {
            return await speechTherapistDL.GetaAllSpeechTherapists();
        }


        //for the login
        public async Task<TblSpeechTherapist> GetSingleSpeechTherapist(int userId)
        {
            return await speechTherapistDL.GetSingleSpeechTherapist(userId);
        }

        public async Task PostSpeechTherapist(TblSpeechTherapist speechTherapist)
        {
            await speechTherapistDL.PostSpeechTherapist(speechTherapist);
        }

        public async Task PutSpeechTherapist(int id,TblSpeechTherapist tblspeechTherapist)
        {
            await speechTherapistDL.PutSpeechTherapist(id,tblspeechTherapist);
        }

        public async Task DeleteSpeechTherapist(int id)
        {
            await speechTherapistDL.DeleteSpeechTherapist(id);
        }

        
    }
}
