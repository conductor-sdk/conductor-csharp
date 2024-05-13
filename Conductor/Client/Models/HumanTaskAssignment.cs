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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Conductor.Client.Models
{
    /// <summary>
    /// HumanTaskAssignment
    /// </summary>
    [DataContract]
    public partial class HumanTaskAssignment : IEquatable<HumanTaskAssignment>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskAssignment" /> class.
        /// </summary>
        /// <param name="assignee">assignee.</param>
        /// <param name="slaMinutes">slaMinutes.</param>
        public HumanTaskAssignment(HumanTaskUser assignee = default(HumanTaskUser), long? slaMinutes = default(long?))
        {
            this.Assignee = assignee;
            this.SlaMinutes = slaMinutes;
        }

        /// <summary>
        /// Gets or Sets Assignee
        /// </summary>
        [DataMember(Name = "assignee", EmitDefaultValue = false)]
        public HumanTaskUser Assignee { get; set; }

        /// <summary>
        /// Gets or Sets SlaMinutes
        /// </summary>
        [DataMember(Name = "slaMinutes", EmitDefaultValue = false)]
        public long? SlaMinutes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HumanTaskAssignment {\n");
            sb.Append("  Assignee: ").Append(Assignee).Append("\n");
            sb.Append("  SlaMinutes: ").Append(SlaMinutes).Append("\n");
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
            return this.Equals(input as HumanTaskAssignment);
        }

        /// <summary>
        /// Returns true if HumanTaskAssignment instances are equal
        /// </summary>
        /// <param name="input">Instance of HumanTaskAssignment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HumanTaskAssignment input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Assignee == input.Assignee ||
                    (this.Assignee != null &&
                    this.Assignee.Equals(input.Assignee))
                ) &&
                (
                    this.SlaMinutes == input.SlaMinutes ||
                    (this.SlaMinutes != null &&
                    this.SlaMinutes.Equals(input.SlaMinutes))
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
                if (this.Assignee != null)
                    hashCode = hashCode * 59 + this.Assignee.GetHashCode();
                if (this.SlaMinutes != null)
                    hashCode = hashCode * 59 + this.SlaMinutes.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
