﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Configuration
{
    public class EmailAttributes
    {
        public string service { get; set; }
        public int popPort { get; set; }
        public string popServer { get; set; }
        public int imapPort { get; set; }
        public string imapServer { get; set; }
        public int smtpPort { get; set; }
        public string smtpServer { get; set; }
        public bool useSsl { get; set; }

        public string username { get; set; }
        public string password { get; set; }
    }
}
