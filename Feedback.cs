using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsHive
{
    class Feedback
    {

        public static VerbosityLevel verbosity = VerbosityLevel.Verbose;

        public static void Verbose(string write)
        {
            if (verbosity == VerbosityLevel.Verbose)
                Console.WriteLine(write);
        }

        public static void Minimal(string write)
        {
            if (verbosity <= VerbosityLevel.Minimal)
                Console.WriteLine(write);
        }

        public static void Error(string write)
        {
            Console.WriteLine(write);
        }

    }

    enum VerbosityLevel
    {
        Verbose = 1,
        Minimal = 2,
        Silent = 3
    }

}
