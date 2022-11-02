
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

namespace Conductor.Models
{
    /// <summary>
    /// User, group or role which is granted/removed access
    /// </summary>
    [DataContract]
        public partial class SubjectRef :  IEquatable<SubjectRef>, IValidatableObject
    {
        /// <summary>
        /// User, role or group
        /// </summary>
        /// <value>User, role or group</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum TypeEnum
        {
            /// <summary>
            /// Enum USER for value: USER
            /// </summary>
            [EnumMember(Value = "USER")]
            USER = 1,
            /// <summary>
            /// Enum ROLE for value: ROLE
            /// </summary>
            [EnumMember(Value = "ROLE")]
            ROLE = 2,
            /// <summary>
            /// Enum GROUP for value: GROUP
            /// </summary>
            [EnumMember(Value = "GROUP")]
            GROUP = 3        }
        /// <summary>
        /// User, role or group
        /// </summary>
        /// <value>User, role or group</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SubjectRef" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="type">User, role or group.</param>
        public SubjectRef(string id = default(string), TypeEnum? type = default(TypeEnum?))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new InvalidDataException("id is a required property for SubjectRef and cannot be null");
            }
            else
            {
                this.Id = id;
            }
            this.Type = type;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SubjectRef {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
            return this.Equals(input as SubjectRef);
        }

        /// <summary>
        /// Returns true if SubjectRef instances are equal
        /// </summary>
        /// <param name="input">Instance of SubjectRef to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SubjectRef input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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
