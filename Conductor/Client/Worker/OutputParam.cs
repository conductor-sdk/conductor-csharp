using System;

namespace Conductor.Client.Worker
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class OutputParam : Attribute
    {
        /// <summary>
        /// Gets or sets the Value
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputParam" /> class.
        /// </summary>
        /// <param name="value"></param>
        public OutputParam(string value)
        {
            Value = value;
        }
    }
}