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
using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Conductor.Client.Models
{
    /// <summary>
    /// ScrollableSearchResultWorkflowSummary
    /// </summary>
    [DataContract]
    public partial class ScrollableSearchResultWorkflowSummary : IEquatable<ScrollableSearchResultWorkflowSummary>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScrollableSearchResultWorkflowSummary" /> class.
        /// </summary>
        /// <param name="queryId">queryId.</param>
        /// <param name="results">results.</param>
        public ScrollableSearchResultWorkflowSummary(
            string queryId = default(string),
            List<WorkflowSummary> results = default(List<WorkflowSummary>),
            long? totalHits = default(long?)
        )
        {
            this.QueryId = queryId;
            this.Results = results;
            this.TotalHits = totalHits;
        }

        /// <summary>
        /// Gets or Sets QueryId
        /// </summary>
        [DataMember(Name = "queryId", EmitDefaultValue = false)]
        public string QueryId { get; set; }

        /// <summary>
        /// Gets or Sets Results
        /// </summary>
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<WorkflowSummary> Results { get; set; }

        /// <summary>
        /// Gets or Sets TotalHits
        /// </summary>
        [DataMember(Name = "totalHits", EmitDefaultValue = false)]
        public long? TotalHits { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ScrollableSearchResultWorkflowSummary {\n");
            sb.Append("  QueryId: ").Append(QueryId).Append("\n");
            sb.Append("  Results: ").Append(Results).Append("\n");
            sb.Append("  TotalHits: ").Append(TotalHits).Append("\n");
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
            return this.Equals(input as ScrollableSearchResultWorkflowSummary);
        }

        /// <summary>
        /// Returns true if ScrollableSearchResultWorkflowSummary instances are equal
        /// </summary>
        /// <param name="input">Instance of ScrollableSearchResultWorkflowSummary to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScrollableSearchResultWorkflowSummary input)
        {
            if (input == null)
                return false;

            return
                (
                    this.QueryId == input.QueryId ||
                    (this.QueryId != null &&
                    this.QueryId.Equals(input.QueryId))
                ) &&
                (
                    this.Results == input.Results ||
                    this.Results != null &&
                    input.Results != null &&
                    this.Results.SequenceEqual(input.Results)
                ) &&
                (
                    this.TotalHits == input.TotalHits ||
                    this.TotalHits.Equals(input.TotalHits)
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
                if (this.QueryId != null)
                    hashCode = hashCode * 59 + this.QueryId.GetHashCode();
                if (this.Results != null)
                    hashCode = hashCode * 59 + this.Results.GetHashCode();
                if (this.TotalHits != null)
                    hashCode = hashCode * 59 + this.TotalHits.GetHashCode();
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
