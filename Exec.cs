using System;
using System.Xml;

namespace MultiExec
{
	class Exec
	{

        private XmlNode command;

        public Exec(XmlNode node)
        {
            command = node;
        }

		public void Run(Object obj)
		{

            // feedback
            DateTime startTime = DateTime.Now;

            try
            {

                Console.WriteLine(command.OuterXml);

                // feedback
                DateTime stopTime = DateTime.Now;
                TimeSpan duration = stopTime - startTime;
                Console.WriteLine("+" + String.Format("{0,10:0.000}", duration.TotalSeconds) + "s ");

            }
            catch (Exception ex)
            {
                Console.WriteLine("! ERROR: " + ex.Message);
                Program.Success = false;
            }
            
		}

	}
}
