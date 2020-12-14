using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start() - Starter en tråd
            //Sleep() - Pauser en tråd 
            //Suspend() - Stopper tråd of venter på at blive resumed
            //Resume() - Genoptager en tråd
            //Abort() - Fjerner tråden
            //Join() - Venter må alle tråde i mainer færdige før den fortsætter.

            Thread thread1 = Thread.CurrentThread;
            thread1.Priority = ThreadPriority.Highest;
            ThreadPool.QueueUserWorkItem(MyMethod, thread1);

            Thread thread2 = Thread.CurrentThread;
            thread2.IsBackground = true;
            ThreadPool.QueueUserWorkItem(MyMethod, thread2);

            Console.ReadKey();
        }

        public static void MyMethod(object obj)
        {
            Thread thread = (Thread)obj;
            string message = $"Background: {thread.IsBackground}, Thread Pool: {thread.IsThreadPoolThread}, Thread Priority: {thread.Priority}";
            Console.WriteLine(message);
        }
    }
}
