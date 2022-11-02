
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
    /// WebhookExecutionHistory
    /// </summary>
    [DataContract]
        public partial class WebhookExecutionHistory :  IEquatable<WebhookExecutionHistory>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookExecutionHistory" /> class.
        /// </summary>
        /// <param name="eventId">eventId.</param>
        /// <param name="matched">matched.</param>
        /// <param name="timeStamp">timeStamp.</param>
        /// <param name="workflowIds">workflowIds.</param>
        public WebhookExecutionHistory(string eventId = default(string), bool? matched = default(bool?), long? timeStamp = default(long?), List<string> workflowIds = default(List<string>))
        {
            this.EventId = eventId;
            this.Matched = matched;
            this.TimeStamp = timeStamp;
            this.WorkflowIds = workflowIds;
        }
        
        /// <summary>
        /// Gets or Sets EventId
        /// </summary>
        [DataMember(Name="eventId", EmitDefaultValue=false)]
        public string EventId { get; set; }

        /// <summary>
        /// Gets or Sets Matched
        /// </summary>
        [DataMember(Name="matched", EmitDefaultValue=false)]
        public bool? Matched { get; set; }

        /// <summary>
        /// Gets or Sets TimeStamp
        /// </summary>
        [DataMember(Name="timeStamp", EmitDefaultValue=false)]
        public long? TimeStamp { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowIds
        /// </summary>
        [DataMember(Name="workflowIds", EmitDefaultValue=false)]
        public List<string> WorkflowIds { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WebhookExecutionHistory {\n");
            sb.Append("  EventId: ").Append(EventId).Append("\n");
            sb.Append("  Matched: ").Append(Matched).Append("\n");
            sb.Append("  TimeStamp: ").Append(TimeStamp).Append("\n");
            sb.Append("  WorkflowIds: ").Append(WorkflowIds).Append("\n");
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
            return this.Equals(input as WebhookExecutionHistory);
        }

        /// <summary>
        /// Returns true if WebhookExecutionHistory instances are equal
        /// </summary>
        /// <param name="input">Instance of WebhookExecutionHistory to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WebhookExecutionHistory input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.EventId == input.EventId ||
                    (this.EventId != null &&
                    this.EventId.Equals(input.EventId))
                ) && 
                (
                    this.Matched == input.Matched ||
                    (this.Matched != null &&
                    this.Matched.Equals(input.Matched))
                ) && 
                (
                    this.TimeStamp == input.TimeStamp ||
                    (this.TimeStamp != null &&
                    this.TimeStamp.Equals(input.TimeStamp))
                ) && 
                (
                    this.WorkflowIds == input.WorkflowIds ||
                    this.WorkflowIds != null &&
                    input.WorkflowIds != null &&
                    this.WorkflowIds.SequenceEqual(input.WorkflowIds)
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
                if (this.EventId != null)
                    hashCode = hashCode * 59 + this.EventId.GetHashCode();
                if (this.Matched != null)
                    hashCode = hashCode * 59 + this.Matched.GetHashCode();
                if (this.TimeStamp != null)
                    hashCode = hashCode * 59 + this.TimeStamp.GetHashCode();
                if (this.WorkflowIds != null)
                    hashCode = hashCode * 59 + this.WorkflowIds.GetHashCode();
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
