using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ETWExcercise
{
    internal static class EtwProgram
    {
        private static volatile bool _stop;
        private static int _cnt;

        #region How to use PerfView

        /**
         * Use PerfView to collect Events
         * 
         * Start PV
         * Collect/Run (Alt+R) to run the executable 
         *     Or Use Collect to collect from a running application (Alt+C)
         * Command: The path to the executable to run (Just in run mode)
         * Data file: Collect Events to this *etl file.
         * Current dir: the location to put the data file.
         * Uncheck Merge if you do not need the kernel events in the same file. (Unchecking can speed up collection)
         * Advanced/Additional providers:
         *     Use:*Lovi88-ETW-Exercise (star name of the source)
         *     Use:@%Ewt_bin%/ETWExcercise.exe (at full path to assembly containing the provider sources)
         * Stop Trigger: In production it can be used to stop collectig to an event.
         * Run Command/Start Collection
         * Cancell collection.
         * 
         * Now you can open the Data file etl file
         * Process filter: ETWExcercise to see exceptions just from this process.
         * Filer: Use lovi88 to see the messages.
         * Fileter Use exc -> Exception start to find the thrown exception
         * Filter lovi88|exc for both (fileter is a Regex)
         * 
         * Sometimes the PV process blocks the file to analyze with other tools you may want to abort collecting by Collection/Abort (Alt+A)
         * 
         * You can merge the file if you want so you can analyze the etl file in an other machine. (It is a long process.)
         */

        #endregion



        /// <summary>
        /// Start the program to send ETW events
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            new Thread(() =>
            {
                Console.WriteLine("Push a button to stop.");
                Console.ReadKey();
                _stop = true;
            }).Start();

            while (!_stop)
            {
                PerformanceEventSource.Log.Message();
                Console.WriteLine("ETW Message sent.");

                _cnt++;
                if (_cnt > 50)
                {
                    throw new Exception("Sorry bro I realy have to stop.");
                }

                Thread.Sleep(500);
            }
        }
    }
}
