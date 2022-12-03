
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
    /// WorkflowScheduleExecutionModel
    /// </summary>
    [DataContract]
    public partial class WorkflowScheduleExecutionModel : IEquatable<WorkflowScheduleExecutionModel>, IValidatableObject
    {
        /// <summary>
        /// Defines State
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StateEnum
        {
            /// <summary>
            /// Enum POLLED for value: POLLED
            /// </summary>
            [EnumMember(Value = "POLLED")]
            POLLED = 1,
            /// <summary>
            /// Enum FAILED for value: FAILED
            /// </summary>
            [EnumMember(Value = "FAILED")]
            FAILED = 2,
            /// <summary>
            /// Enum EXECUTED for value: EXECUTED
            /// </summary>
            [EnumMember(Value = "EXECUTED")]
            EXECUTED = 3
        }
        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public StateEnum? State { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowScheduleExecutionModel" /> class.
        /// </summary>
        /// <param name="executionId">executionId.</param>
        /// <param name="executionTime">executionTime.</param>
        /// <param name="reason">reason.</param>
        /// <param name="scheduleName">scheduleName.</param>
        /// <param name="scheduledTime">scheduledTime.</param>
        /// <param name="stackTrace">stackTrace.</param>
        /// <param name="startWorkflowRequest">startWorkflowRequest.</param>
        /// <param name="state">state.</param>
        /// <param name="workflowId">workflowId.</param>
        /// <param name="workflowName">workflowName.</param>
        public WorkflowScheduleExecutionModel(string executionId = default(string), long? executionTime = default(long?), string reason = default(string), string scheduleName = default(string), long? scheduledTime = default(long?), string stackTrace = default(string), StartWorkflowRequest startWorkflowRequest = default(StartWorkflowRequest), StateEnum? state = default(StateEnum?), string workflowId = default(string), string workflowName = default(string))
        {
            this.ExecutionId = executionId;
            this.ExecutionTime = executionTime;
            this.Reason = reason;
            this.ScheduleName = scheduleName;
            this.ScheduledTime = scheduledTime;
            this.StackTrace = stackTrace;
            this.StartWorkflowRequest = startWorkflowRequest;
            this.State = state;
            this.WorkflowId = workflowId;
            this.WorkflowName = workflowName;
        }

        /// <summary>
        /// Gets or Sets ExecutionId
        /// </summary>
        [DataMember(Name = "executionId", EmitDefaultValue = false)]
        public string ExecutionId { get; set; }

        /// <summary>
        /// Gets or Sets ExecutionTime
        /// </summary>
        [DataMember(Name = "executionTime", EmitDefaultValue = false)]
        public long? ExecutionTime { get; set; }

        /// <summary>
        /// Gets or Sets Reason
        /// </summary>
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or Sets ScheduleName
        /// </summary>
        [DataMember(Name = "scheduleName", EmitDefaultValue = false)]
        public string ScheduleName { get; set; }

        /// <summary>
        /// Gets or Sets ScheduledTime
        /// </summary>
        [DataMember(Name = "scheduledTime", EmitDefaultValue = false)]
        public long? ScheduledTime { get; set; }

        /// <summary>
        /// Gets or Sets StackTrace
        /// </summary>
        [DataMember(Name = "stackTrace", EmitDefaultValue = false)]
        public string StackTrace { get; set; }

        /// <summary>
        /// Gets or Sets StartWorkflowRequest
        /// </summary>
        [DataMember(Name = "startWorkflowRequest", EmitDefaultValue = false)]
        public StartWorkflowRequest StartWorkflowRequest { get; set; }


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
            sb.Append("class WorkflowScheduleExecutionModel {\n");
            sb.Append("  ExecutionId: ").Append(ExecutionId).Append("\n");
            sb.Append("  ExecutionTime: ").Append(ExecutionTime).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  ScheduleName: ").Append(ScheduleName).Append("\n");
            sb.Append("  ScheduledTime: ").Append(ScheduledTime).Append("\n");
            sb.Append("  StackTrace: ").Append(StackTrace).Append("\n");
            sb.Append("  StartWorkflowRequest: ").Append(StartWorkflowRequest).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
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
            return this.Equals(input as WorkflowScheduleExecutionModel);
        }

        /// <summary>
        /// Returns true if WorkflowScheduleExecutionModel instances are equal
        /// </summary>
        /// <param name="input">Instance of WorkflowScheduleExecutionModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WorkflowScheduleExecutionModel input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ExecutionId == input.ExecutionId ||
                    (this.ExecutionId != null &&
                    this.ExecutionId.Equals(input.ExecutionId))
                ) &&
                (
                    this.ExecutionTime == input.ExecutionTime ||
                    (this.ExecutionTime != null &&
                    this.ExecutionTime.Equals(input.ExecutionTime))
                ) &&
                (
                    this.Reason == input.Reason ||
                    (this.Reason != null &&
                    this.Reason.Equals(input.Reason))
                ) &&
                (
                    this.ScheduleName == input.ScheduleName ||
                    (this.ScheduleName != null &&
                    this.ScheduleName.Equals(input.ScheduleName))
                ) &&
                (
                    this.ScheduledTime == input.ScheduledTime ||
                    (this.ScheduledTime != null &&
                    this.ScheduledTime.Equals(input.ScheduledTime))
                ) &&
                (
                    this.StackTrace == input.StackTrace ||
                    (this.StackTrace != null &&
                    this.StackTrace.Equals(input.StackTrace))
                ) &&
                (
                    this.StartWorkflowRequest == input.StartWorkflowRequest ||
                    (this.StartWorkflowRequest != null &&
                    this.StartWorkflowRequest.Equals(input.StartWorkflowRequest))
                ) &&
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
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
                if (this.ExecutionId != null)
                    hashCode = hashCode * 59 + this.ExecutionId.GetHashCode();
                if (this.ExecutionTime != null)
                    hashCode = hashCode * 59 + this.ExecutionTime.GetHashCode();
                if (this.Reason != null)
                    hashCode = hashCode * 59 + this.Reason.GetHashCode();
                if (this.ScheduleName != null)
                    hashCode = hashCode * 59 + this.ScheduleName.GetHashCode();
                if (this.ScheduledTime != null)
                    hashCode = hashCode * 59 + this.ScheduledTime.GetHashCode();
                if (this.StackTrace != null)
                    hashCode = hashCode * 59 + this.StackTrace.GetHashCode();
                if (this.StartWorkflowRequest != null)
                    hashCode = hashCode * 59 + this.StartWorkflowRequest.GetHashCode();
                if (this.State != null)
                    hashCode = hashCode * 59 + this.State.GetHashCode();
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
