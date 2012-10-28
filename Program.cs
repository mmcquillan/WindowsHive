using System;
using System.Xml;
using System.IO;
using System.Threading;

namespace MultiExec
{

    class Program
    {

        // public to keep track of errors
        public static bool Success = true;
        public static int Threads = 0;

        // main program
        [MTAThread]
        static void Main(string[] args)
        {

            // collect stats
            DateTime startTime = DateTime.Now;

            // check for input
            if (args.Length != 1)
            {
                Console.WriteLine("EXITING WITH ERROR! No settings file supplied");
                Console.WriteLine(" mex.exe <file.xml>");
                Environment.Exit(1);
            }

            // job parser
            JobParser jobParser = new JobParser(args[0]);
            Console.WriteLine(jobParser.Name);

            // loop over jobs
            foreach (Job job in jobParser.Jobs)
            {
                if (Program.Success)
                {

                    // collect stats
                    DateTime cmdStartTime = DateTime.Now;

                    // feedback to console
                    Console.WriteLine("--" + job.Name);

                    /*
                    // create a threadpool
                    ThreadPoolWait threads = new ThreadPoolWait();
                    
                    // check the command has the right values
                    if (job.Name == "exec")
                    {

                        // loop over the command
                        foreach (XmlNode item in job)
                        {
                            Exec exec = new Exec(item);
                            threads.QueueUserWorkItem(new WaitCallback(exec.Run));
                        }

                        // wait for all threads to complete
                        threads.WaitOne();

                        // feedback on duration
                        DateTime cmdStopTime = DateTime.Now;
                        TimeSpan cmdDuration = cmdStopTime - cmdStartTime;
                        Console.WriteLine("=" + String.Format("{0,10:0.000}", cmdDuration.TotalSeconds) + "s ");

                    }
                    else
                    {
                        Console.WriteLine("! ERROR: Incorrect Config XML format.");
                        Program.Success = false;
                    }
                    */
                }

            }

            // feedback on duration
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            Console.WriteLine("");
            if (Success)
            {
                Console.WriteLine("All Completed in " + duration.TotalSeconds + "s");
            }
            else
            {
                Console.WriteLine("EXITING WITH ERROR! (" + duration.TotalSeconds + " sec)");
                Environment.Exit(1);
            }

        }

    }
}
