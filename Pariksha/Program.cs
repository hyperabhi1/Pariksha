using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pariksha
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Summary:
            //     Initializes a new instance of the System.Threading.Mutex class with a Boolean
            //     value that indicates whether the calling thread should have initial ownership
            //     of the mutex, and a string that is the name of the mutex.
            //
            // Parameters:
            //   initiallyOwned:
            //     true to give the calling thread initial ownership of the named system mutex if
            //     the named system mutex is created as a result of this call; otherwise, false.
            //
            //   name:
            //     The name of the System.Threading.Mutex. If the value is null, the System.Threading.Mutex
            //     is unnamed.
            //
            // Exceptions:
            //   T:System.UnauthorizedAccessException:
            //     The named mutex exists and has access control security, but the user does not
            //     have System.Security.AccessControl.MutexRights.FullControl.
            //
            //   T:System.IO.IOException:
            //     A Win32 error occurred.
            //
            //   T:System.Threading.WaitHandleCannotBeOpenedException:
            //     The named mutex cannot be created, perhaps because a wait handle of a different
            //     type has the same name.
            //
            //   T:System.ArgumentException:
            //     name is longer than 260 characters.
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                // Summary:
                //     Blocks the current thread until the current System.Threading.WaitHandle receives
                //     a signal, using a 32-bit signed integer to specify the time interval and specifying
                //     whether to exit the synchronization domain before the wait.
                //
                // Parameters:
                //   millisecondsTimeout:
                //     The number of milliseconds to wait, or System.Threading.Timeout.Infinite (-1)
                //     to wait indefinitely.
                //
                //   exitContext:
                //     true to exit the synchronization domain for the context before the wait (if in
                //     a synchronized context), and reacquire it afterward; otherwise, false.
                //
                // Returns:
                //     true if the current instance receives a signal; otherwise, false.
                //
                // Exceptions:
                //   T:System.ObjectDisposedException:
                //     The current instance has already been disposed.
                //
                //   T:System.ArgumentOutOfRangeException:
                //     millisecondsTimeout is a negative number other than -1, which represents an infinite
                //     time-out.
                //
                //   T:System.Threading.AbandonedMutexException:
                //     The wait completed because a thread exited without releasing a mutex. This exception
                //     is not thrown on Windows 98 or Windows Millennium Edition.
                //
                //   T:System.InvalidOperationException:
                //     The current instance is a transparent proxy for a System.Threading.WaitHandle
                //     in another application domain.
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Instance already running");
                    return;
                }
                Application.Run(new Pariksha());
            }
        }
    }
}
