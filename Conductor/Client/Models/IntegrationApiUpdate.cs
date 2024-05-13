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
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Conductor.Client.Models
{
    /// <summary>
    /// IntegrationApiUpdate
    /// </summary>
    [DataContract]
    public partial class IntegrationApiUpdate : IEquatable<IntegrationApiUpdate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationApiUpdate" /> class.
        /// </summary>
        /// <param name="configuration">configuration.</param>
        /// <param name="description">description.</param>
        /// <param name="enabled">enabled.</param>
        public IntegrationApiUpdate(Dictionary<string, Object> configuration = default(Dictionary<string, Object>), string description = default(string), bool? enabled = default(bool?))
        {
            this.Configuration = configuration;
            this.Description = description;
            this.Enabled = enabled;
        }

        /// <summary>
        /// Gets or Sets Configuration
        /// </summary>
        [DataMember(Name = "configuration", EmitDefaultValue = false)]
        public Dictionary<string, Object> Configuration { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Enabled
        /// </summary>
        [DataMember(Name = "enabled", EmitDefaultValue = false)]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IntegrationApiUpdate {\n");
            sb.Append("  Configuration: ").Append(Configuration).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Enabled: ").Append(Enabled).Append("\n");
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
            return this.Equals(input as IntegrationApiUpdate);
        }

        /// <summary>
        /// Returns true if IntegrationApiUpdate instances are equal
        /// </summary>
        /// <param name="input">Instance of IntegrationApiUpdate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IntegrationApiUpdate input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Configuration == input.Configuration ||
                    this.Configuration != null &&
                    input.Configuration != null &&
                    this.Configuration.SequenceEqual(input.Configuration)
                ) &&
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) &&
                (
                    this.Enabled == input.Enabled ||
                    (this.Enabled != null &&
                    this.Enabled.Equals(input.Enabled))
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
                if (this.Configuration != null)
                    hashCode = hashCode * 59 + this.Configuration.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Enabled != null)
                    hashCode = hashCode * 59 + this.Enabled.GetHashCode();
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
