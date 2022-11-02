
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
    /// TaskSummary
    /// </summary>
    [DataContract]
        public partial class TaskSummary :  IEquatable<TaskSummary>, IValidatableObject
    {
        /// <summary>
        /// Defines Status
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum StatusEnum
        {
            /// <summary>
            /// Enum INPROGRESS for value: IN_PROGRESS
            /// </summary>
            [EnumMember(Value = "IN_PROGRESS")]
            INPROGRESS = 1,
            /// <summary>
            /// Enum CANCELED for value: CANCELED
            /// </summary>
            [EnumMember(Value = "CANCELED")]
            CANCELED = 2,
            /// <summary>
            /// Enum FAILED for value: FAILED
            /// </summary>
            [EnumMember(Value = "FAILED")]
            FAILED = 3,
            /// <summary>
            /// Enum FAILEDWITHTERMINALERROR for value: FAILED_WITH_TERMINAL_ERROR
            /// </summary>
            [EnumMember(Value = "FAILED_WITH_TERMINAL_ERROR")]
            FAILEDWITHTERMINALERROR = 4,
            /// <summary>
            /// Enum COMPLETED for value: COMPLETED
            /// </summary>
            [EnumMember(Value = "COMPLETED")]
            COMPLETED = 5,
            /// <summary>
            /// Enum COMPLETEDWITHERRORS for value: COMPLETED_WITH_ERRORS
            /// </summary>
            [EnumMember(Value = "COMPLETED_WITH_ERRORS")]
            COMPLETEDWITHERRORS = 6,
            /// <summary>
            /// Enum SCHEDULED for value: SCHEDULED
            /// </summary>
            [EnumMember(Value = "SCHEDULED")]
            SCHEDULED = 7,
            /// <summary>
            /// Enum TIMEDOUT for value: TIMED_OUT
            /// </summary>
            [EnumMember(Value = "TIMED_OUT")]
            TIMEDOUT = 8,
            /// <summary>
            /// Enum SKIPPED for value: SKIPPED
            /// </summary>
            [EnumMember(Value = "SKIPPED")]
            SKIPPED = 9        }
        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskSummary" /> class.
        /// </summary>
        /// <param name="correlationId">correlationId.</param>
        /// <param name="endTime">endTime.</param>
        /// <param name="executionTime">executionTime.</param>
        /// <param name="externalInputPayloadStoragePath">externalInputPayloadStoragePath.</param>
        /// <param name="externalOutputPayloadStoragePath">externalOutputPayloadStoragePath.</param>
        /// <param name="input">input.</param>
        /// <param name="output">output.</param>
        /// <param name="queueWaitTime">queueWaitTime.</param>
        /// <param name="reasonForIncompletion">reasonForIncompletion.</param>
        /// <param name="scheduledTime">scheduledTime.</param>
        /// <param name="startTime">startTime.</param>
        /// <param name="status">status.</param>
        /// <param name="taskDefName">taskDefName.</param>
        /// <param name="taskId">taskId.</param>
        /// <param name="taskType">taskType.</param>
        /// <param name="updateTime">updateTime.</param>
        /// <param name="workflowId">workflowId.</param>
        /// <param name="workflowPriority">workflowPriority.</param>
        /// <param name="workflowType">workflowType.</param>
        public TaskSummary(string correlationId = default(string), string endTime = default(string), long? executionTime = default(long?), string externalInputPayloadStoragePath = default(string), string externalOutputPayloadStoragePath = default(string), string input = default(string), string output = default(string), long? queueWaitTime = default(long?), string reasonForIncompletion = default(string), string scheduledTime = default(string), string startTime = default(string), StatusEnum? status = default(StatusEnum?), string taskDefName = default(string), string taskId = default(string), string taskType = default(string), string updateTime = default(string), string workflowId = default(string), int? workflowPriority = default(int?), string workflowType = default(string))
        {
            this.CorrelationId = correlationId;
            this.EndTime = endTime;
            this.ExecutionTime = executionTime;
            this.ExternalInputPayloadStoragePath = externalInputPayloadStoragePath;
            this.ExternalOutputPayloadStoragePath = externalOutputPayloadStoragePath;
            this.Input = input;
            this.Output = output;
            this.QueueWaitTime = queueWaitTime;
            this.ReasonForIncompletion = reasonForIncompletion;
            this.ScheduledTime = scheduledTime;
            this.StartTime = startTime;
            this.Status = status;
            this.TaskDefName = taskDefName;
            this.TaskId = taskId;
            this.TaskType = taskType;
            this.UpdateTime = updateTime;
            this.WorkflowId = workflowId;
            this.WorkflowPriority = workflowPriority;
            this.WorkflowType = workflowType;
        }
        
        /// <summary>
        /// Gets or Sets CorrelationId
        /// </summary>
        [DataMember(Name="correlationId", EmitDefaultValue=false)]
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets or Sets EndTime
        /// </summary>
        [DataMember(Name="endTime", EmitDefaultValue=false)]
        public string EndTime { get; set; }

        /// <summary>
        /// Gets or Sets ExecutionTime
        /// </summary>
        [DataMember(Name="executionTime", EmitDefaultValue=false)]
        public long? ExecutionTime { get; set; }

        /// <summary>
        /// Gets or Sets ExternalInputPayloadStoragePath
        /// </summary>
        [DataMember(Name="externalInputPayloadStoragePath", EmitDefaultValue=false)]
        public string ExternalInputPayloadStoragePath { get; set; }

        /// <summary>
        /// Gets or Sets ExternalOutputPayloadStoragePath
        /// </summary>
        [DataMember(Name="externalOutputPayloadStoragePath", EmitDefaultValue=false)]
        public string ExternalOutputPayloadStoragePath { get; set; }

        /// <summary>
        /// Gets or Sets Input
        /// </summary>
        [DataMember(Name="input", EmitDefaultValue=false)]
        public string Input { get; set; }

        /// <summary>
        /// Gets or Sets Output
        /// </summary>
        [DataMember(Name="output", EmitDefaultValue=false)]
        public string Output { get; set; }

        /// <summary>
        /// Gets or Sets QueueWaitTime
        /// </summary>
        [DataMember(Name="queueWaitTime", EmitDefaultValue=false)]
        public long? QueueWaitTime { get; set; }

        /// <summary>
        /// Gets or Sets ReasonForIncompletion
        /// </summary>
        [DataMember(Name="reasonForIncompletion", EmitDefaultValue=false)]
        public string ReasonForIncompletion { get; set; }

        /// <summary>
        /// Gets or Sets ScheduledTime
        /// </summary>
        [DataMember(Name="scheduledTime", EmitDefaultValue=false)]
        public string ScheduledTime { get; set; }

        /// <summary>
        /// Gets or Sets StartTime
        /// </summary>
        [DataMember(Name="startTime", EmitDefaultValue=false)]
        public string StartTime { get; set; }


        /// <summary>
        /// Gets or Sets TaskDefName
        /// </summary>
        [DataMember(Name="taskDefName", EmitDefaultValue=false)]
        public string TaskDefName { get; set; }

        /// <summary>
        /// Gets or Sets TaskId
        /// </summary>
        [DataMember(Name="taskId", EmitDefaultValue=false)]
        public string TaskId { get; set; }

        /// <summary>
        /// Gets or Sets TaskType
        /// </summary>
        [DataMember(Name="taskType", EmitDefaultValue=false)]
        public string TaskType { get; set; }

        /// <summary>
        /// Gets or Sets UpdateTime
        /// </summary>
        [DataMember(Name="updateTime", EmitDefaultValue=false)]
        public string UpdateTime { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowId
        /// </summary>
        [DataMember(Name="workflowId", EmitDefaultValue=false)]
        public string WorkflowId { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowPriority
        /// </summary>
        [DataMember(Name="workflowPriority", EmitDefaultValue=false)]
        public int? WorkflowPriority { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowType
        /// </summary>
        [DataMember(Name="workflowType", EmitDefaultValue=false)]
        public string WorkflowType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TaskSummary {\n");
            sb.Append("  CorrelationId: ").Append(CorrelationId).Append("\n");
            sb.Append("  EndTime: ").Append(EndTime).Append("\n");
            sb.Append("  ExecutionTime: ").Append(ExecutionTime).Append("\n");
            sb.Append("  ExternalInputPayloadStoragePath: ").Append(ExternalInputPayloadStoragePath).Append("\n");
            sb.Append("  ExternalOutputPayloadStoragePath: ").Append(ExternalOutputPayloadStoragePath).Append("\n");
            sb.Append("  Input: ").Append(Input).Append("\n");
            sb.Append("  Output: ").Append(Output).Append("\n");
            sb.Append("  QueueWaitTime: ").Append(QueueWaitTime).Append("\n");
            sb.Append("  ReasonForIncompletion: ").Append(ReasonForIncompletion).Append("\n");
            sb.Append("  ScheduledTime: ").Append(ScheduledTime).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  TaskDefName: ").Append(TaskDefName).Append("\n");
            sb.Append("  TaskId: ").Append(TaskId).Append("\n");
            sb.Append("  TaskType: ").Append(TaskType).Append("\n");
            sb.Append("  UpdateTime: ").Append(UpdateTime).Append("\n");
            sb.Append("  WorkflowId: ").Append(WorkflowId).Append("\n");
            sb.Append("  WorkflowPriority: ").Append(WorkflowPriority).Append("\n");
            sb.Append("  WorkflowType: ").Append(WorkflowType).Append("\n");
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
            return this.Equals(input as TaskSummary);
        }

        /// <summary>
        /// Returns true if TaskSummary instances are equal
        /// </summary>
        /// <param name="input">Instance of TaskSummary to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TaskSummary input)
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
                    this.EndTime == input.EndTime ||
                    (this.EndTime != null &&
                    this.EndTime.Equals(input.EndTime))
                ) && 
                (
                    this.ExecutionTime == input.ExecutionTime ||
                    (this.ExecutionTime != null &&
                    this.ExecutionTime.Equals(input.ExecutionTime))
                ) && 
                (
                    this.ExternalInputPayloadStoragePath == input.ExternalInputPayloadStoragePath ||
                    (this.ExternalInputPayloadStoragePath != null &&
                    this.ExternalInputPayloadStoragePath.Equals(input.ExternalInputPayloadStoragePath))
                ) && 
                (
                    this.ExternalOutputPayloadStoragePath == input.ExternalOutputPayloadStoragePath ||
                    (this.ExternalOutputPayloadStoragePath != null &&
                    this.ExternalOutputPayloadStoragePath.Equals(input.ExternalOutputPayloadStoragePath))
                ) && 
                (
                    this.Input == input.Input ||
                    (this.Input != null &&
                    this.Input.Equals(input.Input))
                ) && 
                (
                    this.Output == input.Output ||
                    (this.Output != null &&
                    this.Output.Equals(input.Output))
                ) && 
                (
                    this.QueueWaitTime == input.QueueWaitTime ||
                    (this.QueueWaitTime != null &&
                    this.QueueWaitTime.Equals(input.QueueWaitTime))
                ) && 
                (
                    this.ReasonForIncompletion == input.ReasonForIncompletion ||
                    (this.ReasonForIncompletion != null &&
                    this.ReasonForIncompletion.Equals(input.ReasonForIncompletion))
                ) && 
                (
                    this.ScheduledTime == input.ScheduledTime ||
                    (this.ScheduledTime != null &&
                    this.ScheduledTime.Equals(input.ScheduledTime))
                ) && 
                (
                    this.StartTime == input.StartTime ||
                    (this.StartTime != null &&
                    this.StartTime.Equals(input.StartTime))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.TaskDefName == input.TaskDefName ||
                    (this.TaskDefName != null &&
                    this.TaskDefName.Equals(input.TaskDefName))
                ) && 
                (
                    this.TaskId == input.TaskId ||
                    (this.TaskId != null &&
                    this.TaskId.Equals(input.TaskId))
                ) && 
                (
                    this.TaskType == input.TaskType ||
                    (this.TaskType != null &&
                    this.TaskType.Equals(input.TaskType))
                ) && 
                (
                    this.UpdateTime == input.UpdateTime ||
                    (this.UpdateTime != null &&
                    this.UpdateTime.Equals(input.UpdateTime))
                ) && 
                (
                    this.WorkflowId == input.WorkflowId ||
                    (this.WorkflowId != null &&
                    this.WorkflowId.Equals(input.WorkflowId))
                ) && 
                (
                    this.WorkflowPriority == input.WorkflowPriority ||
                    (this.WorkflowPriority != null &&
                    this.WorkflowPriority.Equals(input.WorkflowPriority))
                ) && 
                (
                    this.WorkflowType == input.WorkflowType ||
                    (this.WorkflowType != null &&
                    this.WorkflowType.Equals(input.WorkflowType))
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
                if (this.EndTime != null)
                    hashCode = hashCode * 59 + this.EndTime.GetHashCode();
                if (this.ExecutionTime != null)
                    hashCode = hashCode * 59 + this.ExecutionTime.GetHashCode();
                if (this.ExternalInputPayloadStoragePath != null)
                    hashCode = hashCode * 59 + this.ExternalInputPayloadStoragePath.GetHashCode();
                if (this.ExternalOutputPayloadStoragePath != null)
                    hashCode = hashCode * 59 + this.ExternalOutputPayloadStoragePath.GetHashCode();
                if (this.Input != null)
                    hashCode = hashCode * 59 + this.Input.GetHashCode();
                if (this.Output != null)
                    hashCode = hashCode * 59 + this.Output.GetHashCode();
                if (this.QueueWaitTime != null)
                    hashCode = hashCode * 59 + this.QueueWaitTime.GetHashCode();
                if (this.ReasonForIncompletion != null)
                    hashCode = hashCode * 59 + this.ReasonForIncompletion.GetHashCode();
                if (this.ScheduledTime != null)
                    hashCode = hashCode * 59 + this.ScheduledTime.GetHashCode();
                if (this.StartTime != null)
                    hashCode = hashCode * 59 + this.StartTime.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.TaskDefName != null)
                    hashCode = hashCode * 59 + this.TaskDefName.GetHashCode();
                if (this.TaskId != null)
                    hashCode = hashCode * 59 + this.TaskId.GetHashCode();
                if (this.TaskType != null)
                    hashCode = hashCode * 59 + this.TaskType.GetHashCode();
                if (this.UpdateTime != null)
                    hashCode = hashCode * 59 + this.UpdateTime.GetHashCode();
                if (this.WorkflowId != null)
                    hashCode = hashCode * 59 + this.WorkflowId.GetHashCode();
                if (this.WorkflowPriority != null)
                    hashCode = hashCode * 59 + this.WorkflowPriority.GetHashCode();
                if (this.WorkflowType != null)
                    hashCode = hashCode * 59 + this.WorkflowType.GetHashCode();
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
