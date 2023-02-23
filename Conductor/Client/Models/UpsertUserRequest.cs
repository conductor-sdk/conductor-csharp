using System.Linq;
using System.IO;
using Newtonsoft.Json.Converters;
using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Conductor.Client.Models
{
    /// <summary>
    /// UpsertUserRequest
    /// </summary>
    [DataContract]
    public partial class UpsertUserRequest : IEquatable<UpsertUserRequest>, IValidatableObject
    {
        /// <summary>
        /// Defines Roles
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RolesEnum
        {
            /// <summary>
            /// Enum ADMIN for value: ADMIN
            /// </summary>
            [EnumMember(Value = "ADMIN")]
            ADMIN = 1,
            /// <summary>
            /// Enum USER for value: USER
            /// </summary>
            [EnumMember(Value = "USER")]
            USER = 2,
            /// <summary>
            /// Enum WORKER for value: WORKER
            /// </summary>
            [EnumMember(Value = "WORKER")]
            WORKER = 3,
            /// <summary>
            /// Enum METADATAMANAGER for value: METADATA_MANAGER
            /// </summary>
            [EnumMember(Value = "METADATA_MANAGER")]
            METADATAMANAGER = 4,
            /// <summary>
            /// Enum WORKFLOWMANAGER for value: WORKFLOW_MANAGER
            /// </summary>
            [EnumMember(Value = "WORKFLOW_MANAGER")]
            WORKFLOWMANAGER = 5
        }
        /// <summary>
        /// Gets or Sets Roles
        /// </summary>
        [DataMember(Name = "roles", EmitDefaultValue = false)]
        public List<RolesEnum> Roles { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpsertUserRequest" /> class.
        /// </summary>
        /// <param name="groups">Ids of the groups this user belongs to.</param>
        /// <param name="name">User&#x27;s full name (required).</param>
        /// <param name="roles">roles.</param>
        public UpsertUserRequest(List<string> groups = default(List<string>), string name = default(string), List<RolesEnum> roles = default(List<RolesEnum>))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for UpsertUserRequest and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            this.Groups = groups;
            this.Roles = roles;
        }

        /// <summary>
        /// Ids of the groups this user belongs to
        /// </summary>
        /// <value>Ids of the groups this user belongs to</value>
        [DataMember(Name = "groups", EmitDefaultValue = false)]
        public List<string> Groups { get; set; }

        /// <summary>
        /// User&#x27;s full name
        /// </summary>
        /// <value>User&#x27;s full name</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpsertUserRequest {\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Roles: ").Append(Roles).Append("\n");
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
            return this.Equals(input as UpsertUserRequest);
        }

        /// <summary>
        /// Returns true if UpsertUserRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of UpsertUserRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpsertUserRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Groups == input.Groups ||
                    this.Groups != null &&
                    input.Groups != null &&
                    this.Groups.SequenceEqual(input.Groups)
                ) &&
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.Roles == input.Roles ||
                    this.Roles != null &&
                    input.Roles != null &&
                    this.Roles.SequenceEqual(input.Roles)
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
                if (this.Groups != null)
                    hashCode = hashCode * 59 + this.Groups.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Roles != null)
                    hashCode = hashCode * 59 + this.Roles.GetHashCode();
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
