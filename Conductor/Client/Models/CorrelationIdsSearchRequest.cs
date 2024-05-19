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
    /// CorrelationIdsSearchRequest
    /// </summary>
    [DataContract]
    public partial class CorrelationIdsSearchRequest : IEquatable<CorrelationIdsSearchRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorrelationIdsSearchRequest" /> class.
        /// </summary>
        /// <param name="correlationIds">correlationIds (required).</param>
        /// <param name="workflowNames">workflowNames (required).</param>
        public CorrelationIdsSearchRequest(List<string> correlationIds = default(List<string>), List<string> workflowNames = default(List<string>))
        {
            // to ensure "correlationIds" is required (not null)
            if (correlationIds == null)
            {
                throw new InvalidDataException("correlationIds is a required property for CorrelationIdsSearchRequest and cannot be null");
            }
            else
            {
                this.CorrelationIds = correlationIds;
            }
            // to ensure "workflowNames" is required (not null)
            if (workflowNames == null)
            {
                throw new InvalidDataException("workflowNames is a required property for CorrelationIdsSearchRequest and cannot be null");
            }
            else
            {
                this.WorkflowNames = workflowNames;
            }
        }

        /// <summary>
        /// Gets or Sets CorrelationIds
        /// </summary>
        [DataMember(Name = "correlationIds", EmitDefaultValue = false)]
        public List<string> CorrelationIds { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowNames
        /// </summary>
        [DataMember(Name = "workflowNames", EmitDefaultValue = false)]
        public List<string> WorkflowNames { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CorrelationIdsSearchRequest {\n");
            sb.Append("  CorrelationIds: ").Append(CorrelationIds).Append("\n");
            sb.Append("  WorkflowNames: ").Append(WorkflowNames).Append("\n");
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
            return this.Equals(input as CorrelationIdsSearchRequest);
        }

        /// <summary>
        /// Returns true if CorrelationIdsSearchRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CorrelationIdsSearchRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CorrelationIdsSearchRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    this.CorrelationIds == input.CorrelationIds ||
                    this.CorrelationIds != null &&
                    input.CorrelationIds != null &&
                    this.CorrelationIds.SequenceEqual(input.CorrelationIds)
                ) &&
                (
                    this.WorkflowNames == input.WorkflowNames ||
                    this.WorkflowNames != null &&
                    input.WorkflowNames != null &&
                    this.WorkflowNames.SequenceEqual(input.WorkflowNames)
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
                if (this.CorrelationIds != null)
                    hashCode = hashCode * 59 + this.CorrelationIds.GetHashCode();
                if (this.WorkflowNames != null)
                    hashCode = hashCode * 59 + this.WorkflowNames.GetHashCode();
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
