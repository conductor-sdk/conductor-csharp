using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Conductor.Client.Models
{
    /// <summary>
    /// HumanTaskLoad
    /// </summary>
    [DataContract]
    public partial class HumanTaskLoad : IEquatable<HumanTaskLoad>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskLoad" /> class.
        /// </summary>
        /// <param name="assignedUser">assignedUser.</param>
        /// <param name="count">count.</param>
        /// <param name="taskRefName">taskRefName.</param>
        /// <param name="workflowName">workflowName.</param>
        public HumanTaskLoad(string assignedUser = default(string), int? count = default(int?), string taskRefName = default(string), string workflowName = default(string))
        {
            this.AssignedUser = assignedUser;
            this.Count = count;
            this.TaskRefName = taskRefName;
            this.WorkflowName = workflowName;
        }

        /// <summary>
        /// Gets or Sets AssignedUser
        /// </summary>
        [DataMember(Name = "assignedUser", EmitDefaultValue = false)]
        public string AssignedUser { get; set; }

        /// <summary>
        /// Gets or Sets Count
        /// </summary>
        [DataMember(Name = "count", EmitDefaultValue = false)]
        public int? Count { get; set; }

        /// <summary>
        /// Gets or Sets TaskRefName
        /// </summary>
        [DataMember(Name = "taskRefName", EmitDefaultValue = false)]
        public string TaskRefName { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowName
        /// </summary>
        [DataMember(Name = "workflowName", EmitDefaultValue = false)]
        public string WorkflowName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HumanTaskLoad {\n");
            sb.Append("  AssignedUser: ").Append(AssignedUser).Append("\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
            sb.Append("  TaskRefName: ").Append(TaskRefName).Append("\n");
            sb.Append("  WorkflowName: ").Append(WorkflowName).Append("\n");
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
            return this.Equals(input as HumanTaskLoad);
        }

        /// <summary>
        /// Returns true if HumanTaskLoad instances are equal
        /// </summary>
        /// <param name="input">Instance of HumanTaskLoad to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HumanTaskLoad input)
        {
            if (input == null)
                return false;

            return
                (
                    this.AssignedUser == input.AssignedUser ||
                    (this.AssignedUser != null &&
                    this.AssignedUser.Equals(input.AssignedUser))
                ) &&
                (
                    this.Count == input.Count ||
                    (this.Count != null &&
                    this.Count.Equals(input.Count))
                ) &&
                (
                    this.TaskRefName == input.TaskRefName ||
                    (this.TaskRefName != null &&
                    this.TaskRefName.Equals(input.TaskRefName))
                ) &&
                (
                    this.WorkflowName == input.WorkflowName ||
                    (this.WorkflowName != null &&
                    this.WorkflowName.Equals(input.WorkflowName))
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
                if (this.AssignedUser != null)
                    hashCode = hashCode * 59 + this.AssignedUser.GetHashCode();
                if (this.Count != null)
                    hashCode = hashCode * 59 + this.Count.GetHashCode();
                if (this.TaskRefName != null)
                    hashCode = hashCode * 59 + this.TaskRefName.GetHashCode();
                if (this.WorkflowName != null)
                    hashCode = hashCode * 59 + this.WorkflowName.GetHashCode();
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
