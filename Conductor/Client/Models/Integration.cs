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
    /// Integration
    /// </summary>
    [DataContract]
    public partial class Integration : IEquatable<Integration>, IValidatableObject
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
        /// Initializes a new instance of the <see cref="Integration" /> class.
        /// </summary>
        /// <param name="category">category.</param>
        /// <param name="configuration">configuration.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="createdOn">createdOn.</param>
        /// <param name="description">description.</param>
        /// <param name="enabled">enabled.</param>
        /// <param name="modelsCount">modelsCount.</param>
        /// <param name="name">name.</param>
        /// <param name="tags">tags.</param>
        /// <param name="type">type.</param>
        /// <param name="updatedBy">updatedBy.</param>
        /// <param name="updatedOn">updatedOn.</param>
        public Integration(CategoryEnum? category = default(CategoryEnum?), Dictionary<string, Object> configuration = default(Dictionary<string, Object>), string createdBy = default(string), long? createdOn = default(long?), string description = default(string), bool? enabled = default(bool?), long? modelsCount = default(long?), string name = default(string), List<Tag> tags = default(List<Tag>), string type = default(string), string updatedBy = default(string), long? updatedOn = default(long?))
        {
            this.Category = category;
            this.Configuration = configuration;
            this.CreatedBy = createdBy;
            this.CreatedOn = createdOn;
            this.Description = description;
            this.Enabled = enabled;
            this.ModelsCount = modelsCount;
            this.Name = name;
            this.Tags = tags;
            this.Type = type;
            this.UpdatedBy = updatedBy;
            this.UpdatedOn = updatedOn;
        }


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
        /// Gets or Sets ModelsCount
        /// </summary>
        [DataMember(Name = "modelsCount", EmitDefaultValue = false)]
        public long? ModelsCount { get; set; }

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
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

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
            sb.Append("class Integration {\n");
            sb.Append(" Category: ").Append(Category).Append("\n");
            sb.Append(" Configuration: ").Append(Configuration).Append("\n");
            sb.Append(" CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append(" CreatedOn: ").Append(CreatedOn).Append("\n");
            sb.Append(" Description: ").Append(Description).Append("\n");
            sb.Append(" Enabled: ").Append(Enabled).Append("\n");
            sb.Append(" ModelsCount: ").Append(ModelsCount).Append("\n");
            sb.Append(" Name: ").Append(Name).Append("\n");
            sb.Append(" Tags: ").Append(Tags).Append("\n");
            sb.Append(" Type: ").Append(Type).Append("\n");
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
            return this.Equals(input as Integration);
        }

        /// <summary>
        /// Returns true if Integration instances are equal
        /// </summary>
        /// <param name="input">Instance of Integration to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Integration input)
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
            this.ModelsCount == input.ModelsCount ||
            (this.ModelsCount != null &&
            this.ModelsCount.Equals(input.ModelsCount))
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
                if (this.Category != null)
                    hashCode = hashCode * 59 + this.Category.GetHashCode();
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
                if (this.ModelsCount != null)
                    hashCode = hashCode * 59 + this.ModelsCount.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Tags != null)
                    hashCode = hashCode * 59 + this.Tags.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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
