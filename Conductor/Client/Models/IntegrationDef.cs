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
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Conductor.Client.Models
{
    /// <summary>
    /// IntegrationDef
    /// </summary>
    [DataContract]
    public partial class IntegrationDef : IEquatable<IntegrationDef>, IValidatableObject
    {
        /// <summary>
        /// Defines Category
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CategoryEnum
        {
            /// <summary>
            /// Enum API for value: API
            /// </summary>
            [EnumMember(Value = "API")]
            API = 1,
            /// <summary>
            /// Enum AIMODEL for value: AI_MODEL
            /// </summary>
            [EnumMember(Value = "AI_MODEL")]
            AIMODEL = 2,
            /// <summary>
            /// Enum VECTORDB for value: VECTOR_DB
            /// </summary>
            [EnumMember(Value = "VECTOR_DB")]
            VECTORDB = 3,
            /// <summary>
            /// Enum RELATIONALDB for value: RELATIONAL_DB
            /// </summary>
            [EnumMember(Value = "RELATIONAL_DB")]
            RELATIONALDB = 4,
            /// <summary>
            /// Enum MESSAGEBROKER for value: MESSAGE_BROKER
            /// </summary>
            [EnumMember(Value = "MESSAGE_BROKER")]
            MESSAGEBROKER = 5
        }
        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        [DataMember(Name = "category", EmitDefaultValue = false)]
        public CategoryEnum? Category { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationDef" /> class.
        /// </summary>
        /// <param name="category">category.</param>
        /// <param name="categoryLabel">categoryLabel.</param>
        /// <param name="configuration">configuration.</param>
        /// <param name="description">description.</param>
        /// <param name="enabled">enabled.</param>
        /// <param name="iconName">iconName.</param>
        /// <param name="name">name.</param>
        /// <param name="tags">tags.</param>
        /// <param name="type">type.</param>
        public IntegrationDef(CategoryEnum? category = default(CategoryEnum?), string categoryLabel = default(string), List<IntegrationDefFormField> configuration = default(List<IntegrationDefFormField>), string description = default(string), bool? enabled = default(bool?), string iconName = default(string), string name = default(string), List<string> tags = default(List<string>), string type = default(string))
        {
            this.Category = category;
            this.CategoryLabel = categoryLabel;
            this.Configuration = configuration;
            this.Description = description;
            this.Enabled = enabled;
            this.IconName = iconName;
            this.Name = name;
            this.Tags = tags;
            this.Type = type;
        }


        /// <summary>
        /// Gets or Sets CategoryLabel
        /// </summary>
        [DataMember(Name = "categoryLabel", EmitDefaultValue = false)]
        public string CategoryLabel { get; set; }

        /// <summary>
        /// Gets or Sets Configuration
        /// </summary>
        [DataMember(Name = "configuration", EmitDefaultValue = false)]
        public List<IntegrationDefFormField> Configuration { get; set; }

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
        /// Gets or Sets IconName
        /// </summary>
        [DataMember(Name = "iconName", EmitDefaultValue = false)]
        public string IconName { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [DataMember(Name = "tags", EmitDefaultValue = false)]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IntegrationDef {\n");
            sb.Append(" Category: ").Append(Category).Append("\n");
            sb.Append(" CategoryLabel: ").Append(CategoryLabel).Append("\n");
            sb.Append(" Configuration: ").Append(Configuration).Append("\n");
            sb.Append(" Description: ").Append(Description).Append("\n");
            sb.Append(" Enabled: ").Append(Enabled).Append("\n");
            sb.Append(" IconName: ").Append(IconName).Append("\n");
            sb.Append(" Name: ").Append(Name).Append("\n");
            sb.Append(" Tags: ").Append(Tags).Append("\n");
            sb.Append(" Type: ").Append(Type).Append("\n");
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
            return this.Equals(input as IntegrationDef);
        }

        /// <summary>
        /// Returns true if IntegrationDef instances are equal
        /// </summary>
        /// <param name="input">Instance of IntegrationDef to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IntegrationDef input)
        {
            if (input == null)
                return false;

            return
            (
            this.Category == input.Category ||
            (this.Category != null &&
            this.Category.Equals(input.Category))
            ) &&
            (
            this.CategoryLabel == input.CategoryLabel ||
            (this.CategoryLabel != null &&
            this.CategoryLabel.Equals(input.CategoryLabel))
            ) &&
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
            ) &&
            (
            this.IconName == input.IconName ||
            (this.IconName != null &&
            this.IconName.Equals(input.IconName))
            ) &&
            (
            this.Name == input.Name ||
            (this.Name != null &&
            this.Name.Equals(input.Name))
            ) &&
            (
            this.Tags == input.Tags ||
            this.Tags != null &&
            input.Tags != null &&
            this.Tags.SequenceEqual(input.Tags)
            ) &&
            (
            this.Type == input.Type ||
            (this.Type != null &&
            this.Type.Equals(input.Type))
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
                if (this.Category != null)
                    hashCode = hashCode * 59 + this.Category.GetHashCode();
                if (this.CategoryLabel != null)
                    hashCode = hashCode * 59 + this.CategoryLabel.GetHashCode();
                if (this.Configuration != null)
                    hashCode = hashCode * 59 + this.Configuration.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Enabled != null)
                    hashCode = hashCode * 59 + this.Enabled.GetHashCode();
                if (this.IconName != null)
                    hashCode = hashCode * 59 + this.IconName.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Tags != null)
                    hashCode = hashCode * 59 + this.Tags.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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
