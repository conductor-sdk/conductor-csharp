
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
    /// WorkflowSummary
    /// </summary>
    [DataContract]
        public partial class WorkflowSummary :  IEquatable<WorkflowSummary>, IValidatableObject
    {
        /// <summary>
        /// Defines Status
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum StatusEnum
        {
            /// <summary>
            /// Enum RUNNING for value: RUNNING
            /// </summary>
            [EnumMember(Value = "RUNNING")]
            RUNNING = 1,
            /// <summary>
            /// Enum COMPLETED for value: COMPLETED
            /// </summary>
            [EnumMember(Value = "COMPLETED")]
            COMPLETED = 2,
            /// <summary>
            /// Enum FAILED for value: FAILED
            /// </summary>
            [EnumMember(Value = "FAILED")]
            FAILED = 3,
            /// <summary>
            /// Enum TIMEDOUT for value: TIMED_OUT
            /// </summary>
            [EnumMember(Value = "TIMED_OUT")]
            TIMEDOUT = 4,
            /// <summary>
            /// Enum TERMINATED for value: TERMINATED
            /// </summary>
            [EnumMember(Value = "TERMINATED")]
            TERMINATED = 5,
            /// <summary>
            /// Enum PAUSED for value: PAUSED
            /// </summary>
            [EnumMember(Value = "PAUSED")]
            PAUSED = 6        }
        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowSummary" /> class.
        /// </summary>
        /// <param name="correlationId">correlationId.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="endTime">endTime.</param>
        /// <param name="_event">_event.</param>
        /// <param name="executionTime">executionTime.</param>
        /// <param name="externalInputPayloadStoragePath">externalInputPayloadStoragePath.</param>
        /// <param name="externalOutputPayloadStoragePath">externalOutputPayloadStoragePath.</param>
        /// <param name="failedReferenceTaskNames">failedReferenceTaskNames.</param>
        /// <param name="input">input.</param>
        /// <param name="inputSize">inputSize.</param>
        /// <param name="output">output.</param>
        /// <param name="outputSize">outputSize.</param>
        /// <param name="priority">priority.</param>
        /// <param name="reasonForIncompletion">reasonForIncompletion.</param>
        /// <param name="startTime">startTime.</param>
        /// <param name="status">status.</param>
        /// <param name="updateTime">updateTime.</param>
        /// <param name="version">version.</param>
        /// <param name="workflowId">workflowId.</param>
        /// <param name="workflowType">workflowType.</param>
        public WorkflowSummary(string correlationId = default(string), string createdBy = default(string), string endTime = default(string), string _event = default(string), long? executionTime = default(long?), string externalInputPayloadStoragePath = default(string), string externalOutputPayloadStoragePath = default(string), string failedReferenceTaskNames = default(string), string input = default(string), long? inputSize = default(long?), string output = default(string), long? outputSize = default(long?), int? priority = default(int?), string reasonForIncompletion = default(string), string startTime = default(string), StatusEnum? status = default(StatusEnum?), string updateTime = default(string), int? version = default(int?), string workflowId = default(string), string workflowType = default(string))
        {
            this.CorrelationId = correlationId;
            this.CreatedBy = createdBy;
            this.EndTime = endTime;
            this._Event = _event;
            this.ExecutionTime = executionTime;
            this.ExternalInputPayloadStoragePath = externalInputPayloadStoragePath;
            this.ExternalOutputPayloadStoragePath = externalOutputPayloadStoragePath;
            this.FailedReferenceTaskNames = failedReferenceTaskNames;
            this.Input = input;
            this.InputSize = inputSize;
            this.Output = output;
            this.OutputSize = outputSize;
            this.Priority = priority;
            this.ReasonForIncompletion = reasonForIncompletion;
            this.StartTime = startTime;
            this.Status = status;
            this.UpdateTime = updateTime;
            this.Version = version;
            this.WorkflowId = workflowId;
            this.WorkflowType = workflowType;
        }
        
        /// <summary>
        /// Gets or Sets CorrelationId
        /// </summary>
        [DataMember(Name="correlationId", EmitDefaultValue=false)]
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets EndTime
        /// </summary>
        [DataMember(Name="endTime", EmitDefaultValue=false)]
        public string EndTime { get; set; }

        /// <summary>
        /// Gets or Sets _Event
        /// </summary>
        [DataMember(Name="event", EmitDefaultValue=false)]
        public string _Event { get; set; }

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
        /// Gets or Sets FailedReferenceTaskNames
        /// </summary>
        [DataMember(Name="failedReferenceTaskNames", EmitDefaultValue=false)]
        public string FailedReferenceTaskNames { get; set; }

        /// <summary>
        /// Gets or Sets Input
        /// </summary>
        [DataMember(Name="input", EmitDefaultValue=false)]
        public string Input { get; set; }

        /// <summary>
        /// Gets or Sets InputSize
        /// </summary>
        [DataMember(Name="inputSize", EmitDefaultValue=false)]
        public long? InputSize { get; set; }

        /// <summary>
        /// Gets or Sets Output
        /// </summary>
        [DataMember(Name="output", EmitDefaultValue=false)]
        public string Output { get; set; }

        /// <summary>
        /// Gets or Sets OutputSize
        /// </summary>
        [DataMember(Name="outputSize", EmitDefaultValue=false)]
        public long? OutputSize { get; set; }

        /// <summary>
        /// Gets or Sets Priority
        /// </summary>
        [DataMember(Name="priority", EmitDefaultValue=false)]
        public int? Priority { get; set; }

        /// <summary>
        /// Gets or Sets ReasonForIncompletion
        /// </summary>
        [DataMember(Name="reasonForIncompletion", EmitDefaultValue=false)]
        public string ReasonForIncompletion { get; set; }

        /// <summary>
        /// Gets or Sets StartTime
        /// </summary>
        [DataMember(Name="startTime", EmitDefaultValue=false)]
        public string StartTime { get; set; }


        /// <summary>
        /// Gets or Sets UpdateTime
        /// </summary>
        [DataMember(Name="updateTime", EmitDefaultValue=false)]
        public string UpdateTime { get; set; }

        /// <summary>
        /// Gets or Sets Version
        /// </summary>
        [DataMember(Name="version", EmitDefaultValue=false)]
        public int? Version { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowId
        /// </summary>
        [DataMember(Name="workflowId", EmitDefaultValue=false)]
        public string WorkflowId { get; set; }

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
            sb.Append("class WorkflowSummary {\n");
            sb.Append("  CorrelationId: ").Append(CorrelationId).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  EndTime: ").Append(EndTime).Append("\n");
            sb.Append("  _Event: ").Append(_Event).Append("\n");
            sb.Append("  ExecutionTime: ").Append(ExecutionTime).Append("\n");
            sb.Append("  ExternalInputPayloadStoragePath: ").Append(ExternalInputPayloadStoragePath).Append("\n");
            sb.Append("  ExternalOutputPayloadStoragePath: ").Append(ExternalOutputPayloadStoragePath).Append("\n");
            sb.Append("  FailedReferenceTaskNames: ").Append(FailedReferenceTaskNames).Append("\n");
            sb.Append("  Input: ").Append(Input).Append("\n");
            sb.Append("  InputSize: ").Append(InputSize).Append("\n");
            sb.Append("  Output: ").Append(Output).Append("\n");
            sb.Append("  OutputSize: ").Append(OutputSize).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("  ReasonForIncompletion: ").Append(ReasonForIncompletion).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  UpdateTime: ").Append(UpdateTime).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  WorkflowId: ").Append(WorkflowId).Append("\n");
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
            return this.Equals(input as WorkflowSummary);
        }

        /// <summary>
        /// Returns true if WorkflowSummary instances are equal
        /// </summary>
        /// <param name="input">Instance of WorkflowSummary to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WorkflowSummary input)
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
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) && 
                (
                    this.EndTime == input.EndTime ||
                    (this.EndTime != null &&
                    this.EndTime.Equals(input.EndTime))
                ) && 
                (
                    this._Event == input._Event ||
                    (this._Event != null &&
                    this._Event.Equals(input._Event))
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
                    this.FailedReferenceTaskNames == input.FailedReferenceTaskNames ||
                    (this.FailedReferenceTaskNames != null &&
                    this.FailedReferenceTaskNames.Equals(input.FailedReferenceTaskNames))
                ) && 
                (
                    this.Input == input.Input ||
                    (this.Input != null &&
                    this.Input.Equals(input.Input))
                ) && 
                (
                    this.InputSize == input.InputSize ||
                    (this.InputSize != null &&
                    this.InputSize.Equals(input.InputSize))
                ) && 
                (
                    this.Output == input.Output ||
                    (this.Output != null &&
                    this.Output.Equals(input.Output))
                ) && 
                (
                    this.OutputSize == input.OutputSize ||
                    (this.OutputSize != null &&
                    this.OutputSize.Equals(input.OutputSize))
                ) && 
                (
                    this.Priority == input.Priority ||
                    (this.Priority != null &&
                    this.Priority.Equals(input.Priority))
                ) && 
                (
                    this.ReasonForIncompletion == input.ReasonForIncompletion ||
                    (this.ReasonForIncompletion != null &&
                    this.ReasonForIncompletion.Equals(input.ReasonForIncompletion))
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
                    this.UpdateTime == input.UpdateTime ||
                    (this.UpdateTime != null &&
                    this.UpdateTime.Equals(input.UpdateTime))
                ) && 
                (
                    this.Version == input.Version ||
                    (this.Version != null &&
                    this.Version.Equals(input.Version))
                ) && 
                (
                    this.WorkflowId == input.WorkflowId ||
                    (this.WorkflowId != null &&
                    this.WorkflowId.Equals(input.WorkflowId))
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
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.EndTime != null)
                    hashCode = hashCode * 59 + this.EndTime.GetHashCode();
                if (this._Event != null)
                    hashCode = hashCode * 59 + this._Event.GetHashCode();
                if (this.ExecutionTime != null)
                    hashCode = hashCode * 59 + this.ExecutionTime.GetHashCode();
                if (this.ExternalInputPayloadStoragePath != null)
                    hashCode = hashCode * 59 + this.ExternalInputPayloadStoragePath.GetHashCode();
                if (this.ExternalOutputPayloadStoragePath != null)
                    hashCode = hashCode * 59 + this.ExternalOutputPayloadStoragePath.GetHashCode();
                if (this.FailedReferenceTaskNames != null)
                    hashCode = hashCode * 59 + this.FailedReferenceTaskNames.GetHashCode();
                if (this.Input != null)
                    hashCode = hashCode * 59 + this.Input.GetHashCode();
                if (this.InputSize != null)
                    hashCode = hashCode * 59 + this.InputSize.GetHashCode();
                if (this.Output != null)
                    hashCode = hashCode * 59 + this.Output.GetHashCode();
                if (this.OutputSize != null)
                    hashCode = hashCode * 59 + this.OutputSize.GetHashCode();
                if (this.Priority != null)
                    hashCode = hashCode * 59 + this.Priority.GetHashCode();
                if (this.ReasonForIncompletion != null)
                    hashCode = hashCode * 59 + this.ReasonForIncompletion.GetHashCode();
                if (this.StartTime != null)
                    hashCode = hashCode * 59 + this.StartTime.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.UpdateTime != null)
                    hashCode = hashCode * 59 + this.UpdateTime.GetHashCode();
                if (this.Version != null)
                    hashCode = hashCode * 59 + this.Version.GetHashCode();
                if (this.WorkflowId != null)
                    hashCode = hashCode * 59 + this.WorkflowId.GetHashCode();
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
