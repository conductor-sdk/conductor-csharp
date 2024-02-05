using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Conductor.Client.Models
{
    /// <summary>
    ///     StartWorkflowRequest
    /// </summary>
    [DataContract]
    public class StartWorkflowRequest : IEquatable<StartWorkflowRequest>, IValidatableObject
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="StartWorkflowRequest" /> class.
        /// </summary>
        /// <param name="correlationId">correlationId.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="externalInputPayloadStoragePath">externalInputPayloadStoragePath.</param>
        /// <param name="input">input.</param>
        /// <param name="name">name (required).</param>
        /// <param name="priority">priority.</param>
        /// <param name="taskToDomain">taskToDomain.</param>
        /// <param name="version">version.</param>
        /// <param name="workflowDef">workflowDef.</param>
        public StartWorkflowRequest(string correlationId = default, string createdBy = default,
            string externalInputPayloadStoragePath = default, Dictionary<string, object> input = default,
            string name = default, int? priority = default, Dictionary<string, string> taskToDomain = default,
            int? version = default, WorkflowDef workflowDef = default,
            string idempotencyKey = default(string),
            IdempotencyStrategy idempotencyStrategy = IdempotencyStrategy.FAIL)
        {
            this.Name = name;
            this.CorrelationId = correlationId;
            this.CreatedBy = createdBy;
            this.ExternalInputPayloadStoragePath = externalInputPayloadStoragePath;
            this.Input = input;
            this.Priority = priority;
            this.TaskToDomain = taskToDomain;
            this.Version = version;
            this.WorkflowDef = workflowDef;
            this.IdempotencyKey = idempotencyKey;
            this.IdempotencyStrategy = idempotencyStrategy;
        }
        
        [DataMember(Name = "idempotencyStrategy", EmitDefaultValue = true)]
        public IdempotencyStrategy IdempotencyStrategy { get; set; }

        [DataMember(Name = "idempotencyKey", EmitDefaultValue = false)]
        public string IdempotencyKey { get; set; }
        
        /// <summary>
        ///     Gets or Sets CorrelationId
        /// </summary>
        [DataMember(Name = "correlationId", EmitDefaultValue = false)]
        public string CorrelationId { get; set; }

        /// <summary>
        ///     Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        public string CreatedBy { get; set; }

        /// <summary>
        ///     Gets or Sets ExternalInputPayloadStoragePath
        /// </summary>
        [DataMember(Name = "externalInputPayloadStoragePath", EmitDefaultValue = false)]
        public string ExternalInputPayloadStoragePath { get; set; }

        /// <summary>
        ///     Gets or Sets Input
        /// </summary>
        [DataMember(Name = "input", EmitDefaultValue = false)]
        public Dictionary<string, object> Input { get; set; }

        /// <summary>
        ///     Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or Sets Priority
        /// </summary>
        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public int? Priority { get; set; }

        /// <summary>
        ///     Gets or Sets TaskToDomain
        /// </summary>
        [DataMember(Name = "taskToDomain", EmitDefaultValue = false)]
        public Dictionary<string, string> TaskToDomain { get; set; }

        /// <summary>
        ///     Gets or Sets Version
        /// </summary>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public int? Version { get; set; }

        /// <summary>
        ///     Gets or Sets WorkflowDef
        /// </summary>
        [DataMember(Name = "workflowDef", EmitDefaultValue = false)]
        public WorkflowDef WorkflowDef { get; set; }

        /// <summary>
        ///     Returns true if StartWorkflowRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of StartWorkflowRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StartWorkflowRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    CorrelationId == input.CorrelationId ||
                    (CorrelationId != null &&
                     CorrelationId.Equals(input.CorrelationId))
                ) &&
                (
                    CreatedBy == input.CreatedBy ||
                    (CreatedBy != null &&
                     CreatedBy.Equals(input.CreatedBy))
                ) &&
                (
                    ExternalInputPayloadStoragePath == input.ExternalInputPayloadStoragePath ||
                    (ExternalInputPayloadStoragePath != null &&
                     ExternalInputPayloadStoragePath.Equals(input.ExternalInputPayloadStoragePath))
                ) &&
                (
                    Input == input.Input ||
                    (Input != null &&
                     input.Input != null &&
                     Input.SequenceEqual(input.Input))
                ) &&
                (
                    Name == input.Name ||
                    (Name != null &&
                     Name.Equals(input.Name))
                ) &&
                (
                    Priority == input.Priority ||
                    (Priority != null &&
                     Priority.Equals(input.Priority))
                ) &&
                (
                    TaskToDomain == input.TaskToDomain ||
                    (TaskToDomain != null &&
                     input.TaskToDomain != null &&
                     TaskToDomain.SequenceEqual(input.TaskToDomain))
                ) &&
                (
                    Version == input.Version ||
                    (Version != null &&
                     Version.Equals(input.Version))
                ) &&
                (
                    WorkflowDef == input.WorkflowDef ||
                    (WorkflowDef != null &&
                     WorkflowDef.Equals(input.WorkflowDef))
                );
        }

        /// <summary>
        ///     To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StartWorkflowRequest {\n");
            sb.Append("  CorrelationId: ").Append(CorrelationId).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  ExternalInputPayloadStoragePath: ").Append(ExternalInputPayloadStoragePath).Append("\n");
            sb.Append("  Input: ").Append(Input).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("  TaskToDomain: ").Append(TaskToDomain).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  WorkflowDef: ").Append(WorkflowDef).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        ///     Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as StartWorkflowRequest);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                if (CorrelationId != null)
                    hashCode = hashCode * 59 + CorrelationId.GetHashCode();
                if (CreatedBy != null)
                    hashCode = hashCode * 59 + CreatedBy.GetHashCode();
                if (ExternalInputPayloadStoragePath != null)
                    hashCode = hashCode * 59 + ExternalInputPayloadStoragePath.GetHashCode();
                if (Input != null)
                    hashCode = hashCode * 59 + Input.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (Priority != null)
                    hashCode = hashCode * 59 + Priority.GetHashCode();
                if (TaskToDomain != null)
                    hashCode = hashCode * 59 + TaskToDomain.GetHashCode();
                if (Version != null)
                    hashCode = hashCode * 59 + Version.GetHashCode();
                if (WorkflowDef != null)
                    hashCode = hashCode * 59 + WorkflowDef.GetHashCode();
                return hashCode;
            }
        }
    }
}