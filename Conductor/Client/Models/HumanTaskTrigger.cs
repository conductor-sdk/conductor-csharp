using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Conductor.Client.Models
{
    /// <summary>
    /// HumanTaskTrigger
    /// </summary>
    [DataContract]
    public partial class HumanTaskTrigger : IEquatable<HumanTaskTrigger>, IValidatableObject
    {
        /// <summary>
        /// Defines TriggerType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TriggerTypeEnum
        {
            /// <summary>
            /// Enum ASSIGNEECHANGED for value: ASSIGNEE_CHANGED
            /// </summary>
            [EnumMember(Value = "ASSIGNEE_CHANGED")]
            ASSIGNEECHANGED = 1,
            /// <summary>
            /// Enum PENDING for value: PENDING
            /// </summary>
            [EnumMember(Value = "PENDING")]
            PENDING = 2,
            /// <summary>
            /// Enum INPROGRESS for value: IN_PROGRESS
            /// </summary>
            [EnumMember(Value = "IN_PROGRESS")]
            INPROGRESS = 3,
            /// <summary>
            /// Enum ASSIGNED for value: ASSIGNED
            /// </summary>
            [EnumMember(Value = "ASSIGNED")]
            ASSIGNED = 4,
            /// <summary>
            /// Enum COMPLETED for value: COMPLETED
            /// </summary>
            [EnumMember(Value = "COMPLETED")]
            COMPLETED = 5,
            /// <summary>
            /// Enum TIMEDOUT for value: TIMED_OUT
            /// </summary>
            [EnumMember(Value = "TIMED_OUT")]
            TIMEDOUT = 6
        }
        /// <summary>
        /// Gets or Sets TriggerType
        /// </summary>
        [DataMember(Name = "triggerType", EmitDefaultValue = false)]
        public TriggerTypeEnum? TriggerType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskTrigger" /> class.
        /// </summary>
        /// <param name="startWorkflowRequest">startWorkflowRequest.</param>
        /// <param name="triggerType">triggerType.</param>
        public HumanTaskTrigger(StartWorkflowRequest startWorkflowRequest = default(StartWorkflowRequest), TriggerTypeEnum? triggerType = default(TriggerTypeEnum?))
        {
            this.StartWorkflowRequest = startWorkflowRequest;
            this.TriggerType = triggerType;
        }

        /// <summary>
        /// Gets or Sets StartWorkflowRequest
        /// </summary>
        [DataMember(Name = "startWorkflowRequest", EmitDefaultValue = false)]
        public StartWorkflowRequest StartWorkflowRequest { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HumanTaskTrigger {\n");
            sb.Append("  StartWorkflowRequest: ").Append(StartWorkflowRequest).Append("\n");
            sb.Append("  TriggerType: ").Append(TriggerType).Append("\n");
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
            return this.Equals(input as HumanTaskTrigger);
        }

        /// <summary>
        /// Returns true if HumanTaskTrigger instances are equal
        /// </summary>
        /// <param name="input">Instance of HumanTaskTrigger to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HumanTaskTrigger input)
        {
            if (input == null)
                return false;

            return
                (
                    this.StartWorkflowRequest == input.StartWorkflowRequest ||
                    (this.StartWorkflowRequest != null &&
                    this.StartWorkflowRequest.Equals(input.StartWorkflowRequest))
                ) &&
                (
                    this.TriggerType == input.TriggerType ||
                    (this.TriggerType != null &&
                    this.TriggerType.Equals(input.TriggerType))
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
                if (this.StartWorkflowRequest != null)
                    hashCode = hashCode * 59 + this.StartWorkflowRequest.GetHashCode();
                if (this.TriggerType != null)
                    hashCode = hashCode * 59 + this.TriggerType.GetHashCode();
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
