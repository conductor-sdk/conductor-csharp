
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
    /// AuthorizationRequest
    /// </summary>
    [DataContract]
    public partial class AuthorizationRequest : IEquatable<AuthorizationRequest>, IValidatableObject
    {
        /// <summary>
        /// The set of access which is granted or removed
        /// </summary>
        /// <value>The set of access which is granted or removed</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AccessEnum
        {
            /// <summary>
            /// Enum CREATE for value: CREATE
            /// </summary>
            [EnumMember(Value = "CREATE")]
            CREATE = 1,
            /// <summary>
            /// Enum READ for value: READ
            /// </summary>
            [EnumMember(Value = "READ")]
            READ = 2,
            /// <summary>
            /// Enum UPDATE for value: UPDATE
            /// </summary>
            [EnumMember(Value = "UPDATE")]
            UPDATE = 3,
            /// <summary>
            /// Enum DELETE for value: DELETE
            /// </summary>
            [EnumMember(Value = "DELETE")]
            DELETE = 4,
            /// <summary>
            /// Enum EXECUTE for value: EXECUTE
            /// </summary>
            [EnumMember(Value = "EXECUTE")]
            EXECUTE = 5
        }
        /// <summary>
        /// The set of access which is granted or removed
        /// </summary>
        /// <value>The set of access which is granted or removed</value>
        [DataMember(Name = "access", EmitDefaultValue = false)]
        public List<AccessEnum> Access { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationRequest" /> class.
        /// </summary>
        /// <param name="access">The set of access which is granted or removed (required).</param>
        /// <param name="subject">subject (required).</param>
        /// <param name="target">target (required).</param>
        public AuthorizationRequest(List<AccessEnum> access = default(List<AccessEnum>), SubjectRef subject = default(SubjectRef), TargetRef target = default(TargetRef))
        {
            // to ensure "access" is required (not null)
            if (access == null)
            {
                throw new InvalidDataException("access is a required property for AuthorizationRequest and cannot be null");
            }
            else
            {
                this.Access = access;
            }
            // to ensure "subject" is required (not null)
            if (subject == null)
            {
                throw new InvalidDataException("subject is a required property for AuthorizationRequest and cannot be null");
            }
            else
            {
                this.Subject = subject;
            }
            // to ensure "target" is required (not null)
            if (target == null)
            {
                throw new InvalidDataException("target is a required property for AuthorizationRequest and cannot be null");
            }
            else
            {
                this.Target = target;
            }
        }


        /// <summary>
        /// Gets or Sets Subject
        /// </summary>
        [DataMember(Name = "subject", EmitDefaultValue = false)]
        public SubjectRef Subject { get; set; }

        /// <summary>
        /// Gets or Sets Target
        /// </summary>
        [DataMember(Name = "target", EmitDefaultValue = false)]
        public TargetRef Target { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AuthorizationRequest {\n");
            sb.Append("  Access: ").Append(Access).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  Target: ").Append(Target).Append("\n");
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
            return this.Equals(input as AuthorizationRequest);
        }

        /// <summary>
        /// Returns true if AuthorizationRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthorizationRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthorizationRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Access == input.Access ||
                    this.Access != null &&
                    input.Access != null &&
                    this.Access.SequenceEqual(input.Access)
                ) &&
                (
                    this.Subject == input.Subject ||
                    (this.Subject != null &&
                    this.Subject.Equals(input.Subject))
                ) &&
                (
                    this.Target == input.Target ||
                    (this.Target != null &&
                    this.Target.Equals(input.Target))
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
                if (this.Access != null)
                    hashCode = hashCode * 59 + this.Access.GetHashCode();
                if (this.Subject != null)
                    hashCode = hashCode * 59 + this.Subject.GetHashCode();
                if (this.Target != null)
                    hashCode = hashCode * 59 + this.Target.GetHashCode();
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
