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
         * Filter lovi88|exc for both (fileter is a Regex )
         * 
         * You can add new columns, Sort by columns, Text filter by columns and filter by time with the start end or by selecting on the histogram and Alt+R.
         * 
         * You can select more than one event type and push F5 to show them.
         * 
         * If you select an exception wich has stack: Right click Open Any stack shows the stack information of that stack.
         * 
         * The filter can be used to filter to CPU usage, or GC usage and much more.
         * 
         * Sometimes the PV process blocks the file to analyze with other tools you may want to abort collecting by Collection/Abort (Alt+A)
         * 
         * PerfView can be opened from command prompt and has a CLI to address all its main features.
         * 
         * You can merge the file if you want so you can analyze the etl file in an other machine. (It is a long process.)
         */

        #endregion

        #region WPR amd WPR
        /**
         * WPR amd WPR
         * 
         * WPR: Win Perf Recorder 
         *     Can be used for collecting.
         * 
         * WPA: Win Perf Analyzer
         * 
         * To use etl files created by PerfView you may have to merge the files.
         *     Merging etl files: With PerfView or by xperf -merge PerfViewData.etl PerfViewData.kernel.etl merged.etl
         * 
         * Open System Activity/Generic Events to see your events.
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
