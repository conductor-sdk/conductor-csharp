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
using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Conductor.Client.Models
{
    /// <summary>
    /// PollData
    /// </summary>
    [DataContract]
    public partial class PollData : IEquatable<PollData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PollData" /> class.
        /// </summary>
        /// <param name="domain">domain.</param>
        /// <param name="lastPollTime">lastPollTime.</param>
        /// <param name="queueName">queueName.</param>
        /// <param name="workerId">workerId.</param>
        public PollData(string domain = default(string), long? lastPollTime = default(long?), string queueName = default(string), string workerId = default(string))
        {
            this.Domain = domain;
            this.LastPollTime = lastPollTime;
            this.QueueName = queueName;
            this.WorkerId = workerId;
        }

        /// <summary>
        /// Gets or Sets Domain
        /// </summary>
        [DataMember(Name = "domain", EmitDefaultValue = false)]
        public string Domain { get; set; }

        /// <summary>
        /// Gets or Sets LastPollTime
        /// </summary>
        [DataMember(Name = "lastPollTime", EmitDefaultValue = false)]
        public long? LastPollTime { get; set; }

        /// <summary>
        /// Gets or Sets QueueName
        /// </summary>
        [DataMember(Name = "queueName", EmitDefaultValue = false)]
        public string QueueName { get; set; }

        /// <summary>
        /// Gets or Sets WorkerId
        /// </summary>
        [DataMember(Name = "workerId", EmitDefaultValue = false)]
        public string WorkerId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PollData {\n");
            sb.Append("  Domain: ").Append(Domain).Append("\n");
            sb.Append("  LastPollTime: ").Append(LastPollTime).Append("\n");
            sb.Append("  QueueName: ").Append(QueueName).Append("\n");
            sb.Append("  WorkerId: ").Append(WorkerId).Append("\n");
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
            return this.Equals(input as PollData);
        }

        /// <summary>
        /// Returns true if PollData instances are equal
        /// </summary>
        /// <param name="input">Instance of PollData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PollData input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Domain == input.Domain ||
                    (this.Domain != null &&
                    this.Domain.Equals(input.Domain))
                ) &&
                (
                    this.LastPollTime == input.LastPollTime ||
                    (this.LastPollTime != null &&
                    this.LastPollTime.Equals(input.LastPollTime))
                ) &&
                (
                    this.QueueName == input.QueueName ||
                    (this.QueueName != null &&
                    this.QueueName.Equals(input.QueueName))
                ) &&
                (
                    this.WorkerId == input.WorkerId ||
                    (this.WorkerId != null &&
                    this.WorkerId.Equals(input.WorkerId))
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
                if (this.Domain != null)
                    hashCode = hashCode * 59 + this.Domain.GetHashCode();
                if (this.LastPollTime != null)
                    hashCode = hashCode * 59 + this.LastPollTime.GetHashCode();
                if (this.QueueName != null)
                    hashCode = hashCode * 59 + this.QueueName.GetHashCode();
                if (this.WorkerId != null)
                    hashCode = hashCode * 59 + this.WorkerId.GetHashCode();
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
