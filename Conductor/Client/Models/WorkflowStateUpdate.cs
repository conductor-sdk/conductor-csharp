using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Conductor.Client.Models
{
    /// <summary>
    /// WorkflowStateUpdate
    /// </summary>
    [DataContract]
        public partial class WorkflowStateUpdate :  IEquatable<WorkflowStateUpdate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowStateUpdate" /> class.
        /// </summary>
        /// <param name="taskReferenceName">taskReferenceName.</param>
        /// <param name="taskResult">taskResult.</param>
        /// <param name="variables">variables.</param>
        public WorkflowStateUpdate(string taskReferenceName = default(string), TaskResult taskResult = default(TaskResult), Dictionary<string, Object> variables = default(Dictionary<string, Object>))
        {
            this.TaskReferenceName = taskReferenceName;
            this.TaskResult = taskResult;
            this.Variables = variables;
        }
        
        /// <summary>
        /// Gets or Sets TaskReferenceName
        /// </summary>
        [DataMember(Name="taskReferenceName", EmitDefaultValue=false)]
        public string TaskReferenceName { get; set; }

        /// <summary>
        /// Gets or Sets TaskResult
        /// </summary>
        [DataMember(Name="taskResult", EmitDefaultValue=false)]
        public TaskResult TaskResult { get; set; }

        /// <summary>
        /// Gets or Sets Variables
        /// </summary>
        [DataMember(Name="variables", EmitDefaultValue=false)]
        public Dictionary<string, Object> Variables { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WorkflowStateUpdate {\n");
            sb.Append("  TaskReferenceName: ").Append(TaskReferenceName).Append("\n");
            sb.Append("  TaskResult: ").Append(TaskResult).Append("\n");
            sb.Append("  Variables: ").Append(Variables).Append("\n");
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
            return this.Equals(input as WorkflowStateUpdate);
        }

        /// <summary>
        /// Returns true if WorkflowStateUpdate instances are equal
        /// </summary>
        /// <param name="input">Instance of WorkflowStateUpdate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WorkflowStateUpdate input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.TaskReferenceName == input.TaskReferenceName ||
                    (this.TaskReferenceName != null &&
                    this.TaskReferenceName.Equals(input.TaskReferenceName))
                ) && 
                (
                    this.TaskResult == input.TaskResult ||
                    (this.TaskResult != null &&
                    this.TaskResult.Equals(input.TaskResult))
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
                if (this.TaskReferenceName != null)
                    hashCode = hashCode * 59 + this.TaskReferenceName.GetHashCode();
                if (this.TaskResult != null)
                    hashCode = hashCode * 59 + this.TaskResult.GetHashCode();
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
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}