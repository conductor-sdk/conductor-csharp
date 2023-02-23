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
    /// OrkesConductorEnvironment
    /// </summary>
    [DataContract]
    public partial class OrkesConductorEnvironment : IEquatable<OrkesConductorEnvironment>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrkesConductorEnvironment" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="tokenSecret">tokenSecret (required).</param>
        /// <param name="uri">uri (required).</param>
        public OrkesConductorEnvironment(string id = default(string), string tokenSecret = default(string), string uri = default(string))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new InvalidDataException("id is a required property for OrkesConductorEnvironment and cannot be null");
            }
            else
            {
                this.Id = id;
            }
            // to ensure "tokenSecret" is required (not null)
            if (tokenSecret == null)
            {
                throw new InvalidDataException("tokenSecret is a required property for OrkesConductorEnvironment and cannot be null");
            }
            else
            {
                this.TokenSecret = tokenSecret;
            }
            // to ensure "uri" is required (not null)
            if (uri == null)
            {
                throw new InvalidDataException("uri is a required property for OrkesConductorEnvironment and cannot be null");
            }
            else
            {
                this.Uri = uri;
            }
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets TokenSecret
        /// </summary>
        [DataMember(Name = "tokenSecret", EmitDefaultValue = false)]
        public string TokenSecret { get; set; }

        /// <summary>
        /// Gets or Sets Uri
        /// </summary>
        [DataMember(Name = "uri", EmitDefaultValue = false)]
        public string Uri { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrkesConductorEnvironment {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  TokenSecret: ").Append(TokenSecret).Append("\n");
            sb.Append("  Uri: ").Append(Uri).Append("\n");
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
            return this.Equals(input as OrkesConductorEnvironment);
        }

        /// <summary>
        /// Returns true if OrkesConductorEnvironment instances are equal
        /// </summary>
        /// <param name="input">Instance of OrkesConductorEnvironment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrkesConductorEnvironment input)
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
                    this.TokenSecret == input.TokenSecret ||
                    (this.TokenSecret != null &&
                    this.TokenSecret.Equals(input.TokenSecret))
                ) &&
                (
                    this.Uri == input.Uri ||
                    (this.Uri != null &&
                    this.Uri.Equals(input.Uri))
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
                if (this.TokenSecret != null)
                    hashCode = hashCode * 59 + this.TokenSecret.GetHashCode();
                if (this.Uri != null)
                    hashCode = hashCode * 59 + this.Uri.GetHashCode();
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
