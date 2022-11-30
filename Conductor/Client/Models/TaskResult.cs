
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
    /// TaskResult
    /// </summary>
    [DataContract]
    public partial class TaskResult : IEquatable<TaskResult>, IValidatableObject
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
            /// Enum FAILED for value: FAILED
            /// </summary>
            [EnumMember(Value = "FAILED")]
            FAILED = 2,
            /// <summary>
            /// Enum FAILEDWITHTERMINALERROR for value: FAILED_WITH_TERMINAL_ERROR
            /// </summary>
            [EnumMember(Value = "FAILED_WITH_TERMINAL_ERROR")]
            FAILEDWITHTERMINALERROR = 3,
            /// <summary>
            /// Enum COMPLETED for value: COMPLETED
            /// </summary>
            [EnumMember(Value = "COMPLETED")]
            COMPLETED = 4
        }
        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskResult" /> class.
        /// </summary>
        /// <param name="callbackAfterSeconds">callbackAfterSeconds.</param>
        /// <param name="externalOutputPayloadStoragePath">externalOutputPayloadStoragePath.</param>
        /// <param name="logs">logs.</param>
        /// <param name="outputData">outputData.</param>
        /// <param name="reasonForIncompletion">reasonForIncompletion.</param>
        /// <param name="status">status.</param>
        /// <param name="subWorkflowId">subWorkflowId.</param>
        /// <param name="taskId">taskId (required).</param>
        /// <param name="workerId">workerId.</param>
        /// <param name="workflowInstanceId">workflowInstanceId (required).</param>
        public TaskResult(long? callbackAfterSeconds = default(long?), string externalOutputPayloadStoragePath = default(string), List<TaskExecLog> logs = default(List<TaskExecLog>), Dictionary<string, Object> outputData = default(Dictionary<string, Object>), string reasonForIncompletion = default(string), StatusEnum? status = default(StatusEnum?), string subWorkflowId = default(string), string taskId = default(string), string workerId = default(string), string workflowInstanceId = default(string))
        {
            // to ensure "taskId" is required (not null)
            if (taskId == null)
            {
                throw new InvalidDataException("taskId is a required property for TaskResult and cannot be null");
            }
            else
            {
                this.TaskId = taskId;
            }
            // to ensure "workflowInstanceId" is required (not null)
            if (workflowInstanceId == null)
            {
                throw new InvalidDataException("workflowInstanceId is a required property for TaskResult and cannot be null");
            }
            else
            {
                this.WorkflowInstanceId = workflowInstanceId;
            }
            this.CallbackAfterSeconds = callbackAfterSeconds;
            this.ExternalOutputPayloadStoragePath = externalOutputPayloadStoragePath;
            this.Logs = logs;
            this.OutputData = outputData;
            this.ReasonForIncompletion = reasonForIncompletion;
            this.Status = status;
            this.SubWorkflowId = subWorkflowId;
            this.WorkerId = workerId;
        }

        /// <summary>
        /// Gets or Sets CallbackAfterSeconds
        /// </summary>
        [DataMember(Name = "callbackAfterSeconds", EmitDefaultValue = false)]
        public long? CallbackAfterSeconds { get; set; }

        /// <summary>
        /// Gets or Sets ExternalOutputPayloadStoragePath
        /// </summary>
        [DataMember(Name = "externalOutputPayloadStoragePath", EmitDefaultValue = false)]
        public string ExternalOutputPayloadStoragePath { get; set; }

        /// <summary>
        /// Gets or Sets Logs
        /// </summary>
        [DataMember(Name = "logs", EmitDefaultValue = false)]
        public List<TaskExecLog> Logs { get; set; }

        /// <summary>
        /// Gets or Sets OutputData
        /// </summary>
        [DataMember(Name = "outputData", EmitDefaultValue = false)]
        public Dictionary<string, Object> OutputData { get; set; }

        /// <summary>
        /// Gets or Sets ReasonForIncompletion
        /// </summary>
        [DataMember(Name = "reasonForIncompletion", EmitDefaultValue = false)]
        public string ReasonForIncompletion { get; set; }


        /// <summary>
        /// Gets or Sets SubWorkflowId
        /// </summary>
        [DataMember(Name = "subWorkflowId", EmitDefaultValue = false)]
        public string SubWorkflowId { get; set; }

        /// <summary>
        /// Gets or Sets TaskId
        /// </summary>
        [DataMember(Name = "taskId", EmitDefaultValue = false)]
        public string TaskId { get; set; }

        /// <summary>
        /// Gets or Sets WorkerId
        /// </summary>
        [DataMember(Name = "workerId", EmitDefaultValue = false)]
        public string WorkerId { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowInstanceId
        /// </summary>
        [DataMember(Name = "workflowInstanceId", EmitDefaultValue = false)]
        public string WorkflowInstanceId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TaskResult {\n");
            sb.Append("  CallbackAfterSeconds: ").Append(CallbackAfterSeconds).Append("\n");
            sb.Append("  ExternalOutputPayloadStoragePath: ").Append(ExternalOutputPayloadStoragePath).Append("\n");
            sb.Append("  Logs: ").Append(Logs).Append("\n");
            sb.Append("  OutputData: ").Append(OutputData).Append("\n");
            sb.Append("  ReasonForIncompletion: ").Append(ReasonForIncompletion).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  SubWorkflowId: ").Append(SubWorkflowId).Append("\n");
            sb.Append("  TaskId: ").Append(TaskId).Append("\n");
            sb.Append("  WorkerId: ").Append(WorkerId).Append("\n");
            sb.Append("  WorkflowInstanceId: ").Append(WorkflowInstanceId).Append("\n");
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
            return this.Equals(input as TaskResult);
        }

        /// <summary>
        /// Returns true if TaskResult instances are equal
        /// </summary>
        /// <param name="input">Instance of TaskResult to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TaskResult input)
        {
            if (input == null)
                return false;

            return
                (
                    this.CallbackAfterSeconds == input.CallbackAfterSeconds ||
                    (this.CallbackAfterSeconds != null &&
                    this.CallbackAfterSeconds.Equals(input.CallbackAfterSeconds))
                ) &&
                (
                    this.ExternalOutputPayloadStoragePath == input.ExternalOutputPayloadStoragePath ||
                    (this.ExternalOutputPayloadStoragePath != null &&
                    this.ExternalOutputPayloadStoragePath.Equals(input.ExternalOutputPayloadStoragePath))
                ) &&
                (
                    this.Logs == input.Logs ||
                    this.Logs != null &&
                    input.Logs != null &&
                    this.Logs.SequenceEqual(input.Logs)
                ) &&
                (
                    this.OutputData == input.OutputData ||
                    this.OutputData != null &&
                    input.OutputData != null &&
                    this.OutputData.SequenceEqual(input.OutputData)
                ) &&
                (
                    this.ReasonForIncompletion == input.ReasonForIncompletion ||
                    (this.ReasonForIncompletion != null &&
                    this.ReasonForIncompletion.Equals(input.ReasonForIncompletion))
                ) &&
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) &&
                (
                    this.SubWorkflowId == input.SubWorkflowId ||
                    (this.SubWorkflowId != null &&
                    this.SubWorkflowId.Equals(input.SubWorkflowId))
                ) &&
                (
                    this.TaskId == input.TaskId ||
                    (this.TaskId != null &&
                    this.TaskId.Equals(input.TaskId))
                ) &&
                (
                    this.WorkerId == input.WorkerId ||
                    (this.WorkerId != null &&
                    this.WorkerId.Equals(input.WorkerId))
                ) &&
                (
                    this.WorkflowInstanceId == input.WorkflowInstanceId ||
                    (this.WorkflowInstanceId != null &&
                    this.WorkflowInstanceId.Equals(input.WorkflowInstanceId))
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
                if (this.CallbackAfterSeconds != null)
                    hashCode = hashCode * 59 + this.CallbackAfterSeconds.GetHashCode();
                if (this.ExternalOutputPayloadStoragePath != null)
                    hashCode = hashCode * 59 + this.ExternalOutputPayloadStoragePath.GetHashCode();
                if (this.Logs != null)
                    hashCode = hashCode * 59 + this.Logs.GetHashCode();
                if (this.OutputData != null)
                    hashCode = hashCode * 59 + this.OutputData.GetHashCode();
                if (this.ReasonForIncompletion != null)
                    hashCode = hashCode * 59 + this.ReasonForIncompletion.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.SubWorkflowId != null)
                    hashCode = hashCode * 59 + this.SubWorkflowId.GetHashCode();
                if (this.TaskId != null)
                    hashCode = hashCode * 59 + this.TaskId.GetHashCode();
                if (this.WorkerId != null)
                    hashCode = hashCode * 59 + this.WorkerId.GetHashCode();
                if (this.WorkflowInstanceId != null)
                    hashCode = hashCode * 59 + this.WorkflowInstanceId.GetHashCode();
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
