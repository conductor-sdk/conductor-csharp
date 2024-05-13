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
using System.Linq;
using System.IO;
using Newtonsoft.Json.Converters;
using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Conductor.Client.Models
{
    /// <summary>
    /// UpsertGroupRequest
    /// </summary>
    [DataContract]
    public partial class UpsertGroupRequest : IEquatable<UpsertGroupRequest>, IValidatableObject
    {
        /// <summary>
        /// a default Map&lt;TargetType, Set&lt;Access&gt; to share permissions, allowed target types: WORKFLOW_DEF, TASK_DEF, WORKFLOW_SCHEDULE
        /// </summary>
        /// <value>a default Map&lt;TargetType, Set&lt;Access&gt; to share permissions, allowed target types: WORKFLOW_DEF, TASK_DEF, WORKFLOW_SCHEDULE</value>
        [DataMember(Name = "defaultAccess", EmitDefaultValue = false)]
        public Dictionary<string, List<string>> DefaultAccess { get; set; }
        /// <summary>
        /// Defines Roles
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RolesEnum
        {
            /// <summary>
            /// Enum ADMIN for value: ADMIN
            /// </summary>
            [EnumMember(Value = "ADMIN")]
            ADMIN = 1,
            /// <summary>
            /// Enum USER for value: USER
            /// </summary>
            [EnumMember(Value = "USER")]
            USER = 2,
            /// <summary>
            /// Enum WORKER for value: WORKER
            /// </summary>
            [EnumMember(Value = "WORKER")]
            WORKER = 3,
            /// <summary>
            /// Enum METADATAMANAGER for value: METADATA_MANAGER
            /// </summary>
            [EnumMember(Value = "METADATA_MANAGER")]
            METADATAMANAGER = 4,
            /// <summary>
            /// Enum WORKFLOWMANAGER for value: WORKFLOW_MANAGER
            /// </summary>
            [EnumMember(Value = "WORKFLOW_MANAGER")]
            WORKFLOWMANAGER = 5
        }
        /// <summary>
        /// Gets or Sets Roles
        /// </summary>
        [DataMember(Name = "roles", EmitDefaultValue = false)]
        public List<RolesEnum> Roles { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpsertGroupRequest" /> class.
        /// </summary>
        /// <param name="defaultAccess">a default Map&lt;TargetType, Set&lt;Access&gt; to share permissions, allowed target types: WORKFLOW_DEF, TASK_DEF, WORKFLOW_SCHEDULE.</param>
        /// <param name="description">A general description of the group (required).</param>
        /// <param name="roles">roles.</param>
        public UpsertGroupRequest(Dictionary<string, List<string>> defaultAccess = default(Dictionary<string, List<string>>), string description = default(string), List<RolesEnum> roles = default(List<RolesEnum>))
        {
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new InvalidDataException("description is a required property for UpsertGroupRequest and cannot be null");
            }
            else
            {
                this.Description = description;
            }
            this.DefaultAccess = defaultAccess;
            this.Roles = roles;
        }


        /// <summary>
        /// A general description of the group
        /// </summary>
        /// <value>A general description of the group</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpsertGroupRequest {\n");
            sb.Append("  DefaultAccess: ").Append(DefaultAccess).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Roles: ").Append(Roles).Append("\n");
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
            return this.Equals(input as UpsertGroupRequest);
        }

        /// <summary>
        /// Returns true if UpsertGroupRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of UpsertGroupRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpsertGroupRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    this.DefaultAccess == input.DefaultAccess ||
                    this.DefaultAccess != null &&
                    input.DefaultAccess != null &&
                    this.DefaultAccess.SequenceEqual(input.DefaultAccess)
                ) &&
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) &&
                (
                    this.Roles == input.Roles ||
                    this.Roles != null &&
                    input.Roles != null &&
                    this.Roles.SequenceEqual(input.Roles)
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
                if (this.DefaultAccess != null)
                    hashCode = hashCode * 59 + this.DefaultAccess.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Roles != null)
                    hashCode = hashCode * 59 + this.Roles.GetHashCode();
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
