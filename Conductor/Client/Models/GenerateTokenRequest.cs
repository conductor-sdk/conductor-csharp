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
    /// GenerateTokenRequest
    /// </summary>
    [DataContract]
    public partial class GenerateTokenRequest : IEquatable<GenerateTokenRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateTokenRequest" /> class.
        /// </summary>
        /// <param name="keyId">keyId (required).</param>
        /// <param name="keySecret">keySecret (required).</param>
        public GenerateTokenRequest(string keyId = default(string), string keySecret = default(string))
        {
            // to ensure "keyId" is required (not null)
            if (keyId == null)
            {
                throw new InvalidDataException("keyId is a required property for GenerateTokenRequest and cannot be null");
            }
            else
            {
                this.KeyId = keyId;
            }
            // to ensure "keySecret" is required (not null)
            if (keySecret == null)
            {
                throw new InvalidDataException("keySecret is a required property for GenerateTokenRequest and cannot be null");
            }
            else
            {
                this.KeySecret = keySecret;
            }
        }

        /// <summary>
        /// Gets or Sets KeyId
        /// </summary>
        [DataMember(Name = "keyId", EmitDefaultValue = false)]
        public string KeyId { get; set; }

        /// <summary>
        /// Gets or Sets KeySecret
        /// </summary>
        [DataMember(Name = "keySecret", EmitDefaultValue = false)]
        public string KeySecret { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GenerateTokenRequest {\n");
            sb.Append("  KeyId: ").Append(KeyId).Append("\n");
            sb.Append("  KeySecret: ").Append(KeySecret).Append("\n");
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
            return this.Equals(input as GenerateTokenRequest);
        }

        /// <summary>
        /// Returns true if GenerateTokenRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of GenerateTokenRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GenerateTokenRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    this.KeyId == input.KeyId ||
                    (this.KeyId != null &&
                    this.KeyId.Equals(input.KeyId))
                ) &&
                (
                    this.KeySecret == input.KeySecret ||
                    (this.KeySecret != null &&
                    this.KeySecret.Equals(input.KeySecret))
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
                if (this.KeyId != null)
                    hashCode = hashCode * 59 + this.KeyId.GetHashCode();
                if (this.KeySecret != null)
                    hashCode = hashCode * 59 + this.KeySecret.GetHashCode();
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
