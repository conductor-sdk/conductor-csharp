using System.IO;
using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Conductor.Client.Models
{
    /// <summary>
    /// CreateOrUpdateApplicationRequest
    /// </summary>
    [DataContract]
    public partial class CreateOrUpdateApplicationRequest : IEquatable<CreateOrUpdateApplicationRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrUpdateApplicationRequest" /> class.
        /// </summary>
        /// <param name="name">Application&#x27;s name e.g.: Payment Processors (required).</param>
        public CreateOrUpdateApplicationRequest(string name = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for CreateOrUpdateApplicationRequest and cannot be null");
            }
            else
            {
                this.Name = name;
            }
        }

        /// <summary>
        /// Application&#x27;s name e.g.: Payment Processors
        /// </summary>
        /// <value>Application&#x27;s name e.g.: Payment Processors</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CreateOrUpdateApplicationRequest {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
            return this.Equals(input as CreateOrUpdateApplicationRequest);
        }

        /// <summary>
        /// Returns true if CreateOrUpdateApplicationRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CreateOrUpdateApplicationRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateOrUpdateApplicationRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
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
                int hashCode = 41;
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
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
