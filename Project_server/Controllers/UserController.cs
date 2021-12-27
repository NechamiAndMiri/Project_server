using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;
using DTO;

/// <summary>
/// using the tables:
///     1. users
/// </summary>

namespace Project_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUserBL userBL;
        IPatientBL patientBL;
        ISpeechTherapistBL SpeechTherapistBL;

        public UserController(IUserBL userBL, IPatientBL patientBL, ISpeechTherapistBL SpeechTherapistBL)
        {
            this.userBL = userBL;
            this.patientBL = patientBL;
            this.SpeechTherapistBL = SpeechTherapistBL;
        }

        // GET api/<UserController>/5

        /// screens:
        /// 1. login
        [HttpGet("{firstName}, {lastName},{password}")]
        public async Task<UserDTO> Get(string firstName, string lastName, string password)
        {
            //return current user
            UserDTO userDTO;
              TblUser user= await userBL.getUser(firstName,lastName, password);
            if (user.PermissionLevelId == 1)
            {
                userDTO = new UserDTO();
                userDTO.User = user;
                return userDTO;
            } 
            else if (user.PermissionLevelId == 2)
            {
                userDTO = new SpeechTherapistDTO();
                ((SpeechTherapistDTO)userDTO).User = user;
                ((SpeechTherapistDTO)userDTO).SpeechTherapist = await SpeechTherapistBL.GetSingleSpeechTherapist(user.Id);
                return ((SpeechTherapistDTO)userDTO);
            }
            else if(user.PermissionLevelId == 3)
            {
                userDTO = new PatientDTO();
                ((PatientDTO)userDTO).User = user;
                ((PatientDTO)userDTO).Patient = await patientBL.GetSinglePatient(user.Id);
                return ((PatientDTO)userDTO);
            }
        

            return null;
        }

    
    }
}
