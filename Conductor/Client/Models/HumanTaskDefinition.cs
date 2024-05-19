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
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Conductor.Client.Models
{
    /// <summary>
    /// HumanTaskDefinition
    /// </summary>
    [DataContract]
    public partial class HumanTaskDefinition : IEquatable<HumanTaskDefinition>, IValidatableObject
    {
        /// <summary>
        /// Defines AssignmentCompletionStrategy
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AssignmentCompletionStrategyEnum
        {
            /// <summary>
            /// Enum LEAVEOPEN for value: LEAVE_OPEN
            /// </summary>
            [EnumMember(Value = "LEAVE_OPEN")]
            LEAVEOPEN = 1,
            /// <summary>
            /// Enum TERMINATE for value: TERMINATE
            /// </summary>
            [EnumMember(Value = "TERMINATE")]
            TERMINATE = 2
        }
        /// <summary>
        /// Gets or Sets AssignmentCompletionStrategy
        /// </summary>
        [DataMember(Name = "assignmentCompletionStrategy", EmitDefaultValue = false)]
        public AssignmentCompletionStrategyEnum? AssignmentCompletionStrategy { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskDefinition" /> class.
        /// </summary>
        /// <param name="assignmentCompletionStrategy">assignmentCompletionStrategy.</param>
        /// <param name="assignments">assignments.</param>
        /// <param name="displayName">displayName.</param>
        /// <param name="taskTriggers">taskTriggers.</param>
        /// <param name="userFormTemplate">userFormTemplate.</param>
        public HumanTaskDefinition(AssignmentCompletionStrategyEnum? assignmentCompletionStrategy = default(AssignmentCompletionStrategyEnum?), List<HumanTaskAssignment> assignments = default(List<HumanTaskAssignment>), string displayName = default(string), List<HumanTaskTrigger> taskTriggers = default(List<HumanTaskTrigger>), UserFormTemplate userFormTemplate = default(UserFormTemplate))
        {
            this.AssignmentCompletionStrategy = assignmentCompletionStrategy;
            this.Assignments = assignments;
            this.DisplayName = displayName;
            this.TaskTriggers = taskTriggers;
            this.UserFormTemplate = userFormTemplate;
        }


        /// <summary>
        /// Gets or Sets Assignments
        /// </summary>
        [DataMember(Name = "assignments", EmitDefaultValue = false)]
        public List<HumanTaskAssignment> Assignments { get; set; }

        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        [DataMember(Name = "displayName", EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets TaskTriggers
        /// </summary>
        [DataMember(Name = "taskTriggers", EmitDefaultValue = false)]
        public List<HumanTaskTrigger> TaskTriggers { get; set; }

        /// <summary>
        /// Gets or Sets UserFormTemplate
        /// </summary>
        [DataMember(Name = "userFormTemplate", EmitDefaultValue = false)]
        public UserFormTemplate UserFormTemplate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HumanTaskDefinition {\n");
            sb.Append("  AssignmentCompletionStrategy: ").Append(AssignmentCompletionStrategy).Append("\n");
            sb.Append("  Assignments: ").Append(Assignments).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  TaskTriggers: ").Append(TaskTriggers).Append("\n");
            sb.Append("  UserFormTemplate: ").Append(UserFormTemplate).Append("\n");
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
            return this.Equals(input as HumanTaskDefinition);
        }

        /// <summary>
        /// Returns true if HumanTaskDefinition instances are equal
        /// </summary>
        /// <param name="input">Instance of HumanTaskDefinition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HumanTaskDefinition input)
        {
            if (input == null)
                return false;

            return
                (
                    this.AssignmentCompletionStrategy == input.AssignmentCompletionStrategy ||
                    (this.AssignmentCompletionStrategy != null &&
                    this.AssignmentCompletionStrategy.Equals(input.AssignmentCompletionStrategy))
                ) &&
                (
                    this.Assignments == input.Assignments ||
                    this.Assignments != null &&
                    input.Assignments != null &&
                    this.Assignments.SequenceEqual(input.Assignments)
                ) &&
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) &&
                (
                    this.TaskTriggers == input.TaskTriggers ||
                    this.TaskTriggers != null &&
                    input.TaskTriggers != null &&
                    this.TaskTriggers.SequenceEqual(input.TaskTriggers)
                ) &&
                (
                    this.UserFormTemplate == input.UserFormTemplate ||
                    (this.UserFormTemplate != null &&
                    this.UserFormTemplate.Equals(input.UserFormTemplate))
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
                if (this.AssignmentCompletionStrategy != null)
                    hashCode = hashCode * 59 + this.AssignmentCompletionStrategy.GetHashCode();
                if (this.Assignments != null)
                    hashCode = hashCode * 59 + this.Assignments.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.TaskTriggers != null)
                    hashCode = hashCode * 59 + this.TaskTriggers.GetHashCode();
                if (this.UserFormTemplate != null)
                    hashCode = hashCode * 59 + this.UserFormTemplate.GetHashCode();
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
