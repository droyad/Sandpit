using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nimbus.MessageContracts;

namespace Messages
{
    [Serializable]
    public class MessageB : IBusEvent
    {
        public DateTime Timestamp { get; set; }
    }
}
