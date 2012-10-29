using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace WindowsHive
{
    class JobParser
    {

        // private methods
        private const string xns = "http://tempuri.org";
        private const string xsd = "hive.xsd";
        private XmlDocument jobsXML;

        // public methods
        public bool Valid = true;
        public string Name;
        public string Default;
        public string OnError;
        public string OnSuccess;
        public string OnRetry;
        public ArrayList Jobs = new ArrayList();

        public JobParser(string path)
        {
            LoadFile(path);
            ParseRoot();
            ParseJobs();
        }

        private void LoadFile(string path)
        {
            try
            {
                if(File.Exists(path) && File.Exists(xsd))
                {
                    jobsXML = new XmlDocument();
                    jobsXML.Schemas.Add(xns, xsd);
                    jobsXML.Load(path);
                    ValidationEventHandler schemaError = new ValidationEventHandler(SchemaError);
                    jobsXML.Validate(schemaError);
                }
                else
                {
                    Valid = false;
                }
            }
            catch (Exception ex)
            {
                Valid = false;
                Feedback.Error("ERROR: File load error: " + ex.Message);
            }
        }

        private void ParseRoot()
        {
            Name = jobsXML.DocumentElement.Attributes["name"].Value;
            Default = jobsXML.DocumentElement.Attributes["default"].Value;
            OnError = jobsXML.DocumentElement.Attributes["onError"].Value;
            OnSuccess = jobsXML.DocumentElement.Attributes["onSuccess"].Value;
            OnRetry = jobsXML.DocumentElement.Attributes["onRetry"].Value;
        }

        private void ParseJobs()
        {
            foreach (XmlNode jobNode in jobsXML["hive"])
            {
                Job job = new Job();
                job.Name = jobNode.Attributes["name"].Value;
                job.Retry = Int32.Parse(jobNode.Attributes["retry"].Value);
                job.Threads = Int32.Parse(jobNode.Attributes["threads"].Value);
                job.Enabled = Boolean.Parse(jobNode.Attributes["enabled"].Value);
                Jobs.Add(job);
            }
        }

        private void SchemaError(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
            {
                Feedback.Verbose("WARNING: Schema validation warning: " + args.Message);
            }
            else
            {
                Feedback.Error("ERROR: Schema validation error: " + args.Message);
                Valid = false;
            }
        }

    }

    class Job
    {
        public string Name { get; set; }
        public int Retry { get; set; }
        public int Threads { get; set; }
        public bool Enabled { get; set; }
    }

}
