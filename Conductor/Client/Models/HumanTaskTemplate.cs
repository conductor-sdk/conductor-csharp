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
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Conductor.Client.Models
{
    /// <summary>
    /// HumanTaskTemplate
    /// </summary>
    [DataContract]
    public partial class HumanTaskTemplate : IEquatable<HumanTaskTemplate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskTemplate" /> class.
        /// </summary>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="createdOn">createdOn.</param>
        /// <param name="jsonSchema">jsonSchema (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="templateUI">templateUI (required).</param>
        /// <param name="updatedBy">updatedBy.</param>
        /// <param name="updatedOn">updatedOn.</param>
        /// <param name="version">version (required).</param>
        public HumanTaskTemplate(string createdBy = default(string), long? createdOn = default(long?), Dictionary<string, Object> jsonSchema = default(Dictionary<string, Object>), string name = default(string), Dictionary<string, Object> templateUI = default(Dictionary<string, Object>), string updatedBy = default(string), long? updatedOn = default(long?), int? version = default(int?))
        {
            // to ensure "jsonSchema" is required (not null)
            if (jsonSchema == null)
            {
                throw new InvalidDataException("jsonSchema is a required property for HumanTaskTemplate and cannot be null");
            }
            else
            {
                this.JsonSchema = jsonSchema;
            }
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for HumanTaskTemplate and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            // to ensure "templateUI" is required (not null)
            if (templateUI == null)
            {
                throw new InvalidDataException("templateUI is a required property for HumanTaskTemplate and cannot be null");
            }
            else
            {
                this.TemplateUI = templateUI;
            }
            // to ensure "version" is required (not null)
            if (version == null)
            {
                throw new InvalidDataException("version is a required property for HumanTaskTemplate and cannot be null");
            }
            else
            {
                this.Version = version;
            }
            this.CreatedBy = createdBy;
            this.CreatedOn = createdOn;
            this.UpdatedBy = updatedBy;
            this.UpdatedOn = updatedOn;
        }

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
        /// Gets or Sets JsonSchema
        /// </summary>
        [DataMember(Name = "jsonSchema", EmitDefaultValue = false)]
        public Dictionary<string, Object> JsonSchema { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets TemplateUI
        /// </summary>
        [DataMember(Name = "templateUI", EmitDefaultValue = false)]
        public Dictionary<string, Object> TemplateUI { get; set; }

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
        /// Gets or Sets Version
        /// </summary>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public int? Version { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HumanTaskTemplate {\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  CreatedOn: ").Append(CreatedOn).Append("\n");
            sb.Append("  JsonSchema: ").Append(JsonSchema).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  TemplateUI: ").Append(TemplateUI).Append("\n");
            sb.Append("  UpdatedBy: ").Append(UpdatedBy).Append("\n");
            sb.Append("  UpdatedOn: ").Append(UpdatedOn).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
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
            return this.Equals(input as HumanTaskTemplate);
        }

        /// <summary>
        /// Returns true if HumanTaskTemplate instances are equal
        /// </summary>
        /// <param name="input">Instance of HumanTaskTemplate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HumanTaskTemplate input)
        {
            if (input == null)
                return false;

            return
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
                    this.JsonSchema == input.JsonSchema ||
                    this.JsonSchema != null &&
                    input.JsonSchema != null &&
                    this.JsonSchema.SequenceEqual(input.JsonSchema)
                ) &&
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.TemplateUI == input.TemplateUI ||
                    this.TemplateUI != null &&
                    input.TemplateUI != null &&
                    this.TemplateUI.SequenceEqual(input.TemplateUI)
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
                ) &&
                (
                    this.Version == input.Version ||
                    (this.Version != null &&
                    this.Version.Equals(input.Version))
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
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.CreatedOn != null)
                    hashCode = hashCode * 59 + this.CreatedOn.GetHashCode();
                if (this.JsonSchema != null)
                    hashCode = hashCode * 59 + this.JsonSchema.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.TemplateUI != null)
                    hashCode = hashCode * 59 + this.TemplateUI.GetHashCode();
                if (this.UpdatedBy != null)
                    hashCode = hashCode * 59 + this.UpdatedBy.GetHashCode();
                if (this.UpdatedOn != null)
                    hashCode = hashCode * 59 + this.UpdatedOn.GetHashCode();
                if (this.Version != null)
                    hashCode = hashCode * 59 + this.Version.GetHashCode();
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
