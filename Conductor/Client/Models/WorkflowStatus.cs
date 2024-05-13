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
using System.Linq;
using Newtonsoft.Json.Converters;
using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Conductor.Client.Models
{
    /// <summary>
    /// WorkflowStatus
    /// </summary>
    [DataContract]
    public partial class WorkflowStatus : IEquatable<WorkflowStatus>, IValidatableObject
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
            PAUSED = 6
        }
        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowStatus" /> class.
        /// </summary>
        /// <param name="correlationId">correlationId.</param>
        /// <param name="output">output.</param>
        /// <param name="status">status.</param>
        /// <param name="variables">variables.</param>
        /// <param name="workflowId">workflowId.</param>
        public WorkflowStatus(string correlationId = default(string), Dictionary<string, Object> output = default(Dictionary<string, Object>), StatusEnum? status = default(StatusEnum?), Dictionary<string, Object> variables = default(Dictionary<string, Object>), string workflowId = default(string))
        {
            this.CorrelationId = correlationId;
            this.Output = output;
            this.Status = status;
            this.Variables = variables;
            this.WorkflowId = workflowId;
        }

        /// <summary>
        /// Gets or Sets CorrelationId
        /// </summary>
        [DataMember(Name = "correlationId", EmitDefaultValue = false)]
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets or Sets Output
        /// </summary>
        [DataMember(Name = "output", EmitDefaultValue = false)]
        public Dictionary<string, Object> Output { get; set; }


        /// <summary>
        /// Gets or Sets Variables
        /// </summary>
        [DataMember(Name = "variables", EmitDefaultValue = false)]
        public Dictionary<string, Object> Variables { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowId
        /// </summary>
        [DataMember(Name = "workflowId", EmitDefaultValue = false)]
        public string WorkflowId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WorkflowStatus {\n");
            sb.Append("  CorrelationId: ").Append(CorrelationId).Append("\n");
            sb.Append("  Output: ").Append(Output).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Variables: ").Append(Variables).Append("\n");
            sb.Append("  WorkflowId: ").Append(WorkflowId).Append("\n");
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
            return this.Equals(input as WorkflowStatus);
        }

        /// <summary>
        /// Returns true if WorkflowStatus instances are equal
        /// </summary>
        /// <param name="input">Instance of WorkflowStatus to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WorkflowStatus input)
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
                    this.Output == input.Output ||
                    this.Output != null &&
                    input.Output != null &&
                    this.Output.SequenceEqual(input.Output)
                ) &&
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) &&
                (
                    this.Variables == input.Variables ||
                    this.Variables != null &&
                    input.Variables != null &&
                    this.Variables.SequenceEqual(input.Variables)
                ) &&
                (
                    this.WorkflowId == input.WorkflowId ||
                    (this.WorkflowId != null &&
                    this.WorkflowId.Equals(input.WorkflowId))
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
                if (this.Output != null)
                    hashCode = hashCode * 59 + this.Output.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Variables != null)
                    hashCode = hashCode * 59 + this.Variables.GetHashCode();
                if (this.WorkflowId != null)
                    hashCode = hashCode * 59 + this.WorkflowId.GetHashCode();
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
