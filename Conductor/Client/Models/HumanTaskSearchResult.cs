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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Conductor.Client.Models
{
    /// <summary>
    /// HumanTaskSearchResult
    /// </summary>
    [DataContract]
    public partial class HumanTaskSearchResult : IEquatable<HumanTaskSearchResult>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskSearchResult" /> class.
        /// </summary>
        /// <param name="hits">hits.</param>
        /// <param name="pageSizeLimit">pageSizeLimit.</param>
        /// <param name="results">results.</param>
        /// <param name="start">start.</param>
        /// <param name="totalHits">totalHits.</param>
        public HumanTaskSearchResult(int? hits = default(int?), int? pageSizeLimit = default(int?), List<HumanTaskEntry> results = default(List<HumanTaskEntry>), int? start = default(int?), long? totalHits = default(long?))
        {
            this.Hits = hits;
            this.PageSizeLimit = pageSizeLimit;
            this.Results = results;
            this.Start = start;
            this.TotalHits = totalHits;
        }

        /// <summary>
        /// Gets or Sets Hits
        /// </summary>
        [DataMember(Name = "hits", EmitDefaultValue = false)]
        public int? Hits { get; set; }

        /// <summary>
        /// Gets or Sets PageSizeLimit
        /// </summary>
        [DataMember(Name = "pageSizeLimit", EmitDefaultValue = false)]
        public int? PageSizeLimit { get; set; }

        /// <summary>
        /// Gets or Sets Results
        /// </summary>
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<HumanTaskEntry> Results { get; set; }

        /// <summary>
        /// Gets or Sets Start
        /// </summary>
        [DataMember(Name = "start", EmitDefaultValue = false)]
        public int? Start { get; set; }

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
            sb.Append("class HumanTaskSearchResult {\n");
            sb.Append("  Hits: ").Append(Hits).Append("\n");
            sb.Append("  PageSizeLimit: ").Append(PageSizeLimit).Append("\n");
            sb.Append("  Results: ").Append(Results).Append("\n");
            sb.Append("  Start: ").Append(Start).Append("\n");
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
            return this.Equals(input as HumanTaskSearchResult);
        }

        /// <summary>
        /// Returns true if HumanTaskSearchResult instances are equal
        /// </summary>
        /// <param name="input">Instance of HumanTaskSearchResult to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HumanTaskSearchResult input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Hits == input.Hits ||
                    (this.Hits != null &&
                    this.Hits.Equals(input.Hits))
                ) &&
                (
                    this.PageSizeLimit == input.PageSizeLimit ||
                    (this.PageSizeLimit != null &&
                    this.PageSizeLimit.Equals(input.PageSizeLimit))
                ) &&
                (
                    this.Results == input.Results ||
                    this.Results != null &&
                    input.Results != null &&
                    this.Results.SequenceEqual(input.Results)
                ) &&
                (
                    this.Start == input.Start ||
                    (this.Start != null &&
                    this.Start.Equals(input.Start))
                ) &&
                (
                    this.TotalHits == input.TotalHits ||
                    (this.TotalHits != null &&
                    this.TotalHits.Equals(input.TotalHits))
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
                if (this.Hits != null)
                    hashCode = hashCode * 59 + this.Hits.GetHashCode();
                if (this.PageSizeLimit != null)
                    hashCode = hashCode * 59 + this.PageSizeLimit.GetHashCode();
                if (this.Results != null)
                    hashCode = hashCode * 59 + this.Results.GetHashCode();
                if (this.Start != null)
                    hashCode = hashCode * 59 + this.Start.GetHashCode();
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
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
