using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteStateMachineDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var codeLock = new CodeLock();
            codeLock.Post("test");
            codeLock.Post("key");
            codeLock.Post("hello world!");
            codeLock.Post("lock");
            codeLock.Post("test");
            Console.ReadLine();
        }
    }
}
