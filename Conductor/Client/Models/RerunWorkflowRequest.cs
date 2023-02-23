
using System.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Conductor.Client.Models
{
    /// <summary>
    /// RerunWorkflowRequest
    /// </summary>
    [DataContract]
    public partial class RerunWorkflowRequest : IEquatable<RerunWorkflowRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RerunWorkflowRequest" /> class.
        /// </summary>
        /// <param name="correlationId">correlationId.</param>
        /// <param name="reRunFromTaskId">reRunFromTaskId.</param>
        /// <param name="reRunFromWorkflowId">reRunFromWorkflowId.</param>
        /// <param name="taskInput">taskInput.</param>
        /// <param name="workflowInput">workflowInput.</param>
        public RerunWorkflowRequest(string correlationId = default(string), string reRunFromTaskId = default(string), string reRunFromWorkflowId = default(string), Dictionary<string, Object> taskInput = default(Dictionary<string, Object>), Dictionary<string, Object> workflowInput = default(Dictionary<string, Object>))
        {
            this.CorrelationId = correlationId;
            this.ReRunFromTaskId = reRunFromTaskId;
            this.ReRunFromWorkflowId = reRunFromWorkflowId;
            this.TaskInput = taskInput;
            this.WorkflowInput = workflowInput;
        }

        /// <summary>
        /// Gets or Sets CorrelationId
        /// </summary>
        [DataMember(Name = "correlationId", EmitDefaultValue = false)]
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets or Sets ReRunFromTaskId
        /// </summary>
        [DataMember(Name = "reRunFromTaskId", EmitDefaultValue = false)]
        public string ReRunFromTaskId { get; set; }

        /// <summary>
        /// Gets or Sets ReRunFromWorkflowId
        /// </summary>
        [DataMember(Name = "reRunFromWorkflowId", EmitDefaultValue = false)]
        public string ReRunFromWorkflowId { get; set; }

        /// <summary>
        /// Gets or Sets TaskInput
        /// </summary>
        [DataMember(Name = "taskInput", EmitDefaultValue = false)]
        public Dictionary<string, Object> TaskInput { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowInput
        /// </summary>
        [DataMember(Name = "workflowInput", EmitDefaultValue = false)]
        public Dictionary<string, Object> WorkflowInput { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RerunWorkflowRequest {\n");
            sb.Append("  CorrelationId: ").Append(CorrelationId).Append("\n");
            sb.Append("  ReRunFromTaskId: ").Append(ReRunFromTaskId).Append("\n");
            sb.Append("  ReRunFromWorkflowId: ").Append(ReRunFromWorkflowId).Append("\n");
            sb.Append("  TaskInput: ").Append(TaskInput).Append("\n");
            sb.Append("  WorkflowInput: ").Append(WorkflowInput).Append("\n");
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
            return this.Equals(input as RerunWorkflowRequest);
        }

        /// <summary>
        /// Returns true if RerunWorkflowRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of RerunWorkflowRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RerunWorkflowRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    this.CorrelationId == input.CorrelationId ||
                    (this.CorrelationId != null &&
                    this.CorrelationId.Equals(input.CorrelationId))
                ) &&
                (
                    this.ReRunFromTaskId == input.ReRunFromTaskId ||
                    (this.ReRunFromTaskId != null &&
                    this.ReRunFromTaskId.Equals(input.ReRunFromTaskId))
                ) &&
                (
                    this.ReRunFromWorkflowId == input.ReRunFromWorkflowId ||
                    (this.ReRunFromWorkflowId != null &&
                    this.ReRunFromWorkflowId.Equals(input.ReRunFromWorkflowId))
                ) &&
                (
                    this.TaskInput == input.TaskInput ||
                    this.TaskInput != null &&
                    input.TaskInput != null &&
                    this.TaskInput.SequenceEqual(input.TaskInput)
                ) &&
                (
                    this.WorkflowInput == input.WorkflowInput ||
                    this.WorkflowInput != null &&
                    input.WorkflowInput != null &&
                    this.WorkflowInput.SequenceEqual(input.WorkflowInput)
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
                if (this.CorrelationId != null)
                    hashCode = hashCode * 59 + this.CorrelationId.GetHashCode();
                if (this.ReRunFromTaskId != null)
                    hashCode = hashCode * 59 + this.ReRunFromTaskId.GetHashCode();
                if (this.ReRunFromWorkflowId != null)
                    hashCode = hashCode * 59 + this.ReRunFromWorkflowId.GetHashCode();
                if (this.TaskInput != null)
                    hashCode = hashCode * 59 + this.TaskInput.GetHashCode();
                if (this.WorkflowInput != null)
                    hashCode = hashCode * 59 + this.WorkflowInput.GetHashCode();
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
