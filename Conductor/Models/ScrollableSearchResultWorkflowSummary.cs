
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
        public ScrollableSearchResultWorkflowSummary(string queryId = default(string), List<WorkflowSummary> results = default(List<WorkflowSummary>))
        {
            this.QueryId = queryId;
            this.Results = results;
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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ScrollableSearchResultWorkflowSummary {\n");
            sb.Append("  QueryId: ").Append(QueryId).Append("\n");
            sb.Append("  Results: ").Append(Results).Append("\n");
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
