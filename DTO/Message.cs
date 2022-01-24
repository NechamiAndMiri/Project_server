using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class MessageDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string MessageText { get; set; }
        public bool IsAnswer { get; set; }
        public DateTime DateOfWriting { get; set; }
        public bool IsRead { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
