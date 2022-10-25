using System;

namespace Conductor.Exceptions
{
    public class WorkerNotFoundException : Exception
    {
        public WorkerNotFoundException()
        {
        }

        public WorkerNotFoundException(string message)
            : base(message)
        {
        }

        public WorkerNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
