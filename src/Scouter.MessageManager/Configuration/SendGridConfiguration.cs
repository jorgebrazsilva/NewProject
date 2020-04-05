using System;
using System.Collections.Generic;
using System.Text;

namespace Scouter.MessageManager.Configuration
{
    public class SendGridConfiguration
    {
        public string Key { get; set; }
        public string Email { get; set; }
        public string SenderName { get; set; }
    }
}
