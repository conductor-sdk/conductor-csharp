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
    /// HumanTaskSearch
    /// </summary>
    [DataContract]
    public partial class HumanTaskSearch : IEquatable<HumanTaskSearch>, IValidatableObject
    {
        /// <summary>
        /// Defines SearchType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SearchTypeEnum
        {
            /// <summary>
            /// Enum ADMIN for value: ADMIN
            /// </summary>
            [EnumMember(Value = "ADMIN")]
            ADMIN = 1,
            /// <summary>
            /// Enum INBOX for value: INBOX
            /// </summary>
            [EnumMember(Value = "INBOX")]
            INBOX = 2
        }
        /// <summary>
        /// Gets or Sets SearchType
        /// </summary>
        [DataMember(Name = "searchType", EmitDefaultValue = false)]
        public SearchTypeEnum? SearchType { get; set; }
        /// <summary>
        /// Defines States
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatesEnum
        {
            /// <summary>
            /// Enum PENDING for value: PENDING
            /// </summary>
            [EnumMember(Value = "PENDING")]
            PENDING = 1,
            /// <summary>
            /// Enum ASSIGNED for value: ASSIGNED
            /// </summary>
            [EnumMember(Value = "ASSIGNED")]
            ASSIGNED = 2,
            /// <summary>
            /// Enum INPROGRESS for value: IN_PROGRESS
            /// </summary>
            [EnumMember(Value = "IN_PROGRESS")]
            INPROGRESS = 3,
            /// <summary>
            /// Enum COMPLETED for value: COMPLETED
            /// </summary>
            [EnumMember(Value = "COMPLETED")]
            COMPLETED = 4,
            /// <summary>
            /// Enum TIMEDOUT for value: TIMED_OUT
            /// </summary>
            [EnumMember(Value = "TIMED_OUT")]
            TIMEDOUT = 5,
            /// <summary>
            /// Enum DELETED for value: DELETED
            /// </summary>
            [EnumMember(Value = "DELETED")]
            DELETED = 6
        }
        /// <summary>
        /// Gets or Sets States
        /// </summary>
        [DataMember(Name = "states", EmitDefaultValue = false)]
        public List<StatesEnum> States { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskSearch" /> class.
        /// </summary>
        /// <param name="assignees">assignees.</param>
        /// <param name="claimants">claimants.</param>
        /// <param name="definitionNames">definitionNames.</param>
        /// <param name="displayNames">displayNames.</param>
        /// <param name="fullTextQuery">fullTextQuery.</param>
        /// <param name="searchType">searchType.</param>
        /// <param name="size">size.</param>
        /// <param name="start">start.</param>
        /// <param name="states">states.</param>
        /// <param name="taskInputQuery">taskInputQuery.</param>
        /// <param name="taskOutputQuery">taskOutputQuery.</param>
        /// <param name="taskRefNames">taskRefNames.</param>
        /// <param name="updateEndTime">updateEndTime.</param>
        /// <param name="updateStartTime">updateStartTime.</param>
        /// <param name="workflowNames">workflowNames.</param>
        public HumanTaskSearch(List<HumanTaskUser> assignees = default(List<HumanTaskUser>), List<HumanTaskUser> claimants = default(List<HumanTaskUser>), List<string> definitionNames = default(List<string>), List<string> displayNames = default(List<string>), string fullTextQuery = default(string), SearchTypeEnum? searchType = default(SearchTypeEnum?), int? size = default(int?), int? start = default(int?), List<StatesEnum> states = default(List<StatesEnum>), string taskInputQuery = default(string), string taskOutputQuery = default(string), List<string> taskRefNames = default(List<string>), long? updateEndTime = default(long?), long? updateStartTime = default(long?), List<string> workflowNames = default(List<string>))
        {
            this.Assignees = assignees;
            this.Claimants = claimants;
            this.DefinitionNames = definitionNames;
            this.DisplayNames = displayNames;
            this.FullTextQuery = fullTextQuery;
            this.SearchType = searchType;
            this.Size = size;
            this.Start = start;
            this.States = states;
            this.TaskInputQuery = taskInputQuery;
            this.TaskOutputQuery = taskOutputQuery;
            this.TaskRefNames = taskRefNames;
            this.UpdateEndTime = updateEndTime;
            this.UpdateStartTime = updateStartTime;
            this.WorkflowNames = workflowNames;
        }

        /// <summary>
        /// Gets or Sets Assignees
        /// </summary>
        [DataMember(Name = "assignees", EmitDefaultValue = false)]
        public List<HumanTaskUser> Assignees { get; set; }

        /// <summary>
        /// Gets or Sets Claimants
        /// </summary>
        [DataMember(Name = "claimants", EmitDefaultValue = false)]
        public List<HumanTaskUser> Claimants { get; set; }

        /// <summary>
        /// Gets or Sets DefinitionNames
        /// </summary>
        [DataMember(Name = "definitionNames", EmitDefaultValue = false)]
        public List<string> DefinitionNames { get; set; }

        /// <summary>
        /// Gets or Sets DisplayNames
        /// </summary>
        [DataMember(Name = "displayNames", EmitDefaultValue = false)]
        public List<string> DisplayNames { get; set; }

        /// <summary>
        /// Gets or Sets FullTextQuery
        /// </summary>
        [DataMember(Name = "fullTextQuery", EmitDefaultValue = false)]
        public string FullTextQuery { get; set; }


        /// <summary>
        /// Gets or Sets Size
        /// </summary>
        [DataMember(Name = "size", EmitDefaultValue = false)]
        public int? Size { get; set; }

        /// <summary>
        /// Gets or Sets Start
        /// </summary>
        [DataMember(Name = "start", EmitDefaultValue = false)]
        public int? Start { get; set; }


        /// <summary>
        /// Gets or Sets TaskInputQuery
        /// </summary>
        [DataMember(Name = "taskInputQuery", EmitDefaultValue = false)]
        public string TaskInputQuery { get; set; }

        /// <summary>
        /// Gets or Sets TaskOutputQuery
        /// </summary>
        [DataMember(Name = "taskOutputQuery", EmitDefaultValue = false)]
        public string TaskOutputQuery { get; set; }

        /// <summary>
        /// Gets or Sets TaskRefNames
        /// </summary>
        [DataMember(Name = "taskRefNames", EmitDefaultValue = false)]
        public List<string> TaskRefNames { get; set; }

        /// <summary>
        /// Gets or Sets UpdateEndTime
        /// </summary>
        [DataMember(Name = "updateEndTime", EmitDefaultValue = false)]
        public long? UpdateEndTime { get; set; }

        /// <summary>
        /// Gets or Sets UpdateStartTime
        /// </summary>
        [DataMember(Name = "updateStartTime", EmitDefaultValue = false)]
        public long? UpdateStartTime { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowNames
        /// </summary>
        [DataMember(Name = "workflowNames", EmitDefaultValue = false)]
        public List<string> WorkflowNames { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HumanTaskSearch {\n");
            sb.Append("  Assignees: ").Append(Assignees).Append("\n");
            sb.Append("  Claimants: ").Append(Claimants).Append("\n");
            sb.Append("  DefinitionNames: ").Append(DefinitionNames).Append("\n");
            sb.Append("  DisplayNames: ").Append(DisplayNames).Append("\n");
            sb.Append("  FullTextQuery: ").Append(FullTextQuery).Append("\n");
            sb.Append("  SearchType: ").Append(SearchType).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
            sb.Append("  Start: ").Append(Start).Append("\n");
            sb.Append("  States: ").Append(States).Append("\n");
            sb.Append("  TaskInputQuery: ").Append(TaskInputQuery).Append("\n");
            sb.Append("  TaskOutputQuery: ").Append(TaskOutputQuery).Append("\n");
            sb.Append("  TaskRefNames: ").Append(TaskRefNames).Append("\n");
            sb.Append("  UpdateEndTime: ").Append(UpdateEndTime).Append("\n");
            sb.Append("  UpdateStartTime: ").Append(UpdateStartTime).Append("\n");
            sb.Append("  WorkflowNames: ").Append(WorkflowNames).Append("\n");
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
            return this.Equals(input as HumanTaskSearch);
        }

        /// <summary>
        /// Returns true if HumanTaskSearch instances are equal
        /// </summary>
        /// <param name="input">Instance of HumanTaskSearch to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HumanTaskSearch input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Assignees == input.Assignees ||
                    this.Assignees != null &&
                    input.Assignees != null &&
                    this.Assignees.SequenceEqual(input.Assignees)
                ) &&
                (
                    this.Claimants == input.Claimants ||
                    this.Claimants != null &&
                    input.Claimants != null &&
                    this.Claimants.SequenceEqual(input.Claimants)
                ) &&
                (
                    this.DefinitionNames == input.DefinitionNames ||
                    this.DefinitionNames != null &&
                    input.DefinitionNames != null &&
                    this.DefinitionNames.SequenceEqual(input.DefinitionNames)
                ) &&
                (
                    this.DisplayNames == input.DisplayNames ||
                    this.DisplayNames != null &&
                    input.DisplayNames != null &&
                    this.DisplayNames.SequenceEqual(input.DisplayNames)
                ) &&
                (
                    this.FullTextQuery == input.FullTextQuery ||
                    (this.FullTextQuery != null &&
                    this.FullTextQuery.Equals(input.FullTextQuery))
                ) &&
                (
                    this.SearchType == input.SearchType ||
                    (this.SearchType != null &&
                    this.SearchType.Equals(input.SearchType))
                ) &&
                (
                    this.Size == input.Size ||
                    (this.Size != null &&
                    this.Size.Equals(input.Size))
                ) &&
                (
                    this.Start == input.Start ||
                    (this.Start != null &&
                    this.Start.Equals(input.Start))
                ) &&
                (
                    this.States == input.States ||
                    this.States != null &&
                    input.States != null &&
                    this.States.SequenceEqual(input.States)
                ) &&
                (
                    this.TaskInputQuery == input.TaskInputQuery ||
                    (this.TaskInputQuery != null &&
                    this.TaskInputQuery.Equals(input.TaskInputQuery))
                ) &&
                (
                    this.TaskOutputQuery == input.TaskOutputQuery ||
                    (this.TaskOutputQuery != null &&
                    this.TaskOutputQuery.Equals(input.TaskOutputQuery))
                ) &&
                (
                    this.TaskRefNames == input.TaskRefNames ||
                    this.TaskRefNames != null &&
                    input.TaskRefNames != null &&
                    this.TaskRefNames.SequenceEqual(input.TaskRefNames)
                ) &&
                (
                    this.UpdateEndTime == input.UpdateEndTime ||
                    (this.UpdateEndTime != null &&
                    this.UpdateEndTime.Equals(input.UpdateEndTime))
                ) &&
                (
                    this.UpdateStartTime == input.UpdateStartTime ||
                    (this.UpdateStartTime != null &&
                    this.UpdateStartTime.Equals(input.UpdateStartTime))
                ) &&
                (
                    this.WorkflowNames == input.WorkflowNames ||
                    this.WorkflowNames != null &&
                    input.WorkflowNames != null &&
                    this.WorkflowNames.SequenceEqual(input.WorkflowNames)
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
                if (this.Assignees != null)
                    hashCode = hashCode * 59 + this.Assignees.GetHashCode();
                if (this.Claimants != null)
                    hashCode = hashCode * 59 + this.Claimants.GetHashCode();
                if (this.DefinitionNames != null)
                    hashCode = hashCode * 59 + this.DefinitionNames.GetHashCode();
                if (this.DisplayNames != null)
                    hashCode = hashCode * 59 + this.DisplayNames.GetHashCode();
                if (this.FullTextQuery != null)
                    hashCode = hashCode * 59 + this.FullTextQuery.GetHashCode();
                if (this.SearchType != null)
                    hashCode = hashCode * 59 + this.SearchType.GetHashCode();
                if (this.Size != null)
                    hashCode = hashCode * 59 + this.Size.GetHashCode();
                if (this.Start != null)
                    hashCode = hashCode * 59 + this.Start.GetHashCode();
                if (this.States != null)
                    hashCode = hashCode * 59 + this.States.GetHashCode();
                if (this.TaskInputQuery != null)
                    hashCode = hashCode * 59 + this.TaskInputQuery.GetHashCode();
                if (this.TaskOutputQuery != null)
                    hashCode = hashCode * 59 + this.TaskOutputQuery.GetHashCode();
                if (this.TaskRefNames != null)
                    hashCode = hashCode * 59 + this.TaskRefNames.GetHashCode();
                if (this.UpdateEndTime != null)
                    hashCode = hashCode * 59 + this.UpdateEndTime.GetHashCode();
                if (this.UpdateStartTime != null)
                    hashCode = hashCode * 59 + this.UpdateStartTime.GetHashCode();
                if (this.WorkflowNames != null)
                    hashCode = hashCode * 59 + this.WorkflowNames.GetHashCode();
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
