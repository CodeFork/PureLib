﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace PureLib.Legacy.Configuration {
    public class MailConfiguration : ConfigurationElement {
        private const string from = "from";
        private const string to = "to";
        private const string cc = "cc";
        private const string bcc = "bcc";
        private const string host = "host";
        private const string port = "port";
        private const string ssl = "ssl";
        private const string userName = "username";
        private const string password = "password";

        [ConfigurationProperty(from, IsRequired = true)]
        public string From {
            get { return (string)this[from]; }
        }

        [ConfigurationProperty(to, IsRequired = true)]
        public string To {
            get { return (string)this[to]; }
        }

        [ConfigurationProperty(cc)]
        public string CC {
            get { return (string)this[cc]; }
        }

        [ConfigurationProperty(bcc)]
        public string Bcc {
            get { return (string)this[bcc]; }
        }

        [ConfigurationProperty(host, IsRequired = true)]
        public string Host {
            get { return (string)this[host]; }
        }

        [ConfigurationProperty(port, DefaultValue = 25, IsRequired = true)]
        public int Port {
            get { return (int)this[port]; }
        }

        [ConfigurationProperty(ssl, DefaultValue = false, IsRequired = true)]
        public bool EnableSsl {
            get { return (bool)this[ssl]; }
        }

        [ConfigurationProperty(userName, IsRequired = true)]
        public string UserName {
            get { return (string)this[userName]; }
        }

        [ConfigurationProperty(password, IsRequired = true)]
        public string Password {
            get { return (string)this[password]; }
        }
    }
}
