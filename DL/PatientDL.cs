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
        public PatientDL( IUserDL userDL, GeneralDBContext generalDBContext)
        {
            this.userDL = userDL;
           this.generalDBContext= generalDBContext;
        }

        async public Task<List<PatientDTO>> GetPatient(int speechTherapistId)
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

            // הפונקציה שלהלן לא מסונכרנת עם השליפה של המשתמש בכניסה למערכת
            // שם השתמשנו בDTO ופה לא
            // מסתבר שיווצרו בעיות, אפשר לשנות גם כאן לDTO
        {
            TblPatient patient = await generalDBContext.TblPatients.FindAsync(id);
            TblUser user= await generalDBContext.TblUsers.FindAsync(patient.UserId);//לברר למה זה לא עבד בלי לטפל בנפרד בטבלת משתמש
            tblPatient.User.Password = user.Password;
            if (patient==null)
            {
                return;
            }
            generalDBContext.Entry(user).CurrentValues.SetValues(tblPatient.User);//כנ"ל
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
