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
    /// IntegrationApi
    /// </summary>
    [DataContract]
    public partial class IntegrationApi : IEquatable<IntegrationApi>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationApi" /> class.
        /// </summary>
        /// <param name="api">api.</param>
        /// <param name="configuration">configuration.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="createdOn">createdOn.</param>
        /// <param name="description">description.</param>
        /// <param name="enabled">enabled.</param>
        /// <param name="integrationName">integrationName.</param>
        /// <param name="tags">tags.</param>
        /// <param name="updatedBy">updatedBy.</param>
        /// <param name="updatedOn">updatedOn.</param>
        public IntegrationApi(string api = default(string), Dictionary<string, Object> configuration = default(Dictionary<string, Object>), string createdBy = default(string), long? createdOn = default(long?), string description = default(string), bool? enabled = default(bool?), string integrationName = default(string), List<Tag> tags = default(List<Tag>), string updatedBy = default(string), long? updatedOn = default(long?))
        {
            this.Api = api;
            this.Configuration = configuration;
            this.CreatedBy = createdBy;
            this.CreatedOn = createdOn;
            this.Description = description;
            this.Enabled = enabled;
            this.IntegrationName = integrationName;
            this.Tags = tags;
            this.UpdatedBy = updatedBy;
            this.UpdatedOn = updatedOn;
        }

        /// <summary>
        /// Gets or Sets Api
        /// </summary>
        [DataMember(Name = "api", EmitDefaultValue = false)]
        public string Api { get; set; }

        /// <summary>
        /// Gets or Sets Configuration
        /// </summary>
        [DataMember(Name = "configuration", EmitDefaultValue = false)]
        public Dictionary<string, Object> Configuration { get; set; }

        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets CreatedOn
        /// </summary>
        [DataMember(Name = "createdOn", EmitDefaultValue = false)]
        public long? CreatedOn { get; set; }

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
        /// Gets or Sets IntegrationName
        /// </summary>
        [DataMember(Name = "integrationName", EmitDefaultValue = false)]
        public string IntegrationName { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [DataMember(Name = "tags", EmitDefaultValue = false)]
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedBy
        /// </summary>
        [DataMember(Name = "updatedBy", EmitDefaultValue = false)]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedOn
        /// </summary>
        [DataMember(Name = "updatedOn", EmitDefaultValue = false)]
        public long? UpdatedOn { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IntegrationApi {\n");
            sb.Append(" Api: ").Append(Api).Append("\n");
            sb.Append(" Configuration: ").Append(Configuration).Append("\n");
            sb.Append(" CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append(" CreatedOn: ").Append(CreatedOn).Append("\n");
            sb.Append(" Description: ").Append(Description).Append("\n");
            sb.Append(" Enabled: ").Append(Enabled).Append("\n");
            sb.Append(" IntegrationName: ").Append(IntegrationName).Append("\n");
            sb.Append(" Tags: ").Append(Tags).Append("\n");
            sb.Append(" UpdatedBy: ").Append(UpdatedBy).Append("\n");
            sb.Append(" UpdatedOn: ").Append(UpdatedOn).Append("\n");
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
            return this.Equals(input as IntegrationApi);
        }

        /// <summary>
        /// Returns true if IntegrationApi instances are equal
        /// </summary>
        /// <param name="input">Instance of IntegrationApi to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IntegrationApi input)
        {
            if (input == null)
                return false;

            return
            (
            this.Api == input.Api ||
            (this.Api != null &&
            this.Api.Equals(input.Api))
            ) &&
            (
            this.Configuration == input.Configuration ||
            this.Configuration != null &&
            input.Configuration != null &&
            this.Configuration.SequenceEqual(input.Configuration)
            ) &&
            (
            this.CreatedBy == input.CreatedBy ||
            (this.CreatedBy != null &&
            this.CreatedBy.Equals(input.CreatedBy))
            ) &&
            (
            this.CreatedOn == input.CreatedOn ||
            (this.CreatedOn != null &&
            this.CreatedOn.Equals(input.CreatedOn))
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
            ) &&
            (
            this.IntegrationName == input.IntegrationName ||
            (this.IntegrationName != null &&
            this.IntegrationName.Equals(input.IntegrationName))
            ) &&
            (
            this.Tags == input.Tags ||
            this.Tags != null &&
            input.Tags != null &&
            this.Tags.SequenceEqual(input.Tags)
            ) &&
            (
            this.UpdatedBy == input.UpdatedBy ||
            (this.UpdatedBy != null &&
            this.UpdatedBy.Equals(input.UpdatedBy))
            ) &&
            (
            this.UpdatedOn == input.UpdatedOn ||
            (this.UpdatedOn != null &&
            this.UpdatedOn.Equals(input.UpdatedOn))
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
                if (this.Api != null)
                    hashCode = hashCode * 59 + this.Api.GetHashCode();
                if (this.Configuration != null)
                    hashCode = hashCode * 59 + this.Configuration.GetHashCode();
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.CreatedOn != null)
                    hashCode = hashCode * 59 + this.CreatedOn.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Enabled != null)
                    hashCode = hashCode * 59 + this.Enabled.GetHashCode();
                if (this.IntegrationName != null)
                    hashCode = hashCode * 59 + this.IntegrationName.GetHashCode();
                if (this.Tags != null)
                    hashCode = hashCode * 59 + this.Tags.GetHashCode();
                if (this.UpdatedBy != null)
                    hashCode = hashCode * 59 + this.UpdatedBy.GetHashCode();
                if (this.UpdatedOn != null)
                    hashCode = hashCode * 59 + this.UpdatedOn.GetHashCode();
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
