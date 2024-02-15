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
    /// HumanTaskEntry
    /// </summary>
    [DataContract]
    public partial class HumanTaskEntry : IEquatable<HumanTaskEntry>, IValidatableObject
    {
        /// <summary>
        /// Defines State
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StateEnum
        {
            /// <summary>
            /// Enum PENDING for value: PENDING
            /// </summary>
            [EnumMember(Value = "PENDING")]
            PENDING = 1,
            /// <summary>
            /// Enum ASSIGNED for value: ASSIGNED
            /// </summary>
            [EnumMember(Value = "ASSIGNED")]
            ASSIGNED = 2,
            /// <summary>
            /// Enum INPROGRESS for value: IN_PROGRESS
            /// </summary>
            [EnumMember(Value = "IN_PROGRESS")]
            INPROGRESS = 3,
            /// <summary>
            /// Enum COMPLETED for value: COMPLETED
            /// </summary>
            [EnumMember(Value = "COMPLETED")]
            COMPLETED = 4,
            /// <summary>
            /// Enum TIMEDOUT for value: TIMED_OUT
            /// </summary>
            [EnumMember(Value = "TIMED_OUT")]
            TIMEDOUT = 5,
            /// <summary>
            /// Enum DELETED for value: DELETED
            /// </summary>
            [EnumMember(Value = "DELETED")]
            DELETED = 6
        }
        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public StateEnum? State { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskEntry" /> class.
        /// </summary>
        /// <param name="assignee">assignee.</param>
        /// <param name="claimant">claimant.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="createdOn">createdOn.</param>
        /// <param name="definitionName">definitionName.</param>
        /// <param name="displayName">displayName.</param>
        /// <param name="humanTaskDef">humanTaskDef.</param>
        /// <param name="input">input.</param>
        /// <param name="output">output.</param>
        /// <param name="state">state.</param>
        /// <param name="taskId">taskId.</param>
        /// <param name="taskRefName">taskRefName.</param>
        /// <param name="updatedBy">updatedBy.</param>
        /// <param name="updatedOn">updatedOn.</param>
        /// <param name="workflowId">workflowId.</param>
        /// <param name="workflowName">workflowName.</param>
        public HumanTaskEntry(HumanTaskUser assignee = default(HumanTaskUser), HumanTaskUser claimant = default(HumanTaskUser), string createdBy = default(string), long? createdOn = default(long?), string definitionName = default(string), string displayName = default(string), HumanTaskDefinition humanTaskDef = default(HumanTaskDefinition), Dictionary<string, Object> input = default(Dictionary<string, Object>), Dictionary<string, Object> output = default(Dictionary<string, Object>), StateEnum? state = default(StateEnum?), string taskId = default(string), string taskRefName = default(string), string updatedBy = default(string), long? updatedOn = default(long?), string workflowId = default(string), string workflowName = default(string))
        {
            this.Assignee = assignee;
            this.Claimant = claimant;
            this.CreatedBy = createdBy;
            this.CreatedOn = createdOn;
            this.DefinitionName = definitionName;
            this.DisplayName = displayName;
            this.HumanTaskDef = humanTaskDef;
            this.Input = input;
            this.Output = output;
            this.State = state;
            this.TaskId = taskId;
            this.TaskRefName = taskRefName;
            this.UpdatedBy = updatedBy;
            this.UpdatedOn = updatedOn;
            this.WorkflowId = workflowId;
            this.WorkflowName = workflowName;
        }

        /// <summary>
        /// Gets or Sets Assignee
        /// </summary>
        [DataMember(Name = "assignee", EmitDefaultValue = false)]
        public HumanTaskUser Assignee { get; set; }

        /// <summary>
        /// Gets or Sets Claimant
        /// </summary>
        [DataMember(Name = "claimant", EmitDefaultValue = false)]
        public HumanTaskUser Claimant { get; set; }

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
        /// Gets or Sets DefinitionName
        /// </summary>
        [DataMember(Name = "definitionName", EmitDefaultValue = false)]
        public string DefinitionName { get; set; }

        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        [DataMember(Name = "displayName", EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets HumanTaskDef
        /// </summary>
        [DataMember(Name = "humanTaskDef", EmitDefaultValue = false)]
        public HumanTaskDefinition HumanTaskDef { get; set; }

        /// <summary>
        /// Gets or Sets Input
        /// </summary>
        [DataMember(Name = "input", EmitDefaultValue = false)]
        public Dictionary<string, Object> Input { get; set; }

        /// <summary>
        /// Gets or Sets Output
        /// </summary>
        [DataMember(Name = "output", EmitDefaultValue = false)]
        public Dictionary<string, Object> Output { get; set; }


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
            sb.Append("  Assignee: ").Append(Assignee).Append("\n");
            sb.Append("  Claimant: ").Append(Claimant).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  CreatedOn: ").Append(CreatedOn).Append("\n");
            sb.Append("  DefinitionName: ").Append(DefinitionName).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  HumanTaskDef: ").Append(HumanTaskDef).Append("\n");
            sb.Append("  Input: ").Append(Input).Append("\n");
            sb.Append("  Output: ").Append(Output).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  TaskId: ").Append(TaskId).Append("\n");
            sb.Append("  TaskRefName: ").Append(TaskRefName).Append("\n");
            sb.Append("  UpdatedBy: ").Append(UpdatedBy).Append("\n");
            sb.Append("  UpdatedOn: ").Append(UpdatedOn).Append("\n");
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
                    this.Assignee == input.Assignee ||
                    (this.Assignee != null &&
                    this.Assignee.Equals(input.Assignee))
                ) &&
                (
                    this.Claimant == input.Claimant ||
                    (this.Claimant != null &&
                    this.Claimant.Equals(input.Claimant))
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
                    this.DefinitionName == input.DefinitionName ||
                    (this.DefinitionName != null &&
                    this.DefinitionName.Equals(input.DefinitionName))
                ) &&
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) &&
                (
                    this.HumanTaskDef == input.HumanTaskDef ||
                    (this.HumanTaskDef != null &&
                    this.HumanTaskDef.Equals(input.HumanTaskDef))
                ) &&
                (
                    this.Input == input.Input ||
                    this.Input != null &&
                    input.Input != null &&
                    this.Input.SequenceEqual(input.Input)
                ) &&
                (
                    this.Output == input.Output ||
                    this.Output != null &&
                    input.Output != null &&
                    this.Output.SequenceEqual(input.Output)
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
                if (this.Assignee != null)
                    hashCode = hashCode * 59 + this.Assignee.GetHashCode();
                if (this.Claimant != null)
                    hashCode = hashCode * 59 + this.Claimant.GetHashCode();
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.CreatedOn != null)
                    hashCode = hashCode * 59 + this.CreatedOn.GetHashCode();
                if (this.DefinitionName != null)
                    hashCode = hashCode * 59 + this.DefinitionName.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.HumanTaskDef != null)
                    hashCode = hashCode * 59 + this.HumanTaskDef.GetHashCode();
                if (this.Input != null)
                    hashCode = hashCode * 59 + this.Input.GetHashCode();
                if (this.Output != null)
                    hashCode = hashCode * 59 + this.Output.GetHashCode();
                if (this.State != null)
                    hashCode = hashCode * 59 + this.State.GetHashCode();
                if (this.TaskId != null)
                    hashCode = hashCode * 59 + this.TaskId.GetHashCode();
                if (this.TaskRefName != null)
                    hashCode = hashCode * 59 + this.TaskRefName.GetHashCode();
                if (this.UpdatedBy != null)
                    hashCode = hashCode * 59 + this.UpdatedBy.GetHashCode();
                if (this.UpdatedOn != null)
                    hashCode = hashCode * 59 + this.UpdatedOn.GetHashCode();
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
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
