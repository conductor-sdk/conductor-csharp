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
    /// MigrationDescriptor
    /// </summary>
    [DataContract]
    public partial class MigrationDescriptor : IEquatable<MigrationDescriptor>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MigrationDescriptor" /> class.
        /// </summary>
        /// <param name="tasks">tasks.</param>
        /// <param name="workflows">workflows.</param>
        public MigrationDescriptor(List<TaskDef> tasks = default(List<TaskDef>), List<WorkflowDef> workflows = default(List<WorkflowDef>))
        {
            this.Tasks = tasks;
            this.Workflows = workflows;
        }

        /// <summary>
        /// Gets or Sets Tasks
        /// </summary>
        [DataMember(Name = "tasks", EmitDefaultValue = false)]
        public List<TaskDef> Tasks { get; set; }

        /// <summary>
        /// Gets or Sets Workflows
        /// </summary>
        [DataMember(Name = "workflows", EmitDefaultValue = false)]
        public List<WorkflowDef> Workflows { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MigrationDescriptor {\n");
            sb.Append("  Tasks: ").Append(Tasks).Append("\n");
            sb.Append("  Workflows: ").Append(Workflows).Append("\n");
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
            return this.Equals(input as MigrationDescriptor);
        }

        /// <summary>
        /// Returns true if MigrationDescriptor instances are equal
        /// </summary>
        /// <param name="input">Instance of MigrationDescriptor to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MigrationDescriptor input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Tasks == input.Tasks ||
                    this.Tasks != null &&
                    input.Tasks != null &&
                    this.Tasks.SequenceEqual(input.Tasks)
                ) &&
                (
                    this.Workflows == input.Workflows ||
                    this.Workflows != null &&
                    input.Workflows != null &&
                    this.Workflows.SequenceEqual(input.Workflows)
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
                if (this.Tasks != null)
                    hashCode = hashCode * 59 + this.Tasks.GetHashCode();
                if (this.Workflows != null)
                    hashCode = hashCode * 59 + this.Workflows.GetHashCode();
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
