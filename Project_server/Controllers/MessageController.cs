using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// using the tables:
///     1. Message
/// </summary>
namespace Project_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        IMessageBL messageBL;

        public MessageController(IMessageBL messageBL)
        {
            this.messageBL = messageBL;
        }

        /// screens:
        /// 1. SpeechTherapist->msg
        // GET: api/<MessageController>

        [HttpGet("{SpeechTherapistID}")]
         public async Task<IEnumerable<TblMessage>> Get(int SpeechTherapistID)
        {
            //return all the msgs
            return await messageBL.getMessage(SpeechTherapistID);


        }
        /// screens:
        /// 1. SpeechTherapist->msg
        /// 2.patient
        // POST api/<MessageController>
        [HttpPost]
        public async Task Post([FromBody] TblMessage value)
        {
             await messageBL.postMessage(value);
        }
        /// screens:
        /// 1. SpeechTherapist->msg
        // PUT api/<MessageController>/5
        [HttpPut("{id}")]
        public async Task Put(int id)
        {
            // update col read?
            await messageBL.putMessage(id);
        }
        /// screens:
        /// 1. SpeechTherapist->msg
        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        async public Task Delete(int id)
        {
            //Delete msg
            await messageBL.deleteMessage(id);
        }
    }
}
