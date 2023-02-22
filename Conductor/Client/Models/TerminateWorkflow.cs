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
    /// TerminateWorkflow
    /// </summary>
    [DataContract]
    public partial class TerminateWorkflow : IEquatable<TerminateWorkflow>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TerminateWorkflow" /> class.
        /// </summary>
        /// <param name="terminationReason">terminationReason.</param>
        /// <param name="workflowId">workflowId.</param>
        public TerminateWorkflow(string terminationReason = default(string), string workflowId = default(string))
        {
            this.TerminationReason = terminationReason;
            this.WorkflowId = workflowId;
        }

        /// <summary>
        /// Gets or Sets TerminationReason
        /// </summary>
        [DataMember(Name = "terminationReason", EmitDefaultValue = false)]
        public string TerminationReason { get; set; }

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
            sb.Append("class TerminateWorkflow {\n");
            sb.Append("  TerminationReason: ").Append(TerminationReason).Append("\n");
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
            return this.Equals(input as TerminateWorkflow);
        }

        /// <summary>
        /// Returns true if TerminateWorkflow instances are equal
        /// </summary>
        /// <param name="input">Instance of TerminateWorkflow to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TerminateWorkflow input)
        {
            if (input == null)
                return false;

            return
                (
                    this.TerminationReason == input.TerminationReason ||
                    (this.TerminationReason != null &&
                    this.TerminationReason.Equals(input.TerminationReason))
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
                if (this.TerminationReason != null)
                    hashCode = hashCode * 59 + this.TerminationReason.GetHashCode();
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
