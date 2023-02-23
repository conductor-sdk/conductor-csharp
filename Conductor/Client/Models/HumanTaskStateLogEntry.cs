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
    /// HumanTaskStateLogEntry
    /// </summary>
    [DataContract]
    public partial class HumanTaskStateLogEntry : IEquatable<HumanTaskStateLogEntry>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskStateLogEntry" /> class.
        /// </summary>
        /// <param name="assigned">assigned.</param>
        /// <param name="claimedBy">claimedBy.</param>
        /// <param name="id">id.</param>
        /// <param name="state">state.</param>
        /// <param name="stateEnd">stateEnd.</param>
        /// <param name="stateStart">stateStart.</param>
        /// <param name="taskId">taskId.</param>
        /// <param name="taskRefName">taskRefName.</param>
        /// <param name="workflowId">workflowId.</param>
        /// <param name="workflowName">workflowName.</param>
        public HumanTaskStateLogEntry(List<string> assigned = default(List<string>), string claimedBy = default(string), string id = default(string), string state = default(string), long? stateEnd = default(long?), long? stateStart = default(long?), string taskId = default(string), string taskRefName = default(string), string workflowId = default(string), string workflowName = default(string))
        {
            this.Assigned = assigned;
            this.ClaimedBy = claimedBy;
            this.Id = id;
            this.State = state;
            this.StateEnd = stateEnd;
            this.StateStart = stateStart;
            this.TaskId = taskId;
            this.TaskRefName = taskRefName;
            this.WorkflowId = workflowId;
            this.WorkflowName = workflowName;
        }

        /// <summary>
        /// Gets or Sets Assigned
        /// </summary>
        [DataMember(Name = "assigned", EmitDefaultValue = false)]
        public List<string> Assigned { get; set; }

        /// <summary>
        /// Gets or Sets ClaimedBy
        /// </summary>
        [DataMember(Name = "claimedBy", EmitDefaultValue = false)]
        public string ClaimedBy { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        /// <summary>
        /// Gets or Sets StateEnd
        /// </summary>
        [DataMember(Name = "stateEnd", EmitDefaultValue = false)]
        public long? StateEnd { get; set; }

        /// <summary>
        /// Gets or Sets StateStart
        /// </summary>
        [DataMember(Name = "stateStart", EmitDefaultValue = false)]
        public long? StateStart { get; set; }

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
            sb.Append("class HumanTaskStateLogEntry {\n");
            sb.Append("  Assigned: ").Append(Assigned).Append("\n");
            sb.Append("  ClaimedBy: ").Append(ClaimedBy).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  StateEnd: ").Append(StateEnd).Append("\n");
            sb.Append("  StateStart: ").Append(StateStart).Append("\n");
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
            return this.Equals(input as HumanTaskStateLogEntry);
        }

        /// <summary>
        /// Returns true if HumanTaskStateLogEntry instances are equal
        /// </summary>
        /// <param name="input">Instance of HumanTaskStateLogEntry to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HumanTaskStateLogEntry input)
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
                    this.ClaimedBy == input.ClaimedBy ||
                    (this.ClaimedBy != null &&
                    this.ClaimedBy.Equals(input.ClaimedBy))
                ) &&
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) &&
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
                ) &&
                (
                    this.StateEnd == input.StateEnd ||
                    (this.StateEnd != null &&
                    this.StateEnd.Equals(input.StateEnd))
                ) &&
                (
                    this.StateStart == input.StateStart ||
                    (this.StateStart != null &&
                    this.StateStart.Equals(input.StateStart))
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
                if (this.Assigned != null)
                    hashCode = hashCode * 59 + this.Assigned.GetHashCode();
                if (this.ClaimedBy != null)
                    hashCode = hashCode * 59 + this.ClaimedBy.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.State != null)
                    hashCode = hashCode * 59 + this.State.GetHashCode();
                if (this.StateEnd != null)
                    hashCode = hashCode * 59 + this.StateEnd.GetHashCode();
                if (this.StateStart != null)
                    hashCode = hashCode * 59 + this.StateStart.GetHashCode();
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
