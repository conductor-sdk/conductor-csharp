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
using System.Runtime.Serialization;
using System.Text;

namespace Conductor.Client.Models
{
    /// <summary>
    /// EventLog
    /// </summary>
    [DataContract]
    public partial class EventLog : IEquatable<EventLog>, IValidatableObject
    {
        /// <summary>
        /// Defines EventType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EventTypeEnum
        {
            /// <summary>
            /// Enum SEND for value: SEND
            /// </summary>
            [EnumMember(Value = "SEND")]
            SEND = 1,
            /// <summary>
            /// Enum RECEIVE for value: RECEIVE
            /// </summary>
            [EnumMember(Value = "RECEIVE")]
            RECEIVE = 2
        }
        /// <summary>
        /// Gets or Sets EventType
        /// </summary>
        [DataMember(Name = "eventType", EmitDefaultValue = false)]
        public EventTypeEnum? EventType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventLog" /> class.
        /// </summary>
        /// <param name="createdAt">createdAt.</param>
        /// <param name="_event">_event.</param>
        /// <param name="eventType">eventType.</param>
        /// <param name="handlerName">handlerName.</param>
        /// <param name="id">id.</param>
        /// <param name="taskId">taskId.</param>
        /// <param name="workerId">workerId.</param>
        public EventLog(long? createdAt = default(long?), string _event = default(string), EventTypeEnum? eventType = default(EventTypeEnum?), string handlerName = default(string), string id = default(string), string taskId = default(string), string workerId = default(string))
        {
            this.CreatedAt = createdAt;
            this._Event = _event;
            this.EventType = eventType;
            this.HandlerName = handlerName;
            this.Id = id;
            this.TaskId = taskId;
            this.WorkerId = workerId;
        }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public long? CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets _Event
        /// </summary>
        [DataMember(Name = "event", EmitDefaultValue = false)]
        public string _Event { get; set; }

        /// <summary>
        /// Gets or Sets HandlerName
        /// </summary>
        [DataMember(Name = "handlerName", EmitDefaultValue = false)]
        public string HandlerName { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets TaskId
        /// </summary>
        [DataMember(Name = "taskId", EmitDefaultValue = false)]
        public string TaskId { get; set; }

        /// <summary>
        /// Gets or Sets WorkerId
        /// </summary>
        [DataMember(Name = "workerId", EmitDefaultValue = false)]
        public string WorkerId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EventLog {\n");
            sb.Append(" CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append(" _Event: ").Append(_Event).Append("\n");
            sb.Append(" EventType: ").Append(EventType).Append("\n");
            sb.Append(" HandlerName: ").Append(HandlerName).Append("\n");
            sb.Append(" Id: ").Append(Id).Append("\n");
            sb.Append(" TaskId: ").Append(TaskId).Append("\n");
            sb.Append(" WorkerId: ").Append(WorkerId).Append("\n");
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
            return this.Equals(input as EventLog);
        }

        /// <summary>
        /// Returns true if EventLog instances are equal
        /// </summary>
        /// <param name="input">Instance of EventLog to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EventLog input)
        {
            if (input == null)
                return false;

            return
            (
            this.CreatedAt == input.CreatedAt ||
            (this.CreatedAt != null &&
            this.CreatedAt.Equals(input.CreatedAt))
            ) &&
            (
            this._Event == input._Event ||
            (this._Event != null &&
            this._Event.Equals(input._Event))
            ) &&
            (
            this.EventType == input.EventType ||
            (this.EventType != null &&
            this.EventType.Equals(input.EventType))
            ) &&
            (
            this.HandlerName == input.HandlerName ||
            (this.HandlerName != null &&
            this.HandlerName.Equals(input.HandlerName))
            ) &&
            (
            this.Id == input.Id ||
            (this.Id != null &&
            this.Id.Equals(input.Id))
            ) &&
            (
            this.TaskId == input.TaskId ||
            (this.TaskId != null &&
            this.TaskId.Equals(input.TaskId))
            ) &&
            (
            this.WorkerId == input.WorkerId ||
            (this.WorkerId != null &&
            this.WorkerId.Equals(input.WorkerId))
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
                if (this.CreatedAt != null)
                    hashCode = hashCode * 59 + this.CreatedAt.GetHashCode();
                if (this._Event != null)
                    hashCode = hashCode * 59 + this._Event.GetHashCode();
                if (this.EventType != null)
                    hashCode = hashCode * 59 + this.EventType.GetHashCode();
                if (this.HandlerName != null)
                    hashCode = hashCode * 59 + this.HandlerName.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.TaskId != null)
                    hashCode = hashCode * 59 + this.TaskId.GetHashCode();
                if (this.WorkerId != null)
                    hashCode = hashCode * 59 + this.WorkerId.GetHashCode();
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
