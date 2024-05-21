using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> GetListReceiverMessage(int p);
        List<Message> GetListSenderMessage(int p);
        List<Message> Last3Message(int p);
    }
}
