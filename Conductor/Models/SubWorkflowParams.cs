
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

namespace Conductor.Models
{
    /// <summary>
    /// SubWorkflowParams
    /// </summary>
    [DataContract]
    public partial class SubWorkflowParams : IEquatable<SubWorkflowParams>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubWorkflowParams" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="taskToDomain">taskToDomain.</param>
        /// <param name="version">version.</param>
        /// <param name="workflowDefinition">workflowDefinition.</param>
        public SubWorkflowParams(string name = default(string), Dictionary<string, string> taskToDomain = default(Dictionary<string, string>), int? version = default(int?), WorkflowDef workflowDefinition = default(WorkflowDef))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for SubWorkflowParams and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            this.TaskToDomain = taskToDomain;
            this.Version = version;
            this.WorkflowDefinition = workflowDefinition;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets TaskToDomain
        /// </summary>
        [DataMember(Name = "taskToDomain", EmitDefaultValue = false)]
        public Dictionary<string, string> TaskToDomain { get; set; }

        /// <summary>
        /// Gets or Sets Version
        /// </summary>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public int? Version { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowDefinition
        /// </summary>
        [DataMember(Name = "workflowDefinition", EmitDefaultValue = false)]
        public WorkflowDef WorkflowDefinition { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SubWorkflowParams {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  TaskToDomain: ").Append(TaskToDomain).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  WorkflowDefinition: ").Append(WorkflowDefinition).Append("\n");
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
            return this.Equals(input as SubWorkflowParams);
        }

        /// <summary>
        /// Returns true if SubWorkflowParams instances are equal
        /// </summary>
        /// <param name="input">Instance of SubWorkflowParams to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SubWorkflowParams input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.TaskToDomain == input.TaskToDomain ||
                    this.TaskToDomain != null &&
                    input.TaskToDomain != null &&
                    this.TaskToDomain.SequenceEqual(input.TaskToDomain)
                ) &&
                (
                    this.Version == input.Version ||
                    (this.Version != null &&
                    this.Version.Equals(input.Version))
                ) &&
                (
                    this.WorkflowDefinition == input.WorkflowDefinition ||
                    (this.WorkflowDefinition != null &&
                    this.WorkflowDefinition.Equals(input.WorkflowDefinition))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.TaskToDomain != null)
                    hashCode = hashCode * 59 + this.TaskToDomain.GetHashCode();
                if (this.Version != null)
                    hashCode = hashCode * 59 + this.Version.GetHashCode();
                if (this.WorkflowDefinition != null)
                    hashCode = hashCode * 59 + this.WorkflowDefinition.GetHashCode();
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
