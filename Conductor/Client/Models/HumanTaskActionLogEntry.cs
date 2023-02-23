using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Conductor.Client.Models
{
    /// <summary>
    /// HumanTaskActionLogEntry
    /// </summary>
    [DataContract]
    public partial class HumanTaskActionLogEntry : IEquatable<HumanTaskActionLogEntry>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskActionLogEntry" /> class.
        /// </summary>
        /// <param name="action">action.</param>
        /// <param name="actionTime">actionTime.</param>
        /// <param name="cause">cause.</param>
        /// <param name="id">id.</param>
        /// <param name="taskId">taskId.</param>
        /// <param name="taskRefName">taskRefName.</param>
        /// <param name="workflowId">workflowId.</param>
        /// <param name="workflowName">workflowName.</param>
        public HumanTaskActionLogEntry(string action = default(string), long? actionTime = default(long?), string cause = default(string), string id = default(string), string taskId = default(string), string taskRefName = default(string), string workflowId = default(string), string workflowName = default(string))
        {
            this.Action = action;
            this.ActionTime = actionTime;
            this.Cause = cause;
            this.Id = id;
            this.TaskId = taskId;
            this.TaskRefName = taskRefName;
            this.WorkflowId = workflowId;
            this.WorkflowName = workflowName;
        }

        /// <summary>
        /// Gets or Sets Action
        /// </summary>
        [DataMember(Name = "action", EmitDefaultValue = false)]
        public string Action { get; set; }

        /// <summary>
        /// Gets or Sets ActionTime
        /// </summary>
        [DataMember(Name = "actionTime", EmitDefaultValue = false)]
        public long? ActionTime { get; set; }

        /// <summary>
        /// Gets or Sets Cause
        /// </summary>
        [DataMember(Name = "cause", EmitDefaultValue = false)]
        public string Cause { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

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
            sb.Append("class HumanTaskActionLogEntry {\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
            sb.Append("  ActionTime: ").Append(ActionTime).Append("\n");
            sb.Append("  Cause: ").Append(Cause).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  TaskId: ").Append(TaskId).Append("\n");
            sb.Append("  TaskRefName: ").Append(TaskRefName).Append("\n");
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
            return this.Equals(input as HumanTaskActionLogEntry);
        }

        /// <summary>
        /// Returns true if HumanTaskActionLogEntry instances are equal
        /// </summary>
        /// <param name="input">Instance of HumanTaskActionLogEntry to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HumanTaskActionLogEntry input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Action == input.Action ||
                    (this.Action != null &&
                    this.Action.Equals(input.Action))
                ) &&
                (
                    this.ActionTime == input.ActionTime ||
                    (this.ActionTime != null &&
                    this.ActionTime.Equals(input.ActionTime))
                ) &&
                (
                    this.Cause == input.Cause ||
                    (this.Cause != null &&
                    this.Cause.Equals(input.Cause))
                ) &&
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
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
                if (this.Action != null)
                    hashCode = hashCode * 59 + this.Action.GetHashCode();
                if (this.ActionTime != null)
                    hashCode = hashCode * 59 + this.ActionTime.GetHashCode();
                if (this.Cause != null)
                    hashCode = hashCode * 59 + this.Cause.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.TaskId != null)
                    hashCode = hashCode * 59 + this.TaskId.GetHashCode();
                if (this.TaskRefName != null)
                    hashCode = hashCode * 59 + this.TaskRefName.GetHashCode();
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
