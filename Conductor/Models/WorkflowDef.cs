
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
    /// WorkflowDef
    /// </summary>
    [DataContract]
        public partial class WorkflowDef :  IEquatable<WorkflowDef>, IValidatableObject
    {
        /// <summary>
        /// Defines TimeoutPolicy
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum TimeoutPolicyEnum
        {
            /// <summary>
            /// Enum TIMEOUTWF for value: TIME_OUT_WF
            /// </summary>
            [EnumMember(Value = "TIME_OUT_WF")]
            TIMEOUTWF = 1,
            /// <summary>
            /// Enum ALERTONLY for value: ALERT_ONLY
            /// </summary>
            [EnumMember(Value = "ALERT_ONLY")]
            ALERTONLY = 2        }
        /// <summary>
        /// Gets or Sets TimeoutPolicy
        /// </summary>
        [DataMember(Name="timeoutPolicy", EmitDefaultValue=false)]
        public TimeoutPolicyEnum? TimeoutPolicy { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowDef" /> class.
        /// </summary>
        /// <param name="createTime">createTime.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="description">description.</param>
        /// <param name="failureWorkflow">failureWorkflow.</param>
        /// <param name="inputParameters">inputParameters.</param>
        /// <param name="inputTemplate">inputTemplate.</param>
        /// <param name="name">name (required).</param>
        /// <param name="outputParameters">outputParameters.</param>
        /// <param name="ownerApp">ownerApp.</param>
        /// <param name="ownerEmail">ownerEmail.</param>
        /// <param name="restartable">restartable.</param>
        /// <param name="schemaVersion">schemaVersion.</param>
        /// <param name="tasks">tasks (required).</param>
        /// <param name="timeoutPolicy">timeoutPolicy.</param>
        /// <param name="timeoutSeconds">timeoutSeconds (required).</param>
        /// <param name="updateTime">updateTime.</param>
        /// <param name="updatedBy">updatedBy.</param>
        /// <param name="variables">variables.</param>
        /// <param name="version">version.</param>
        /// <param name="workflowStatusListenerEnabled">workflowStatusListenerEnabled.</param>
        public WorkflowDef(long? createTime = default(long?), string createdBy = default(string), string description = default(string), string failureWorkflow = default(string), List<string> inputParameters = default(List<string>), Dictionary<string, Object> inputTemplate = default(Dictionary<string, Object>), string name = default(string), Dictionary<string, Object> outputParameters = default(Dictionary<string, Object>), string ownerApp = default(string), string ownerEmail = default(string), bool? restartable = default(bool?), int? schemaVersion = default(int?), List<WorkflowTask> tasks = default(List<WorkflowTask>), TimeoutPolicyEnum? timeoutPolicy = default(TimeoutPolicyEnum?), long? timeoutSeconds = default(long?), long? updateTime = default(long?), string updatedBy = default(string), Dictionary<string, Object> variables = default(Dictionary<string, Object>), int? version = default(int?), bool? workflowStatusListenerEnabled = default(bool?))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for WorkflowDef and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            // to ensure "tasks" is required (not null)
            if (tasks == null)
            {
                throw new InvalidDataException("tasks is a required property for WorkflowDef and cannot be null");
            }
            else
            {
                this.Tasks = tasks;
            }
            // to ensure "timeoutSeconds" is required (not null)
            if (timeoutSeconds == null)
            {
                throw new InvalidDataException("timeoutSeconds is a required property for WorkflowDef and cannot be null");
            }
            else
            {
                this.TimeoutSeconds = timeoutSeconds;
            }
            this.CreateTime = createTime;
            this.CreatedBy = createdBy;
            this.Description = description;
            this.FailureWorkflow = failureWorkflow;
            this.InputParameters = inputParameters;
            this.InputTemplate = inputTemplate;
            this.OutputParameters = outputParameters;
            this.OwnerApp = ownerApp;
            this.OwnerEmail = ownerEmail;
            this.Restartable = restartable;
            this.SchemaVersion = schemaVersion;
            this.TimeoutPolicy = timeoutPolicy;
            this.UpdateTime = updateTime;
            this.UpdatedBy = updatedBy;
            this.Variables = variables;
            this.Version = version;
            this.WorkflowStatusListenerEnabled = workflowStatusListenerEnabled;
        }
        
        /// <summary>
        /// Gets or Sets CreateTime
        /// </summary>
        [DataMember(Name="createTime", EmitDefaultValue=false)]
        public long? CreateTime { get; set; }

        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets FailureWorkflow
        /// </summary>
        [DataMember(Name="failureWorkflow", EmitDefaultValue=false)]
        public string FailureWorkflow { get; set; }

        /// <summary>
        /// Gets or Sets InputParameters
        /// </summary>
        [DataMember(Name="inputParameters", EmitDefaultValue=false)]
        public List<string> InputParameters { get; set; }

        /// <summary>
        /// Gets or Sets InputTemplate
        /// </summary>
        [DataMember(Name="inputTemplate", EmitDefaultValue=false)]
        public Dictionary<string, Object> InputTemplate { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets OutputParameters
        /// </summary>
        [DataMember(Name="outputParameters", EmitDefaultValue=false)]
        public Dictionary<string, Object> OutputParameters { get; set; }

        /// <summary>
        /// Gets or Sets OwnerApp
        /// </summary>
        [DataMember(Name="ownerApp", EmitDefaultValue=false)]
        public string OwnerApp { get; set; }

        /// <summary>
        /// Gets or Sets OwnerEmail
        /// </summary>
        [DataMember(Name="ownerEmail", EmitDefaultValue=false)]
        public string OwnerEmail { get; set; }

        /// <summary>
        /// Gets or Sets Restartable
        /// </summary>
        [DataMember(Name="restartable", EmitDefaultValue=false)]
        public bool? Restartable { get; set; }

        /// <summary>
        /// Gets or Sets SchemaVersion
        /// </summary>
        [DataMember(Name="schemaVersion", EmitDefaultValue=false)]
        public int? SchemaVersion { get; set; }

        /// <summary>
        /// Gets or Sets Tasks
        /// </summary>
        [DataMember(Name="tasks", EmitDefaultValue=false)]
        public List<WorkflowTask> Tasks { get; set; }


        /// <summary>
        /// Gets or Sets TimeoutSeconds
        /// </summary>
        [DataMember(Name="timeoutSeconds", EmitDefaultValue=false)]
        public long? TimeoutSeconds { get; set; }

        /// <summary>
        /// Gets or Sets UpdateTime
        /// </summary>
        [DataMember(Name="updateTime", EmitDefaultValue=false)]
        public long? UpdateTime { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedBy
        /// </summary>
        [DataMember(Name="updatedBy", EmitDefaultValue=false)]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or Sets Variables
        /// </summary>
        [DataMember(Name="variables", EmitDefaultValue=false)]
        public Dictionary<string, Object> Variables { get; set; }

        /// <summary>
        /// Gets or Sets Version
        /// </summary>
        [DataMember(Name="version", EmitDefaultValue=false)]
        public int? Version { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowStatusListenerEnabled
        /// </summary>
        [DataMember(Name="workflowStatusListenerEnabled", EmitDefaultValue=false)]
        public bool? WorkflowStatusListenerEnabled { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WorkflowDef {\n");
            sb.Append("  CreateTime: ").Append(CreateTime).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  FailureWorkflow: ").Append(FailureWorkflow).Append("\n");
            sb.Append("  InputParameters: ").Append(InputParameters).Append("\n");
            sb.Append("  InputTemplate: ").Append(InputTemplate).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OutputParameters: ").Append(OutputParameters).Append("\n");
            sb.Append("  OwnerApp: ").Append(OwnerApp).Append("\n");
            sb.Append("  OwnerEmail: ").Append(OwnerEmail).Append("\n");
            sb.Append("  Restartable: ").Append(Restartable).Append("\n");
            sb.Append("  SchemaVersion: ").Append(SchemaVersion).Append("\n");
            sb.Append("  Tasks: ").Append(Tasks).Append("\n");
            sb.Append("  TimeoutPolicy: ").Append(TimeoutPolicy).Append("\n");
            sb.Append("  TimeoutSeconds: ").Append(TimeoutSeconds).Append("\n");
            sb.Append("  UpdateTime: ").Append(UpdateTime).Append("\n");
            sb.Append("  UpdatedBy: ").Append(UpdatedBy).Append("\n");
            sb.Append("  Variables: ").Append(Variables).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  WorkflowStatusListenerEnabled: ").Append(WorkflowStatusListenerEnabled).Append("\n");
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
            return this.Equals(input as WorkflowDef);
        }

        /// <summary>
        /// Returns true if WorkflowDef instances are equal
        /// </summary>
        /// <param name="input">Instance of WorkflowDef to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WorkflowDef input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CreateTime == input.CreateTime ||
                    (this.CreateTime != null &&
                    this.CreateTime.Equals(input.CreateTime))
                ) && 
                (
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.FailureWorkflow == input.FailureWorkflow ||
                    (this.FailureWorkflow != null &&
                    this.FailureWorkflow.Equals(input.FailureWorkflow))
                ) && 
                (
                    this.InputParameters == input.InputParameters ||
                    this.InputParameters != null &&
                    input.InputParameters != null &&
                    this.InputParameters.SequenceEqual(input.InputParameters)
                ) && 
                (
                    this.InputTemplate == input.InputTemplate ||
                    this.InputTemplate != null &&
                    input.InputTemplate != null &&
                    this.InputTemplate.SequenceEqual(input.InputTemplate)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.OutputParameters == input.OutputParameters ||
                    this.OutputParameters != null &&
                    input.OutputParameters != null &&
                    this.OutputParameters.SequenceEqual(input.OutputParameters)
                ) && 
                (
                    this.OwnerApp == input.OwnerApp ||
                    (this.OwnerApp != null &&
                    this.OwnerApp.Equals(input.OwnerApp))
                ) && 
                (
                    this.OwnerEmail == input.OwnerEmail ||
                    (this.OwnerEmail != null &&
                    this.OwnerEmail.Equals(input.OwnerEmail))
                ) && 
                (
                    this.Restartable == input.Restartable ||
                    (this.Restartable != null &&
                    this.Restartable.Equals(input.Restartable))
                ) && 
                (
                    this.SchemaVersion == input.SchemaVersion ||
                    (this.SchemaVersion != null &&
                    this.SchemaVersion.Equals(input.SchemaVersion))
                ) && 
                (
                    this.Tasks == input.Tasks ||
                    this.Tasks != null &&
                    input.Tasks != null &&
                    this.Tasks.SequenceEqual(input.Tasks)
                ) && 
                (
                    this.TimeoutPolicy == input.TimeoutPolicy ||
                    (this.TimeoutPolicy != null &&
                    this.TimeoutPolicy.Equals(input.TimeoutPolicy))
                ) && 
                (
                    this.TimeoutSeconds == input.TimeoutSeconds ||
                    (this.TimeoutSeconds != null &&
                    this.TimeoutSeconds.Equals(input.TimeoutSeconds))
                ) && 
                (
                    this.UpdateTime == input.UpdateTime ||
                    (this.UpdateTime != null &&
                    this.UpdateTime.Equals(input.UpdateTime))
                ) && 
                (
                    this.UpdatedBy == input.UpdatedBy ||
                    (this.UpdatedBy != null &&
                    this.UpdatedBy.Equals(input.UpdatedBy))
                ) && 
                (
                    this.Variables == input.Variables ||
                    this.Variables != null &&
                    input.Variables != null &&
                    this.Variables.SequenceEqual(input.Variables)
                ) && 
                (
                    this.Version == input.Version ||
                    (this.Version != null &&
                    this.Version.Equals(input.Version))
                ) && 
                (
                    this.WorkflowStatusListenerEnabled == input.WorkflowStatusListenerEnabled ||
                    (this.WorkflowStatusListenerEnabled != null &&
                    this.WorkflowStatusListenerEnabled.Equals(input.WorkflowStatusListenerEnabled))
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
                if (this.CreateTime != null)
                    hashCode = hashCode * 59 + this.CreateTime.GetHashCode();
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.FailureWorkflow != null)
                    hashCode = hashCode * 59 + this.FailureWorkflow.GetHashCode();
                if (this.InputParameters != null)
                    hashCode = hashCode * 59 + this.InputParameters.GetHashCode();
                if (this.InputTemplate != null)
                    hashCode = hashCode * 59 + this.InputTemplate.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.OutputParameters != null)
                    hashCode = hashCode * 59 + this.OutputParameters.GetHashCode();
                if (this.OwnerApp != null)
                    hashCode = hashCode * 59 + this.OwnerApp.GetHashCode();
                if (this.OwnerEmail != null)
                    hashCode = hashCode * 59 + this.OwnerEmail.GetHashCode();
                if (this.Restartable != null)
                    hashCode = hashCode * 59 + this.Restartable.GetHashCode();
                if (this.SchemaVersion != null)
                    hashCode = hashCode * 59 + this.SchemaVersion.GetHashCode();
                if (this.Tasks != null)
                    hashCode = hashCode * 59 + this.Tasks.GetHashCode();
                if (this.TimeoutPolicy != null)
                    hashCode = hashCode * 59 + this.TimeoutPolicy.GetHashCode();
                if (this.TimeoutSeconds != null)
                    hashCode = hashCode * 59 + this.TimeoutSeconds.GetHashCode();
                if (this.UpdateTime != null)
                    hashCode = hashCode * 59 + this.UpdateTime.GetHashCode();
                if (this.UpdatedBy != null)
                    hashCode = hashCode * 59 + this.UpdatedBy.GetHashCode();
                if (this.Variables != null)
                    hashCode = hashCode * 59 + this.Variables.GetHashCode();
                if (this.Version != null)
                    hashCode = hashCode * 59 + this.Version.GetHashCode();
                if (this.WorkflowStatusListenerEnabled != null)
                    hashCode = hashCode * 59 + this.WorkflowStatusListenerEnabled.GetHashCode();
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
