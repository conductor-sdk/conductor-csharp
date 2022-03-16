/* 
 * 
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

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

namespace Conductor.Client.Models
{
    /// <summary>
    /// ByteString
    /// </summary>
    [DataContract]
    public partial class ByteString :  IEquatable<ByteString>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ByteString" /> class.
        /// </summary>
        /// <param name="validUtf8">validUtf8 (default to false).</param>
        /// <param name="empty">empty (default to false).</param>
        public ByteString(bool? validUtf8 = false, bool? empty = false)
        {
            // use default value if no "validUtf8" provided
            if (validUtf8 == null)
            {
                this.ValidUtf8 = false;
            }
            else
            {
                this.ValidUtf8 = validUtf8;
            }
            // use default value if no "empty" provided
            if (empty == null)
            {
                this.Empty = false;
            }
            else
            {
                this.Empty = empty;
            }
        }
        
        /// <summary>
        /// Gets or Sets ValidUtf8
        /// </summary>
        [DataMember(Name="validUtf8", EmitDefaultValue=false)]
        public bool? ValidUtf8 { get; set; }

        /// <summary>
        /// Gets or Sets Empty
        /// </summary>
        [DataMember(Name="empty", EmitDefaultValue=false)]
        public bool? Empty { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ByteString {\n");
            sb.Append("  ValidUtf8: ").Append(ValidUtf8).Append("\n");
            sb.Append("  Empty: ").Append(Empty).Append("\n");
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
            return this.Equals(input as ByteString);
        }

        /// <summary>
        /// Returns true if ByteString instances are equal
        /// </summary>
        /// <param name="input">Instance of ByteString to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ByteString input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ValidUtf8 == input.ValidUtf8 ||
                    (this.ValidUtf8 != null &&
                    this.ValidUtf8.Equals(input.ValidUtf8))
                ) && 
                (
                    this.Empty == input.Empty ||
                    (this.Empty != null &&
                    this.Empty.Equals(input.Empty))
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
                if (this.ValidUtf8 != null)
                    hashCode = hashCode * 59 + this.ValidUtf8.GetHashCode();
                if (this.Empty != null)
                    hashCode = hashCode * 59 + this.Empty.GetHashCode();
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
