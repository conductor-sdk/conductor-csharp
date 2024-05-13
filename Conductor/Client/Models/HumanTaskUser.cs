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
    /// HumanTaskUser
    /// </summary>
    [DataContract]
    public partial class HumanTaskUser : IEquatable<HumanTaskUser>, IValidatableObject
    {
        /// <summary>
        /// Defines UserType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UserTypeEnum
        {
            /// <summary>
            /// Enum EXTERNALUSER for value: EXTERNAL_USER
            /// </summary>
            [EnumMember(Value = "EXTERNAL_USER")]
            EXTERNALUSER = 1,
            /// <summary>
            /// Enum EXTERNALGROUP for value: EXTERNAL_GROUP
            /// </summary>
            [EnumMember(Value = "EXTERNAL_GROUP")]
            EXTERNALGROUP = 2,
            /// <summary>
            /// Enum CONDUCTORUSER for value: CONDUCTOR_USER
            /// </summary>
            [EnumMember(Value = "CONDUCTOR_USER")]
            CONDUCTORUSER = 3,
            /// <summary>
            /// Enum CONDUCTORGROUP for value: CONDUCTOR_GROUP
            /// </summary>
            [EnumMember(Value = "CONDUCTOR_GROUP")]
            CONDUCTORGROUP = 4
        }
        /// <summary>
        /// Gets or Sets UserType
        /// </summary>
        [DataMember(Name = "userType", EmitDefaultValue = false)]
        public UserTypeEnum? UserType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskUser" /> class.
        /// </summary>
        /// <param name="user">user.</param>
        /// <param name="userType">userType.</param>
        public HumanTaskUser(string user = default(string), UserTypeEnum? userType = default(UserTypeEnum?))
        {
            this.User = user;
            this.UserType = userType;
        }

        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public string User { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HumanTaskUser {\n");
            sb.Append("  User: ").Append(User).Append("\n");
            sb.Append("  UserType: ").Append(UserType).Append("\n");
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
            return this.Equals(input as HumanTaskUser);
        }

        /// <summary>
        /// Returns true if HumanTaskUser instances are equal
        /// </summary>
        /// <param name="input">Instance of HumanTaskUser to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HumanTaskUser input)
        {
            if (input == null)
                return false;

            return
                (
                    this.User == input.User ||
                    (this.User != null &&
                    this.User.Equals(input.User))
                ) &&
                (
                    this.UserType == input.UserType ||
                    (this.UserType != null &&
                    this.UserType.Equals(input.UserType))
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
                if (this.User != null)
                    hashCode = hashCode * 59 + this.User.GetHashCode();
                if (this.UserType != null)
                    hashCode = hashCode * 59 + this.UserType.GetHashCode();
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
