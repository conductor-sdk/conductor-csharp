using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Conductor.Client.Models
{
    /// <summary>
    /// OneOfHumanTaskEntryAssignmentPolicy
    /// </summary>
    [DataContract]
    public partial class OneOfHumanTaskEntryAssignmentPolicy : IEquatable<OneOfHumanTaskEntryAssignmentPolicy>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneOfHumanTaskEntryAssignmentPolicy" /> class.
        /// </summary>
        public OneOfHumanTaskEntryAssignmentPolicy()
        {
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OneOfHumanTaskEntryAssignmentPolicy {\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as OneOfHumanTaskEntryAssignmentPolicy);
        }

        /// <summary>
        /// Returns true if OneOfHumanTaskEntryAssignmentPolicy instances are equal
        /// </summary>
        /// <param name="input">Instance of OneOfHumanTaskEntryAssignmentPolicy to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OneOfHumanTaskEntryAssignmentPolicy input)
        {
            if (input == null)
                return false;

            return false;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
