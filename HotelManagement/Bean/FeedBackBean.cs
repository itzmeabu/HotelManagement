using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Bean
{
    [DataContract]
    public class FeedBackBean
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "Phone")]
        public string Phone { get; set; }

        [DataMember(Name = "MailSubject")]
        public string MailSubject { get; set; }

        [DataMember(Name = "MailBody")]
        public string MailBody { get; set; }
    }
}
