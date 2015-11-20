using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Services
{
    class MessageServiceA : IMessageService
    {
        public string GetMessage()
        {
            return "This is A";
        }

        public bool SendMessage(string message)
        {
            return true;
        }
    }
}
