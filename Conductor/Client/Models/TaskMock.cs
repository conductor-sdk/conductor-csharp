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
    /// TaskMock
    /// </summary>
    [DataContract]
    public partial class TaskMock : IEquatable<TaskMock>, IValidatableObject
    {
        /// <summary>
        /// Defines Status
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum INPROGRESS for value: IN_PROGRESS
            /// </summary>
            [EnumMember(Value = "IN_PROGRESS")]
            INPROGRESS = 1,
            /// <summary>
            /// Enum FAILED for value: FAILED
            /// </summary>
            [EnumMember(Value = "FAILED")]
            FAILED = 2,
            /// <summary>
            /// Enum FAILEDWITHTERMINALERROR for value: FAILED_WITH_TERMINAL_ERROR
            /// </summary>
            [EnumMember(Value = "FAILED_WITH_TERMINAL_ERROR")]
            FAILEDWITHTERMINALERROR = 3,
            /// <summary>
            /// Enum COMPLETED for value: COMPLETED
            /// </summary>
            [EnumMember(Value = "COMPLETED")]
            COMPLETED = 4
        }
        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskMock" /> class.
        /// </summary>
        /// <param name="executionTime">executionTime.</param>
        /// <param name="output">output.</param>
        /// <param name="queueWaitTime">queueWaitTime.</param>
        /// <param name="status">status.</param>
        public TaskMock(long? executionTime = default(long?), Dictionary<string, Object> output = default(Dictionary<string, Object>), long? queueWaitTime = default(long?), StatusEnum? status = default(StatusEnum?))
        {
            this.ExecutionTime = executionTime;
            this.Output = output;
            this.QueueWaitTime = queueWaitTime;
            this.Status = status;
        }

        /// <summary>
        /// Gets or Sets ExecutionTime
        /// </summary>
        [DataMember(Name = "executionTime", EmitDefaultValue = false)]
        public long? ExecutionTime { get; set; }

        /// <summary>
        /// Gets or Sets Output
        /// </summary>
        [DataMember(Name = "output", EmitDefaultValue = false)]
        public Dictionary<string, Object> Output { get; set; }

        /// <summary>
        /// Gets or Sets QueueWaitTime
        /// </summary>
        [DataMember(Name = "queueWaitTime", EmitDefaultValue = false)]
        public long? QueueWaitTime { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TaskMock {\n");
            sb.Append("  ExecutionTime: ").Append(ExecutionTime).Append("\n");
            sb.Append("  Output: ").Append(Output).Append("\n");
            sb.Append("  QueueWaitTime: ").Append(QueueWaitTime).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
            return this.Equals(input as TaskMock);
        }

        /// <summary>
        /// Returns true if TaskMock instances are equal
        /// </summary>
        /// <param name="input">Instance of TaskMock to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TaskMock input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ExecutionTime == input.ExecutionTime ||
                    (this.ExecutionTime != null &&
                    this.ExecutionTime.Equals(input.ExecutionTime))
                ) &&
                (
                    this.Output == input.Output ||
                    this.Output != null &&
                    input.Output != null &&
                    this.Output.SequenceEqual(input.Output)
                ) &&
                (
                    this.QueueWaitTime == input.QueueWaitTime ||
                    (this.QueueWaitTime != null &&
                    this.QueueWaitTime.Equals(input.QueueWaitTime))
                ) &&
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
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
                if (this.ExecutionTime != null)
                    hashCode = hashCode * 59 + this.ExecutionTime.GetHashCode();
                if (this.Output != null)
                    hashCode = hashCode * 59 + this.Output.GetHashCode();
                if (this.QueueWaitTime != null)
                    hashCode = hashCode * 59 + this.QueueWaitTime.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
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
