using AutoMapper;
using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// using the tables:
///     1. users
///     2.Patients
/// </summary>

namespace Project_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly IMapper _mapper;
        private IPatientBL patientBL;
        private IUserBL userBL;
        public PatientController(IPatientBL patientBL,IMapper mapper,IUserBL userBL)
        {   
          _mapper = mapper;
          this.patientBL = patientBL;
          this.userBL = userBL;
        }
        //public IActionResult Index()
        //{
        //    // Populate the user details from DB
        //    var user = GetUserDetails();
        //    UserViewModel userViewModel = _mapper.Map<UserViewModel>(user)
        //return View(userViewModel);}
     
        
        /// note: יתכן שאפשר לאחד את 2 GET -להלן ה
        ///

        // GET: api/<PatientController>
        /// screens:
        /// 1. admin
        [HttpGet("{speechTherapistId}")]
        // בשביל מסך המנהל- מקבל פרמטר של סוג הסינון, ומחזיר רשימה של כל המטופלים המותאמות לתנאי 

        public async Task<List<PatientDTO>> Get(int speechTherapistId)
        {
            // return all patient list

            return await patientBL.GetPatient(speechTherapistId);
        }

     
        ///////////////////בעקרון מיותר- לבדוק//////////////////////////
        /// screens:
        /// 1. SpeechTherapist -> patients
        //[HttpGet("{SpeechTherapistID}/{param}/{searchType}")]
        //public List<TblPatient> Get(int SpeechTherapistID, string param = null, int searchType = 0)//הפרמטרים הנוספים עבור הסינון
        //{
        //    // return all patient list for the SpeechTherapist
        //    return null;
        //}


        /// screens:
        /// 1. SpeechTherapist -> patients->add
        // POST api/<PatientController>
        [HttpPost]
        public async Task Post([FromBody] TblPatient patient)
        {
            await patientBL.PostPatient(patient);

        }
        /// screens:
        /// 1. SpeechTherapist -> patients->edit
        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] TblPatient tblPatient)
        {
            await patientBL.PutPatient(id,tblPatient);
        }
        /// screens:
        /// 1. SpeechTherapist -> patients->delete
        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await patientBL.deletePatient(id);
        }
    }
}
