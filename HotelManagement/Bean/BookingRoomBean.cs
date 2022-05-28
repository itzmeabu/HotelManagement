using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Bean
{
    [DataContract]
    public class BookingRoomBean
    {
        [DataMember(Name = "FirstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "Phone")]
        public string Phone { get; set; }

        [DataMember(Name = "LastName")]
        public string LastName { get; set; }

    }
}
