using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NtsdAndWinDbgUsage
{
    internal static class DebuggingProgram
    {
        #region Ntsd and WinDbg usage

        /**
        * ntsd and WinDbg(parts of the Win SDK)
        * The project uses a 64bit build(because Wow64 could be tricky)
        * 
        * ntsd command stepps:
        * ntsd Debugging.exe
        * .symfix
        * .reload
        * g
        * CTRL+C - Break in.
        * .loadby sos clr (mscorwks in 3.5)
        * or.load fullpath
        * !DumpDomain
        * !DumpAssembly
        * !eeheap -loader show the modules loaded
        * ~0s - jumps to the first thread
        * !ClrStack
        * !ClrStack -a
        * dq addr - raw dumps memory(dump quad word)
        * du addr - raw dumps memory(dump unicode)
        * !SyncBlk - shows the sync block table. (Obj instances has sync like lock information.This is on the heap or in the syncblk table)
        * !do addr(dumps object)
        * -> Shows method table(called Type handle as well)
        * -> Shows properties etc.
        * !DumpMT - Dump method table
        * !DumpMT -md method_descriptor
        * !DumpMD - dumps a method descriptor
        * -> CodeAddr: is the addr of the machine code for jitted methods
        * u code_addr - unassemble shows the machine code
        * 
        * 
        * q - quits the debuging session
        * 
        * ------------------------------------------------------
        * WinDbg(the ntsd commands can be used as well): 
        * Run NtsdAndWinDbgUsage.exe
        * Attach Windbg (F6)
        * .loadby sos clr
        * .chain - shows the loadad sos
        * .prefer_dml 0/1 turns off/on the links in debugger (on is preferred)
        * !help - sos help
        * !help cmdName - detailed command help
        * 
        * Extensions:
        *     SOSEX
        *     PSSCOR2/4 - helps IIS debugging and more
        */

        #endregion
        private static void Main(string[] args)
        {
            while (!Debugger.IsAttached)
            {
                Console.WriteLine("Waiting for a debugger.");
                Thread.Sleep(1000);
            }

            Console.WriteLine($"Is Debugger Attached: {Debugger.IsAttached}");
            Console.WriteLine("WinDbg id cool");
        }
    }
}
