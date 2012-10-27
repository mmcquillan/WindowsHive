using System;
using System.Xml;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace MultiExec
{
    class JobParser
    {

        public string Name;
        public string defaultJob;
        public string onErrorJob;
        public string onSuccessJob;
        public string onRetryJob;
        public Dictionary<string, string> Jobs;

        public JobParser(string path)
        {

        }


    }
}
