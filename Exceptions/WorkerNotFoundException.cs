using System;
using System.Collections.Generic;
using System.Text;

namespace Conductor.Client.Exceptions
{
    public  class WorkerNotFoundException : Exception
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
