using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Services
{
    class MessageServiceB:IMessageService
    {
        public string GetMessage()
        {
            return "This is B";
        }

        public bool SendMessage(string message)
        {
            return true;
        }
    }
}
