using System;

namespace Conductor.Client.Worker
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
    public class InputParam : Attribute
    {
        /// <summary>
        /// Gets or sets the Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the Required
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputParam" /> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="required"></param>
        public InputParam(string value, bool required = false)
        {
            Value = value;
            Required = required;

        }
    }
}
