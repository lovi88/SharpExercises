using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ETWExcercise
{
    [EventSource(Name = "Lovi88-ETW-Exercise")]
    sealed class PerformanceEventSource : EventSource
    {
        private static readonly Lazy<PerformanceEventSource> _log
            = new Lazy<PerformanceEventSource>(() => new PerformanceEventSource());

        internal static PerformanceEventSource Log => _log.Value;

        private PerformanceEventSource() { }

        [Event(1)]
        public void Message()
        {
            if (IsEnabled())
            {
                WriteEvent(1);
            }
        }
    }
}
