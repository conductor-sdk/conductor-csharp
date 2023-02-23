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
    /// HumanTaskEntry
    /// </summary>
    [DataContract]
    public partial class HumanTaskEntry : IEquatable<HumanTaskEntry>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskEntry" /> class.
        /// </summary>
        /// <param name="assigned">assigned.</param>
        /// <param name="assignmentPolicy">assignmentPolicy.</param>
        /// <param name="claimedBy">claimedBy.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="createdOn">createdOn.</param>
        /// <param name="state">state.</param>
        /// <param name="taskId">taskId.</param>
        /// <param name="taskRefName">taskRefName.</param>
        /// <param name="templateId">templateId.</param>
        /// <param name="timeoutPolicy">timeoutPolicy.</param>
        /// <param name="workflowId">workflowId.</param>
        /// <param name="workflowName">workflowName.</param>
        public HumanTaskEntry(List<string> assigned = default(List<string>), OneOfHumanTaskEntryAssignmentPolicy assignmentPolicy = default(OneOfHumanTaskEntryAssignmentPolicy), string claimedBy = default(string), string createdBy = default(string), long? createdOn = default(long?), string state = default(string), string taskId = default(string), string taskRefName = default(string), string templateId = default(string), OneOfHumanTaskEntryTimeoutPolicy timeoutPolicy = default(OneOfHumanTaskEntryTimeoutPolicy), string workflowId = default(string), string workflowName = default(string))
        {
            this.Assigned = assigned;
            this.AssignmentPolicy = assignmentPolicy;
            this.ClaimedBy = claimedBy;
            this.CreatedBy = createdBy;
            this.CreatedOn = createdOn;
            this.State = state;
            this.TaskId = taskId;
            this.TaskRefName = taskRefName;
            this.TemplateId = templateId;
            this.TimeoutPolicy = timeoutPolicy;
            this.WorkflowId = workflowId;
            this.WorkflowName = workflowName;
        }

        /// <summary>
        /// Gets or Sets Assigned
        /// </summary>
        [DataMember(Name = "assigned", EmitDefaultValue = false)]
        public List<string> Assigned { get; set; }

        /// <summary>
        /// Gets or Sets AssignmentPolicy
        /// </summary>
        [DataMember(Name = "assignmentPolicy", EmitDefaultValue = false)]
        public OneOfHumanTaskEntryAssignmentPolicy AssignmentPolicy { get; set; }

        /// <summary>
        /// Gets or Sets ClaimedBy
        /// </summary>
        [DataMember(Name = "claimedBy", EmitDefaultValue = false)]
        public string ClaimedBy { get; set; }

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
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        /// <summary>
        /// Gets or Sets TaskId
        /// </summary>
        [DataMember(Name = "taskId", EmitDefaultValue = false)]
        public string TaskId { get; set; }

        /// <summary>
        /// Gets or Sets TaskRefName
        /// </summary>
        [DataMember(Name = "taskRefName", EmitDefaultValue = false)]
        public string TaskRefName { get; set; }

        /// <summary>
        /// Gets or Sets TemplateId
        /// </summary>
        [DataMember(Name = "templateId", EmitDefaultValue = false)]
        public string TemplateId { get; set; }

        /// <summary>
        /// Gets or Sets TimeoutPolicy
        /// </summary>
        [DataMember(Name = "timeoutPolicy", EmitDefaultValue = false)]
        public OneOfHumanTaskEntryTimeoutPolicy TimeoutPolicy { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowId
        /// </summary>
        [DataMember(Name = "workflowId", EmitDefaultValue = false)]
        public string WorkflowId { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowName
        /// </summary>
        [DataMember(Name = "workflowName", EmitDefaultValue = false)]
        public string WorkflowName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HumanTaskEntry {\n");
            sb.Append("  Assigned: ").Append(Assigned).Append("\n");
            sb.Append("  AssignmentPolicy: ").Append(AssignmentPolicy).Append("\n");
            sb.Append("  ClaimedBy: ").Append(ClaimedBy).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  CreatedOn: ").Append(CreatedOn).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  TaskId: ").Append(TaskId).Append("\n");
            sb.Append("  TaskRefName: ").Append(TaskRefName).Append("\n");
            sb.Append("  TemplateId: ").Append(TemplateId).Append("\n");
            sb.Append("  TimeoutPolicy: ").Append(TimeoutPolicy).Append("\n");
            sb.Append("  WorkflowId: ").Append(WorkflowId).Append("\n");
            sb.Append("  WorkflowName: ").Append(WorkflowName).Append("\n");
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
            return this.Equals(input as HumanTaskEntry);
        }

        /// <summary>
        /// Returns true if HumanTaskEntry instances are equal
        /// </summary>
        /// <param name="input">Instance of HumanTaskEntry to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HumanTaskEntry input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Assigned == input.Assigned ||
                    this.Assigned != null &&
                    input.Assigned != null &&
                    this.Assigned.SequenceEqual(input.Assigned)
                ) &&
                (
                    this.AssignmentPolicy == input.AssignmentPolicy ||
                    (this.AssignmentPolicy != null &&
                    this.AssignmentPolicy.Equals(input.AssignmentPolicy))
                ) &&
                (
                    this.ClaimedBy == input.ClaimedBy ||
                    (this.ClaimedBy != null &&
                    this.ClaimedBy.Equals(input.ClaimedBy))
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
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
                ) &&
                (
                    this.TaskId == input.TaskId ||
                    (this.TaskId != null &&
                    this.TaskId.Equals(input.TaskId))
                ) &&
                (
                    this.TaskRefName == input.TaskRefName ||
                    (this.TaskRefName != null &&
                    this.TaskRefName.Equals(input.TaskRefName))
                ) &&
                (
                    this.TemplateId == input.TemplateId ||
                    (this.TemplateId != null &&
                    this.TemplateId.Equals(input.TemplateId))
                ) &&
                (
                    this.TimeoutPolicy == input.TimeoutPolicy ||
                    (this.TimeoutPolicy != null &&
                    this.TimeoutPolicy.Equals(input.TimeoutPolicy))
                ) &&
                (
                    this.WorkflowId == input.WorkflowId ||
                    (this.WorkflowId != null &&
                    this.WorkflowId.Equals(input.WorkflowId))
                ) &&
                (
                    this.WorkflowName == input.WorkflowName ||
                    (this.WorkflowName != null &&
                    this.WorkflowName.Equals(input.WorkflowName))
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
                if (this.Assigned != null)
                    hashCode = hashCode * 59 + this.Assigned.GetHashCode();
                if (this.AssignmentPolicy != null)
                    hashCode = hashCode * 59 + this.AssignmentPolicy.GetHashCode();
                if (this.ClaimedBy != null)
                    hashCode = hashCode * 59 + this.ClaimedBy.GetHashCode();
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.CreatedOn != null)
                    hashCode = hashCode * 59 + this.CreatedOn.GetHashCode();
                if (this.State != null)
                    hashCode = hashCode * 59 + this.State.GetHashCode();
                if (this.TaskId != null)
                    hashCode = hashCode * 59 + this.TaskId.GetHashCode();
                if (this.TaskRefName != null)
                    hashCode = hashCode * 59 + this.TaskRefName.GetHashCode();
                if (this.TemplateId != null)
                    hashCode = hashCode * 59 + this.TemplateId.GetHashCode();
                if (this.TimeoutPolicy != null)
                    hashCode = hashCode * 59 + this.TimeoutPolicy.GetHashCode();
                if (this.WorkflowId != null)
                    hashCode = hashCode * 59 + this.WorkflowId.GetHashCode();
                if (this.WorkflowName != null)
                    hashCode = hashCode * 59 + this.WorkflowName.GetHashCode();
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
