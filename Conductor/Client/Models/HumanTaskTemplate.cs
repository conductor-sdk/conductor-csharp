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
    /// HumanTaskTemplate
    /// </summary>
    [DataContract]
    public partial class HumanTaskTemplate : IEquatable<HumanTaskTemplate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskTemplate" /> class.
        /// </summary>
        /// <param name="jsonSchema">jsonSchema (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="templateUI">templateUI (required).</param>
        /// <param name="version">version.</param>
        public HumanTaskTemplate(Dictionary<string, Object> jsonSchema = default(Dictionary<string, Object>), string name = default(string), Dictionary<string, Object> templateUI = default(Dictionary<string, Object>), int? version = default(int?))
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
            this.Version = version;
        }

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
            sb.Append("  JsonSchema: ").Append(JsonSchema).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  TemplateUI: ").Append(TemplateUI).Append("\n");
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
                if (this.JsonSchema != null)
                    hashCode = hashCode * 59 + this.JsonSchema.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.TemplateUI != null)
                    hashCode = hashCode * 59 + this.TemplateUI.GetHashCode();
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
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
