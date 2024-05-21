using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer.Concrete
{
    public class Message
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public bool ImportantMessage { get; set; }
        public bool MessageTrash { get; set; }
        public AppUser SenderUser { get; set; }
        public AppUser ReceiverUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }

        public string ReceiverName { get; set; }
        public string ReceiverSurname { get; set; }
        public string ReceiverImageUrl { get; set; }
    }
}
