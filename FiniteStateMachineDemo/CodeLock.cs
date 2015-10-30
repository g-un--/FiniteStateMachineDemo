using ActionAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteStateMachineDemo
{
    public delegate Handle<T> Handle<T>(string message);

    public class CodeLock
    {
        private Handle<string> state;
        private Agent<string> agent;

        public CodeLock()
        {
            state = Locked();
            agent = new Agent<string>(message =>
            {
                state = state(message);
            });
        }

        public void Post(string message)
        {
            agent.Post(message);
        }

        Handle<string> Unlocked()
        {
            return new Handle<string>(message =>
            {
                if (message == "lock")
                    return Locked();
                else
                {
                    Console.WriteLine(message);
                    return Unlocked();
                }
            });
        }

        Handle<string> Locked()
        {
            return new Handle<string>(message =>
            {
                if (message == "key")
                    return Unlocked();
                else
                {
                    Console.WriteLine("Nice try!");
                    return Locked();
                }
            });
        }
    }
}
