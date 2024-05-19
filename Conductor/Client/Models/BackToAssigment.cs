/*
 * Copyright 2024 Conductor Authors.
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 */
using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Conductor.Client.Models
{
    /// <summary>
    /// BackToAssigment
    /// </summary>
    [DataContract]
    public partial class BackToAssigment : TimeoutPolicy, IEquatable<BackToAssigment>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BackToAssigment" /> class.
        /// </summary>
        /// <param name="timeoutSeconds">timeoutSeconds.</param>
        public BackToAssigment(long? timeoutSeconds = default(long?), string type = default(string)) : base(type)
        {
            this.TimeoutSeconds = timeoutSeconds;
        }

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
            sb.Append("class BackToAssigment {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
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
            return this.Equals(input as BackToAssigment);
        }

        /// <summary>
        /// Returns true if BackToAssigment instances are equal
        /// </summary>
        /// <param name="input">Instance of BackToAssigment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BackToAssigment input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
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
