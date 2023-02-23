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
    /// UpdateWorkflowVariables
    /// </summary>
    [DataContract]
    public partial class UpdateWorkflowVariables : IEquatable<UpdateWorkflowVariables>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWorkflowVariables" /> class.
        /// </summary>
        /// <param name="appendArray">appendArray.</param>
        /// <param name="variables">variables.</param>
        /// <param name="workflowId">workflowId.</param>
        public UpdateWorkflowVariables(bool? appendArray = default(bool?), Dictionary<string, Object> variables = default(Dictionary<string, Object>), string workflowId = default(string))
        {
            this.AppendArray = appendArray;
            this.Variables = variables;
            this.WorkflowId = workflowId;
        }

        /// <summary>
        /// Gets or Sets AppendArray
        /// </summary>
        [DataMember(Name = "appendArray", EmitDefaultValue = false)]
        public bool? AppendArray { get; set; }

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
            sb.Append("class UpdateWorkflowVariables {\n");
            sb.Append("  AppendArray: ").Append(AppendArray).Append("\n");
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
            return this.Equals(input as UpdateWorkflowVariables);
        }

        /// <summary>
        /// Returns true if UpdateWorkflowVariables instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateWorkflowVariables to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateWorkflowVariables input)
        {
            if (input == null)
                return false;

            return
                (
                    this.AppendArray == input.AppendArray ||
                    (this.AppendArray != null &&
                    this.AppendArray.Equals(input.AppendArray))
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
                if (this.AppendArray != null)
                    hashCode = hashCode * 59 + this.AppendArray.GetHashCode();
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
