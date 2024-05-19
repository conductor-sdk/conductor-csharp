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
    /// MessageTemplate
    /// </summary>
    [DataContract]
    public partial class MessageTemplate : IEquatable<MessageTemplate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTemplate" /> class.
        /// </summary>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="createdOn">createdOn.</param>
        /// <param name="description">description.</param>
        /// <param name="integrations">integrations.</param>
        /// <param name="name">name.</param>
        /// <param name="tags">tags.</param>
        /// <param name="template">template.</param>
        /// <param name="updatedBy">updatedBy.</param>
        /// <param name="updatedOn">updatedOn.</param>
        /// <param name="variables">variables.</param>
        public MessageTemplate(string createdBy = default(string), long? createdOn = default(long?), string description = default(string), List<string> integrations = default(List<string>), string name = default(string), List<Tag> tags = default(List<Tag>), string template = default(string), string updatedBy = default(string), long? updatedOn = default(long?), List<string> variables = default(List<string>))
        {
            this.CreatedBy = createdBy;
            this.CreatedOn = createdOn;
            this.Description = description;
            this.Integrations = integrations;
            this.Name = name;
            this.Tags = tags;
            this.Template = template;
            this.UpdatedBy = updatedBy;
            this.UpdatedOn = updatedOn;
            this.Variables = variables;
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
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Integrations
        /// </summary>
        [DataMember(Name = "integrations", EmitDefaultValue = false)]
        public List<string> Integrations { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [DataMember(Name = "tags", EmitDefaultValue = false)]
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or Sets Template
        /// </summary>
        [DataMember(Name = "template", EmitDefaultValue = false)]
        public string Template { get; set; }

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
        /// Gets or Sets Variables
        /// </summary>
        [DataMember(Name = "variables", EmitDefaultValue = false)]
        public List<string> Variables { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MessageTemplate {\n");
            sb.Append(" CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append(" CreatedOn: ").Append(CreatedOn).Append("\n");
            sb.Append(" Description: ").Append(Description).Append("\n");
            sb.Append(" Integrations: ").Append(Integrations).Append("\n");
            sb.Append(" Name: ").Append(Name).Append("\n");
            sb.Append(" Tags: ").Append(Tags).Append("\n");
            sb.Append(" Template: ").Append(Template).Append("\n");
            sb.Append(" UpdatedBy: ").Append(UpdatedBy).Append("\n");
            sb.Append(" UpdatedOn: ").Append(UpdatedOn).Append("\n");
            sb.Append(" Variables: ").Append(Variables).Append("\n");
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
            return this.Equals(input as MessageTemplate);
        }

        /// <summary>
        /// Returns true if MessageTemplate instances are equal
        /// </summary>
        /// <param name="input">Instance of MessageTemplate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MessageTemplate input)
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
            this.Description == input.Description ||
            (this.Description != null &&
            this.Description.Equals(input.Description))
            ) &&
            (
            this.Integrations == input.Integrations ||
            this.Integrations != null &&
            input.Integrations != null &&
            this.Integrations.SequenceEqual(input.Integrations)
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
            this.Template == input.Template ||
            (this.Template != null &&
            this.Template.Equals(input.Template))
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
            this.Variables == input.Variables ||
            this.Variables != null &&
            input.Variables != null &&
            this.Variables.SequenceEqual(input.Variables)
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
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Integrations != null)
                    hashCode = hashCode * 59 + this.Integrations.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Tags != null)
                    hashCode = hashCode * 59 + this.Tags.GetHashCode();
                if (this.Template != null)
                    hashCode = hashCode * 59 + this.Template.GetHashCode();
                if (this.UpdatedBy != null)
                    hashCode = hashCode * 59 + this.UpdatedBy.GetHashCode();
                if (this.UpdatedOn != null)
                    hashCode = hashCode * 59 + this.UpdatedOn.GetHashCode();
                if (this.Variables != null)
                    hashCode = hashCode * 59 + this.Variables.GetHashCode();
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
