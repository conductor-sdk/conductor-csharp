
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
    /// WorkflowSchedule
    /// </summary>
    [DataContract]
    public partial class WorkflowSchedule : IEquatable<WorkflowSchedule>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowSchedule" /> class.
        /// </summary>
        /// <param name="createTime">createTime.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="cronExpression">cronExpression.</param>
        /// <param name="name">name.</param>
        /// <param name="paused">paused.</param>
        /// <param name="pausedReason">pausedReason.</param>
        /// <param name="runCatchupScheduleInstances">runCatchupScheduleInstances.</param>
        /// <param name="scheduleEndTime">scheduleEndTime.</param>
        /// <param name="scheduleStartTime">scheduleStartTime.</param>
        /// <param name="startWorkflowRequest">startWorkflowRequest.</param>
        /// <param name="updatedBy">updatedBy.</param>
        /// <param name="updatedTime">updatedTime.</param>
        public WorkflowSchedule(long? createTime = default(long?), string createdBy = default(string), string cronExpression = default(string), string name = default(string), bool? paused = default(bool?), string pausedReason = default(string), bool? runCatchupScheduleInstances = default(bool?), long? scheduleEndTime = default(long?), long? scheduleStartTime = default(long?), StartWorkflowRequest startWorkflowRequest = default(StartWorkflowRequest), string updatedBy = default(string), long? updatedTime = default(long?))
        {
            this.CreateTime = createTime;
            this.CreatedBy = createdBy;
            this.CronExpression = cronExpression;
            this.Name = name;
            this.Paused = paused;
            this.PausedReason = pausedReason;
            this.RunCatchupScheduleInstances = runCatchupScheduleInstances;
            this.ScheduleEndTime = scheduleEndTime;
            this.ScheduleStartTime = scheduleStartTime;
            this.StartWorkflowRequest = startWorkflowRequest;
            this.UpdatedBy = updatedBy;
            this.UpdatedTime = updatedTime;
        }

        /// <summary>
        /// Gets or Sets CreateTime
        /// </summary>
        [DataMember(Name = "createTime", EmitDefaultValue = false)]
        public long? CreateTime { get; set; }

        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets CronExpression
        /// </summary>
        [DataMember(Name = "cronExpression", EmitDefaultValue = false)]
        public string CronExpression { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Paused
        /// </summary>
        [DataMember(Name = "paused", EmitDefaultValue = false)]
        public bool? Paused { get; set; }

        /// <summary>
        /// Gets or Sets PausedReason
        /// </summary>
        [DataMember(Name = "pausedReason", EmitDefaultValue = false)]
        public string PausedReason { get; set; }

        /// <summary>
        /// Gets or Sets RunCatchupScheduleInstances
        /// </summary>
        [DataMember(Name = "runCatchupScheduleInstances", EmitDefaultValue = false)]
        public bool? RunCatchupScheduleInstances { get; set; }

        /// <summary>
        /// Gets or Sets ScheduleEndTime
        /// </summary>
        [DataMember(Name = "scheduleEndTime", EmitDefaultValue = false)]
        public long? ScheduleEndTime { get; set; }

        /// <summary>
        /// Gets or Sets ScheduleStartTime
        /// </summary>
        [DataMember(Name = "scheduleStartTime", EmitDefaultValue = false)]
        public long? ScheduleStartTime { get; set; }

        /// <summary>
        /// Gets or Sets StartWorkflowRequest
        /// </summary>
        [DataMember(Name = "startWorkflowRequest", EmitDefaultValue = false)]
        public StartWorkflowRequest StartWorkflowRequest { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedBy
        /// </summary>
        [DataMember(Name = "updatedBy", EmitDefaultValue = false)]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedTime
        /// </summary>
        [DataMember(Name = "updatedTime", EmitDefaultValue = false)]
        public long? UpdatedTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WorkflowSchedule {\n");
            sb.Append("  CreateTime: ").Append(CreateTime).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  CronExpression: ").Append(CronExpression).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Paused: ").Append(Paused).Append("\n");
            sb.Append("  PausedReason: ").Append(PausedReason).Append("\n");
            sb.Append("  RunCatchupScheduleInstances: ").Append(RunCatchupScheduleInstances).Append("\n");
            sb.Append("  ScheduleEndTime: ").Append(ScheduleEndTime).Append("\n");
            sb.Append("  ScheduleStartTime: ").Append(ScheduleStartTime).Append("\n");
            sb.Append("  StartWorkflowRequest: ").Append(StartWorkflowRequest).Append("\n");
            sb.Append("  UpdatedBy: ").Append(UpdatedBy).Append("\n");
            sb.Append("  UpdatedTime: ").Append(UpdatedTime).Append("\n");
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
            return this.Equals(input as WorkflowSchedule);
        }

        /// <summary>
        /// Returns true if WorkflowSchedule instances are equal
        /// </summary>
        /// <param name="input">Instance of WorkflowSchedule to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WorkflowSchedule input)
        {
            if (input == null)
                return false;

            return
                (
                    this.CreateTime == input.CreateTime ||
                    (this.CreateTime != null &&
                    this.CreateTime.Equals(input.CreateTime))
                ) &&
                (
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) &&
                (
                    this.CronExpression == input.CronExpression ||
                    (this.CronExpression != null &&
                    this.CronExpression.Equals(input.CronExpression))
                ) &&
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.Paused == input.Paused ||
                    (this.Paused != null &&
                    this.Paused.Equals(input.Paused))
                ) &&
                (
                    this.PausedReason == input.PausedReason ||
                    (this.PausedReason != null &&
                    this.PausedReason.Equals(input.PausedReason))
                ) &&
                (
                    this.RunCatchupScheduleInstances == input.RunCatchupScheduleInstances ||
                    (this.RunCatchupScheduleInstances != null &&
                    this.RunCatchupScheduleInstances.Equals(input.RunCatchupScheduleInstances))
                ) &&
                (
                    this.ScheduleEndTime == input.ScheduleEndTime ||
                    (this.ScheduleEndTime != null &&
                    this.ScheduleEndTime.Equals(input.ScheduleEndTime))
                ) &&
                (
                    this.ScheduleStartTime == input.ScheduleStartTime ||
                    (this.ScheduleStartTime != null &&
                    this.ScheduleStartTime.Equals(input.ScheduleStartTime))
                ) &&
                (
                    this.StartWorkflowRequest == input.StartWorkflowRequest ||
                    (this.StartWorkflowRequest != null &&
                    this.StartWorkflowRequest.Equals(input.StartWorkflowRequest))
                ) &&
                (
                    this.UpdatedBy == input.UpdatedBy ||
                    (this.UpdatedBy != null &&
                    this.UpdatedBy.Equals(input.UpdatedBy))
                ) &&
                (
                    this.UpdatedTime == input.UpdatedTime ||
                    (this.UpdatedTime != null &&
                    this.UpdatedTime.Equals(input.UpdatedTime))
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
                if (this.CreateTime != null)
                    hashCode = hashCode * 59 + this.CreateTime.GetHashCode();
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.CronExpression != null)
                    hashCode = hashCode * 59 + this.CronExpression.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Paused != null)
                    hashCode = hashCode * 59 + this.Paused.GetHashCode();
                if (this.PausedReason != null)
                    hashCode = hashCode * 59 + this.PausedReason.GetHashCode();
                if (this.RunCatchupScheduleInstances != null)
                    hashCode = hashCode * 59 + this.RunCatchupScheduleInstances.GetHashCode();
                if (this.ScheduleEndTime != null)
                    hashCode = hashCode * 59 + this.ScheduleEndTime.GetHashCode();
                if (this.ScheduleStartTime != null)
                    hashCode = hashCode * 59 + this.ScheduleStartTime.GetHashCode();
                if (this.StartWorkflowRequest != null)
                    hashCode = hashCode * 59 + this.StartWorkflowRequest.GetHashCode();
                if (this.UpdatedBy != null)
                    hashCode = hashCode * 59 + this.UpdatedBy.GetHashCode();
                if (this.UpdatedTime != null)
                    hashCode = hashCode * 59 + this.UpdatedTime.GetHashCode();
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
