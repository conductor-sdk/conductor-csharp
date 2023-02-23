using System.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Conductor.Client.Models
{
    /// <summary>
    /// ListAssignment
    /// </summary>
    [DataContract]
    public partial class ListAssignment : AssignmentPolicy, IEquatable<ListAssignment>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAssignment" /> class.
        /// </summary>
        /// <param name="subjects">subjects.</param>
        public ListAssignment(List<string> subjects = default(List<string>), string type = default(string)) : base(type)
        {
            this.Subjects = subjects;
        }

        /// <summary>
        /// Gets or Sets Subjects
        /// </summary>
        [DataMember(Name = "subjects", EmitDefaultValue = false)]
        public List<string> Subjects { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ListAssignment {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Subjects: ").Append(Subjects).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
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
            return this.Equals(input as ListAssignment);
        }

        /// <summary>
        /// Returns true if ListAssignment instances are equal
        /// </summary>
        /// <param name="input">Instance of ListAssignment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ListAssignment input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                (
                    this.Subjects == input.Subjects ||
                    this.Subjects != null &&
                    input.Subjects != null &&
                    this.Subjects.SequenceEqual(input.Subjects)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = base.GetHashCode();
                if (this.Subjects != null)
                    hashCode = hashCode * 59 + this.Subjects.GetHashCode();
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
