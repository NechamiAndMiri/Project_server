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
///     2. Speech_therapists
/// </summary>

namespace Project_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechTherapistController : ControllerBase
    {

        ISpeechTherapistBL speechTherapistBL;

        public SpeechTherapistController(ISpeechTherapistBL speechTherapistBL)
        {
            this.speechTherapistBL = speechTherapistBL;
        }


        // GET: api/<SpeechTherapistController>
        [HttpGet]
        /// screens:
        /// 1. admin
         // בשביל מסך המנהל- מקבל פרמטר של סוג הסינון, ומחזיר רשימה של כל הקלינאיות המותאמות לתנאי 
        public async Task<IEnumerable<SpeechTherapistDTO>> Get()
        {
            //return TblSpeechTherapist list
            return await speechTherapistBL.GetaAllSpeechTherapists();
        }



        //////////////לבדוק אם צריך את זה- לשים לב זה מחזיר רק את החלק של הקלינאית ולא את כל המשתמש////////
        
        // GET api/<SpeechTherapistController>/5 
        /// screens:
        /// 1. SpeechTherapist
        [HttpGet("{userId}")]
        public async Task<TblSpeechTherapist> Get(int userId)
        {
            // return the current SpeechTherapist
            return await speechTherapistBL.GetSingleSpeechTherapist(userId);
        }
       //////////////////////////////////////////////////////////////////////////////////////////// 

        // POST api/<SpeechTherapistController>
        /// screens:
        /// 1. admin
        [HttpPost]
        public async Task Post([FromBody] TblSpeechTherapist speechTherapist)
        {
           await speechTherapistBL.PostSpeechTherapist(speechTherapist);
        }

        // PUT api/<SpeechTherapistController>/5
        /// screens:
        /// 1. admin
        /// 2. SpeechTherapist
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] TblSpeechTherapist tblspeechTherapist)
        {
            await speechTherapistBL.PutSpeechTherapist(id,tblspeechTherapist);
        }

        // DELETE api/<SpeechTherapistController>/5
        /// screens:
        /// 1. admin
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
          await speechTherapistBL.DeleteSpeechTherapist(id);
        }
    }
}
