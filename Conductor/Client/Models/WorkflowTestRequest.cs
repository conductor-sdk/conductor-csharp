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
    /// WorkflowTestRequest
    /// </summary>
    [DataContract]
    public partial class WorkflowTestRequest : IEquatable<WorkflowTestRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowTestRequest" /> class.
        /// </summary>
        /// <param name="correlationId">correlationId.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="externalInputPayloadStoragePath">externalInputPayloadStoragePath.</param>
        /// <param name="input">input.</param>
        /// <param name="name">name (required).</param>
        /// <param name="priority">priority.</param>
        /// <param name="subWorkflowTestRequest">subWorkflowTestRequest.</param>
        /// <param name="taskRefToMockOutput">taskRefToMockOutput.</param>
        /// <param name="taskToDomain">taskToDomain.</param>
        /// <param name="version">version.</param>
        /// <param name="workflowDef">workflowDef.</param>
        public WorkflowTestRequest(string correlationId = default(string), string createdBy = default(string), string externalInputPayloadStoragePath = default(string), Dictionary<string, Object> input = default(Dictionary<string, Object>), string name = default(string), int? priority = default(int?), Dictionary<string, WorkflowTestRequest> subWorkflowTestRequest = default(Dictionary<string, WorkflowTestRequest>), Dictionary<string, List<TaskMock>> taskRefToMockOutput = default(Dictionary<string, List<TaskMock>>), Dictionary<string, string> taskToDomain = default(Dictionary<string, string>), int? version = default(int?), WorkflowDef workflowDef = default(WorkflowDef))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for WorkflowTestRequest and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            this.CorrelationId = correlationId;
            this.CreatedBy = createdBy;
            this.ExternalInputPayloadStoragePath = externalInputPayloadStoragePath;
            this.Input = input;
            this.Priority = priority;
            this.SubWorkflowTestRequest = subWorkflowTestRequest;
            this.TaskRefToMockOutput = taskRefToMockOutput;
            this.TaskToDomain = taskToDomain;
            this.Version = version;
            this.WorkflowDef = workflowDef;
        }

        /// <summary>
        /// Gets or Sets CorrelationId
        /// </summary>
        [DataMember(Name = "correlationId", EmitDefaultValue = false)]
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets ExternalInputPayloadStoragePath
        /// </summary>
        [DataMember(Name = "externalInputPayloadStoragePath", EmitDefaultValue = false)]
        public string ExternalInputPayloadStoragePath { get; set; }

        /// <summary>
        /// Gets or Sets Input
        /// </summary>
        [DataMember(Name = "input", EmitDefaultValue = false)]
        public Dictionary<string, Object> Input { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Priority
        /// </summary>
        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public int? Priority { get; set; }

        /// <summary>
        /// Gets or Sets SubWorkflowTestRequest
        /// </summary>
        [DataMember(Name = "subWorkflowTestRequest", EmitDefaultValue = false)]
        public Dictionary<string, WorkflowTestRequest> SubWorkflowTestRequest { get; set; }

        /// <summary>
        /// Gets or Sets TaskRefToMockOutput
        /// </summary>
        [DataMember(Name = "taskRefToMockOutput", EmitDefaultValue = false)]
        public Dictionary<string, List<TaskMock>> TaskRefToMockOutput { get; set; }

        /// <summary>
        /// Gets or Sets TaskToDomain
        /// </summary>
        [DataMember(Name = "taskToDomain", EmitDefaultValue = false)]
        public Dictionary<string, string> TaskToDomain { get; set; }

        /// <summary>
        /// Gets or Sets Version
        /// </summary>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public int? Version { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowDef
        /// </summary>
        [DataMember(Name = "workflowDef", EmitDefaultValue = false)]
        public WorkflowDef WorkflowDef { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WorkflowTestRequest {\n");
            sb.Append("  CorrelationId: ").Append(CorrelationId).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  ExternalInputPayloadStoragePath: ").Append(ExternalInputPayloadStoragePath).Append("\n");
            sb.Append("  Input: ").Append(Input).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("  SubWorkflowTestRequest: ").Append(SubWorkflowTestRequest).Append("\n");
            sb.Append("  TaskRefToMockOutput: ").Append(TaskRefToMockOutput).Append("\n");
            sb.Append("  TaskToDomain: ").Append(TaskToDomain).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  WorkflowDef: ").Append(WorkflowDef).Append("\n");
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
            return this.Equals(input as WorkflowTestRequest);
        }

        /// <summary>
        /// Returns true if WorkflowTestRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of WorkflowTestRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WorkflowTestRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    this.CorrelationId == input.CorrelationId ||
                    (this.CorrelationId != null &&
                    this.CorrelationId.Equals(input.CorrelationId))
                ) &&
                (
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) &&
                (
                    this.ExternalInputPayloadStoragePath == input.ExternalInputPayloadStoragePath ||
                    (this.ExternalInputPayloadStoragePath != null &&
                    this.ExternalInputPayloadStoragePath.Equals(input.ExternalInputPayloadStoragePath))
                ) &&
                (
                    this.Input == input.Input ||
                    this.Input != null &&
                    input.Input != null &&
                    this.Input.SequenceEqual(input.Input)
                ) &&
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.Priority == input.Priority ||
                    (this.Priority != null &&
                    this.Priority.Equals(input.Priority))
                ) &&
                (
                    this.SubWorkflowTestRequest == input.SubWorkflowTestRequest ||
                    this.SubWorkflowTestRequest != null &&
                    input.SubWorkflowTestRequest != null &&
                    this.SubWorkflowTestRequest.SequenceEqual(input.SubWorkflowTestRequest)
                ) &&
                (
                    this.TaskRefToMockOutput == input.TaskRefToMockOutput ||
                    this.TaskRefToMockOutput != null &&
                    input.TaskRefToMockOutput != null &&
                    this.TaskRefToMockOutput.SequenceEqual(input.TaskRefToMockOutput)
                ) &&
                (
                    this.TaskToDomain == input.TaskToDomain ||
                    this.TaskToDomain != null &&
                    input.TaskToDomain != null &&
                    this.TaskToDomain.SequenceEqual(input.TaskToDomain)
                ) &&
                (
                    this.Version == input.Version ||
                    (this.Version != null &&
                    this.Version.Equals(input.Version))
                ) &&
                (
                    this.WorkflowDef == input.WorkflowDef ||
                    (this.WorkflowDef != null &&
                    this.WorkflowDef.Equals(input.WorkflowDef))
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
                if (this.CorrelationId != null)
                    hashCode = hashCode * 59 + this.CorrelationId.GetHashCode();
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.ExternalInputPayloadStoragePath != null)
                    hashCode = hashCode * 59 + this.ExternalInputPayloadStoragePath.GetHashCode();
                if (this.Input != null)
                    hashCode = hashCode * 59 + this.Input.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Priority != null)
                    hashCode = hashCode * 59 + this.Priority.GetHashCode();
                if (this.SubWorkflowTestRequest != null)
                    hashCode = hashCode * 59 + this.SubWorkflowTestRequest.GetHashCode();
                if (this.TaskRefToMockOutput != null)
                    hashCode = hashCode * 59 + this.TaskRefToMockOutput.GetHashCode();
                if (this.TaskToDomain != null)
                    hashCode = hashCode * 59 + this.TaskToDomain.GetHashCode();
                if (this.Version != null)
                    hashCode = hashCode * 59 + this.Version.GetHashCode();
                if (this.WorkflowDef != null)
                    hashCode = hashCode * 59 + this.WorkflowDef.GetHashCode();
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
