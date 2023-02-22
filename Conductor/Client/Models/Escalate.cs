using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = Conductor.Client.SwaggerDateConverter;

namespace Conductor.Client.Models
{
    /// <summary>
    /// Escalate
    /// </summary>
    [DataContract]
    public partial class Escalate : TimeoutPolicy, IEquatable<Escalate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Escalate" /> class.
        /// </summary>
        /// <param name="subjects">subjects (required).</param>
        /// <param name="timeoutSeconds">timeoutSeconds.</param>
        public Escalate(List<string> subjects = default(List<string>), long? timeoutSeconds = default(long?), string type = default(string)) : base(type)
        {
            // to ensure "subjects" is required (not null)
            if (subjects == null)
            {
                throw new InvalidDataException("subjects is a required property for Escalate and cannot be null");
            }
            else
            {
                this.Subjects = subjects;
            }
            this.TimeoutSeconds = timeoutSeconds;
        }

        /// <summary>
        /// Gets or Sets Subjects
        /// </summary>
        [DataMember(Name = "subjects", EmitDefaultValue = false)]
        public List<string> Subjects { get; set; }

        /// <summary>
        /// Gets or Sets TimeoutSeconds
        /// </summary>
        [DataMember(Name = "timeoutSeconds", EmitDefaultValue = false)]
        public long? TimeoutSeconds { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Escalate {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Subjects: ").Append(Subjects).Append("\n");
            sb.Append("  TimeoutSeconds: ").Append(TimeoutSeconds).Append("\n");
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
            return this.Equals(input as Escalate);
        }

        /// <summary>
        /// Returns true if Escalate instances are equal
        /// </summary>
        /// <param name="input">Instance of Escalate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Escalate input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                (
                    this.Subjects == input.Subjects ||
                    this.Subjects != null &&
                    input.Subjects != null &&
                    this.Subjects.SequenceEqual(input.Subjects)
                ) && base.Equals(input) &&
                (
                    this.TimeoutSeconds == input.TimeoutSeconds ||
                    (this.TimeoutSeconds != null &&
                    this.TimeoutSeconds.Equals(input.TimeoutSeconds))
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
                if (this.TimeoutSeconds != null)
                    hashCode = hashCode * 59 + this.TimeoutSeconds.GetHashCode();
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
