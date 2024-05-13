/*
 * Copyright 2024 Conductor Authors.
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 */
using System.IO;
using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Conductor.Client.Models
{
    /// <summary>
    /// SaveScheduleRequest
    /// </summary>
    [DataContract]
    public partial class SaveScheduleRequest : IEquatable<SaveScheduleRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveScheduleRequest" /> class.
        /// </summary>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="cronExpression">cronExpression (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="paused">paused.</param>
        /// <param name="runCatchupScheduleInstances">runCatchupScheduleInstances.</param>
        /// <param name="scheduleEndTime">scheduleEndTime.</param>
        /// <param name="scheduleStartTime">scheduleStartTime.</param>
        /// <param name="startWorkflowRequest">startWorkflowRequest (required).</param>
        /// <param name="updatedBy">updatedBy.</param>
        public SaveScheduleRequest(string createdBy = default(string), string cronExpression = default(string), string name = default(string), bool? paused = default(bool?), bool? runCatchupScheduleInstances = default(bool?), long? scheduleEndTime = default(long?), long? scheduleStartTime = default(long?), StartWorkflowRequest startWorkflowRequest = default(StartWorkflowRequest), string updatedBy = default(string))
        {
            // to ensure "cronExpression" is required (not null)
            if (cronExpression == null)
            {
                throw new InvalidDataException("cronExpression is a required property for SaveScheduleRequest and cannot be null");
            }
            else
            {
                this.CronExpression = cronExpression;
            }
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for SaveScheduleRequest and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            // to ensure "startWorkflowRequest" is required (not null)
            if (startWorkflowRequest == null)
            {
                throw new InvalidDataException("startWorkflowRequest is a required property for SaveScheduleRequest and cannot be null");
            }
            else
            {
                this.StartWorkflowRequest = startWorkflowRequest;
            }
            this.CreatedBy = createdBy;
            this.Paused = paused;
            this.RunCatchupScheduleInstances = runCatchupScheduleInstances;
            this.ScheduleEndTime = scheduleEndTime;
            this.ScheduleStartTime = scheduleStartTime;
            this.UpdatedBy = updatedBy;
        }

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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SaveScheduleRequest {\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  CronExpression: ").Append(CronExpression).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Paused: ").Append(Paused).Append("\n");
            sb.Append("  RunCatchupScheduleInstances: ").Append(RunCatchupScheduleInstances).Append("\n");
            sb.Append("  ScheduleEndTime: ").Append(ScheduleEndTime).Append("\n");
            sb.Append("  ScheduleStartTime: ").Append(ScheduleStartTime).Append("\n");
            sb.Append("  StartWorkflowRequest: ").Append(StartWorkflowRequest).Append("\n");
            sb.Append("  UpdatedBy: ").Append(UpdatedBy).Append("\n");
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
            return this.Equals(input as SaveScheduleRequest);
        }

        /// <summary>
        /// Returns true if SaveScheduleRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of SaveScheduleRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SaveScheduleRequest input)
        {
            if (input == null)
                return false;

            return
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
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.CronExpression != null)
                    hashCode = hashCode * 59 + this.CronExpression.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Paused != null)
                    hashCode = hashCode * 59 + this.Paused.GetHashCode();
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
