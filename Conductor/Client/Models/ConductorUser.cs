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
    /// ConductorUser
    /// </summary>
    [DataContract]
    public partial class ConductorUser : IEquatable<ConductorUser>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConductorUser" /> class.
        /// </summary>
        /// <param name="applicationUser">applicationUser.</param>
        /// <param name="groups">groups.</param>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="roles">roles.</param>
        /// <param name="uuid">uuid.</param>
        public ConductorUser(bool? applicationUser = default(bool?), List<Group> groups = default(List<Group>), string id = default(string), string name = default(string), List<Role> roles = default(List<Role>), string uuid = default(string))
        {
            this.ApplicationUser = applicationUser;
            this.Groups = groups;
            this.Id = id;
            this.Name = name;
            this.Roles = roles;
            this.Uuid = uuid;
        }

        /// <summary>
        /// Gets or Sets ApplicationUser
        /// </summary>
        [DataMember(Name = "applicationUser", EmitDefaultValue = false)]
        public bool? ApplicationUser { get; set; }

        /// <summary>
        /// Gets or Sets Groups
        /// </summary>
        [DataMember(Name = "groups", EmitDefaultValue = false)]
        public List<Group> Groups { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Roles
        /// </summary>
        [DataMember(Name = "roles", EmitDefaultValue = false)]
        public List<Role> Roles { get; set; }

        /// <summary>
        /// Gets or Sets Uuid
        /// </summary>
        [DataMember(Name = "uuid", EmitDefaultValue = false)]
        public string Uuid { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConductorUser {\n");
            sb.Append("  ApplicationUser: ").Append(ApplicationUser).Append("\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Roles: ").Append(Roles).Append("\n");
            sb.Append("  Uuid: ").Append(Uuid).Append("\n");
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
            return this.Equals(input as ConductorUser);
        }

        /// <summary>
        /// Returns true if ConductorUser instances are equal
        /// </summary>
        /// <param name="input">Instance of ConductorUser to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConductorUser input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ApplicationUser == input.ApplicationUser ||
                    (this.ApplicationUser != null &&
                    this.ApplicationUser.Equals(input.ApplicationUser))
                ) &&
                (
                    this.Groups == input.Groups ||
                    this.Groups != null &&
                    input.Groups != null &&
                    this.Groups.SequenceEqual(input.Groups)
                ) &&
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
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
                ) &&
                (
                    this.Uuid == input.Uuid ||
                    (this.Uuid != null &&
                    this.Uuid.Equals(input.Uuid))
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
                if (this.ApplicationUser != null)
                    hashCode = hashCode * 59 + this.ApplicationUser.GetHashCode();
                if (this.Groups != null)
                    hashCode = hashCode * 59 + this.Groups.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Roles != null)
                    hashCode = hashCode * 59 + this.Roles.GetHashCode();
                if (this.Uuid != null)
                    hashCode = hashCode * 59 + this.Uuid.GetHashCode();
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
