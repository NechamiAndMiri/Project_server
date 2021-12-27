using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class PatientDL : IPatientDL
    {

        GeneralDBContext generalDBContext;
        IUserDL userDL;
        public PatientDL( IUserDL userDL)
        {
            this.userDL = userDL;
            generalDBContext = new GeneralDBContext();
        }

        async public Task<IEnumerable<PatientDTO>> GetPatient(int speechTherapistId)
        {
            List<TblPatient> patients= await generalDBContext.TblPatients.Where(p => p.SpeechTherapistId == speechTherapistId).ToListAsync();
            
            List<PatientDTO> patientDTOs = new List<PatientDTO>();
            TblUser userDTO = new TblUser();
            foreach (var patient in patients)
            {
                userDTO = await userDL.GetUser(patient.UserId);
                PatientDTO new_patient = new PatientDTO() { Patient = patient, User = userDTO };
                patientDTOs.Add(new_patient);
            }

            return patientDTOs;
            
        } 
        
        public async Task deletePatient(int id)
        {
            TblPatient patient = await generalDBContext.TblPatients.FindAsync(id);
            int userId = patient.UserId;
            generalDBContext.TblPatients.Remove(patient);
            TblUser user = await generalDBContext.TblUsers.FindAsync(userId);
            generalDBContext.TblUsers.Remove(user);
            await generalDBContext.SaveChangesAsync();


        }

        public async Task PostPatient(TblPatient tblPatient)
        {
            await generalDBContext.TblPatients.AddAsync(tblPatient);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task PutPatient(int id, TblPatient tblPatient)
        {
            TblPatient patient = await generalDBContext.TblPatients.FindAsync(id);
            if (patient==null)
            {
                return;
            }
            generalDBContext.Entry(patient).CurrentValues.SetValues(tblPatient);
            await generalDBContext.SaveChangesAsync();

        }
        


        ///////from user controller/////////
        public async Task<TblPatient> GetSinglePatient(int userId)
        {
           
            List < TblPatient > p=await generalDBContext.TblPatients.Where(x => x.UserId == userId).ToListAsync();
            return p[0];
           
        }

        
    }
}
