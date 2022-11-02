
using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Conductor.Models
{
    /// <summary>
    /// The object over which access is being granted or removed
    /// </summary>
    [DataContract]
    public partial class Token : IEquatable<Token>, IValidatableObject
    {

        /// <summary>
        /// Gets or Sets token
        /// </summary>
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string _token { get; set; }

        public Token(string token = default(string))
        {
            _token = token;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Token {\n");
            sb.Append("  token: ").Append(_token).Append("\n");
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
            return this.Equals(input as Token);
        }

        /// <summary>
        /// Returns true if Token instances are equal
        /// </summary>
        /// <param name="input">Instance of Token to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Token input)
        {
            if (input == null)
                return false;

            return
                (
                    _token == input._token ||
                    _token.Equals(input._token)
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
                hashCode = hashCode * 59 + this._token.GetHashCode();
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
