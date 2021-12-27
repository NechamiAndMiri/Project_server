using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class SpeechTherapistDL : ISpeechTherapistDL
    {
        GeneralDBContext generalDBContext;
        IUserDL userDL;
        public SpeechTherapistDL(IUserDL userDL)
        {
            this.userDL = userDL;
            generalDBContext = new GeneralDBContext();
        }


        public async Task<IEnumerable<SpeechTherapistDTO>> GetaAllSpeechTherapists()
        {
            List<TblSpeechTherapist> speechTherapists=await generalDBContext.TblSpeechTherapists.ToListAsync();

            List<SpeechTherapistDTO> speechTherapistDTOs = new List<SpeechTherapistDTO>();
            TblUser userDTO = new TblUser();
            foreach (var speechTherapist in speechTherapists)
            {
                userDTO = await userDL.GetUser(speechTherapist.UserId);
                SpeechTherapistDTO new_speechTherapist = new SpeechTherapistDTO() { SpeechTherapist = speechTherapist, User = userDTO };
                speechTherapistDTOs.Add(new_speechTherapist);
            }
            return speechTherapistDTOs;

        }

        public async Task<TblSpeechTherapist> GetSingleSpeechTherapist(int userId)
        {
            List<TblSpeechTherapist> s = await generalDBContext.TblSpeechTherapists.Where(x => x.UserId == userId).ToListAsync();
            return s[0];
        }

        public async Task PostSpeechTherapist(TblSpeechTherapist speechTherapist)
        {
            await generalDBContext.TblSpeechTherapists.AddAsync(speechTherapist);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task PutSpeechTherapist(int id,TblSpeechTherapist tblspeechTherapist)
        {
            TblSpeechTherapist speechTherapist = await generalDBContext.TblSpeechTherapists.FindAsync(id);
            if (speechTherapist == null)
            {
                return;
            }
            generalDBContext.Entry(speechTherapist).CurrentValues.SetValues(tblspeechTherapist);
            await generalDBContext.SaveChangesAsync();
        }


        public async Task DeleteSpeechTherapist(int id)
        {
            TblSpeechTherapist speechTherapist = await generalDBContext.TblSpeechTherapists.FindAsync(id);
            int userId = speechTherapist.UserId;
            generalDBContext.TblSpeechTherapists.Remove(speechTherapist);
            TblUser user = await generalDBContext.TblUsers.FindAsync(userId);
            generalDBContext.TblUsers.Remove(user);
            await generalDBContext.SaveChangesAsync();
        }

    }
}
