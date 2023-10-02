using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendMail.UI.DAL.Interface
{
   public interface IRabbitMQService
    {
        void SendMessage(string message);
    }
}
