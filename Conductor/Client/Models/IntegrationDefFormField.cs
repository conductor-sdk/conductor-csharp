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
    /// IntegrationDefFormField
    /// </summary>
    [DataContract]
    public partial class IntegrationDefFormField : IEquatable<IntegrationDefFormField>, IValidatableObject
    {
        /// <summary>
        /// Defines FieldName
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FieldNameEnum
        {
            /// <summary>
            /// Enum Apikey for value: api_key
            /// </summary>
            [EnumMember(Value = "api_key")]
            Apikey = 1,
            /// <summary>
            /// Enum User for value: user
            /// </summary>
            [EnumMember(Value = "user")]
            User = 2,
            /// <summary>
            /// Enum Endpoint for value: endpoint
            /// </summary>
            [EnumMember(Value = "endpoint")]
            Endpoint = 3,
            /// <summary>
            /// Enum Environment for value: environment
            /// </summary>
            [EnumMember(Value = "environment")]
            Environment = 4,
            /// <summary>
            /// Enum ProjectName for value: projectName
            /// </summary>
            [EnumMember(Value = "projectName")]
            ProjectName = 5,
            /// <summary>
            /// Enum IndexName for value: indexName
            /// </summary>
            [EnumMember(Value = "indexName")]
            IndexName = 6,
            /// <summary>
            /// Enum Publisher for value: publisher
            /// </summary>
            [EnumMember(Value = "publisher")]
            Publisher = 7,
            /// <summary>
            /// Enum Password for value: password
            /// </summary>
            [EnumMember(Value = "password")]
            Password = 8,
            /// <summary>
            /// Enum Namespace for value: namespace
            /// </summary>
            [EnumMember(Value = "namespace")]
            Namespace = 9,
            /// <summary>
            /// Enum BatchSize for value: batchSize
            /// </summary>
            [EnumMember(Value = "batchSize")]
            BatchSize = 10,
            /// <summary>
            /// Enum BatchWaitTime for value: batchWaitTime
            /// </summary>
            [EnumMember(Value = "batchWaitTime")]
            BatchWaitTime = 11,
            /// <summary>
            /// Enum VisibilityTimeout for value: visibilityTimeout
            /// </summary>
            [EnumMember(Value = "visibilityTimeout")]
            VisibilityTimeout = 12,
            /// <summary>
            /// Enum ConnectionType for value: connectionType
            /// </summary>
            [EnumMember(Value = "connectionType")]
            ConnectionType = 13,
            /// <summary>
            /// Enum Region for value: region
            /// </summary>
            [EnumMember(Value = "region")]
            Region = 14,
            /// <summary>
            /// Enum AwsAccountId for value: awsAccountId
            /// </summary>
            [EnumMember(Value = "awsAccountId")]
            AwsAccountId = 15,
            /// <summary>
            /// Enum ExternalId for value: externalId
            /// </summary>
            [EnumMember(Value = "externalId")]
            ExternalId = 16,
            /// <summary>
            /// Enum RoleArn for value: roleArn
            /// </summary>
            [EnumMember(Value = "roleArn")]
            RoleArn = 17,
            /// <summary>
            /// Enum Protocol for value: protocol
            /// </summary>
            [EnumMember(Value = "protocol")]
            Protocol = 18,
            /// <summary>
            /// Enum Port for value: port
            /// </summary>
            [EnumMember(Value = "port")]
            Port = 19,
            /// <summary>
            /// Enum SchemaRegistryUrl for value: schemaRegistryUrl
            /// </summary>
            [EnumMember(Value = "schemaRegistryUrl")]
            SchemaRegistryUrl = 20,
            /// <summary>
            /// Enum SchemaRegistryApiKey for value: schemaRegistryApiKey
            /// </summary>
            [EnumMember(Value = "schemaRegistryApiKey")]
            SchemaRegistryApiKey = 21,
            /// <summary>
            /// Enum SchemaRegistryApiSecret for value: schemaRegistryApiSecret
            /// </summary>
            [EnumMember(Value = "schemaRegistryApiSecret")]
            SchemaRegistryApiSecret = 22,
            /// <summary>
            /// Enum AuthenticationType for value: authenticationType
            /// </summary>
            [EnumMember(Value = "authenticationType")]
            AuthenticationType = 23,
            /// <summary>
            /// Enum KeyStorePassword for value: keyStorePassword
            /// </summary>
            [EnumMember(Value = "keyStorePassword")]
            KeyStorePassword = 24,
            /// <summary>
            /// Enum KeyStoreLocation for value: keyStoreLocation
            /// </summary>
            [EnumMember(Value = "keyStoreLocation")]
            KeyStoreLocation = 25,
            /// <summary>
            /// Enum SchemaRegistryAuthType for value: schemaRegistryAuthType
            /// </summary>
            [EnumMember(Value = "schemaRegistryAuthType")]
            SchemaRegistryAuthType = 26,
            /// <summary>
            /// Enum ValueSubjectNameStrategy for value: valueSubjectNameStrategy
            /// </summary>
            [EnumMember(Value = "valueSubjectNameStrategy")]
            ValueSubjectNameStrategy = 27,
            /// <summary>
            /// Enum File for value: file
            /// </summary>
            [EnumMember(Value = "file")]
            File = 28,
            /// <summary>
            /// Enum JdbcDriver for value: jdbcDriver
            /// </summary>
            [EnumMember(Value = "jdbcDriver")]
            JdbcDriver = 29,
            /// <summary>
            /// Enum DataSourceURL for value: datasourceURL
            /// </summary>
            [EnumMember(Value = "datasourceURL")]
            DataSourceURL = 30,
            /// <summary>
            /// Enum Subscription for value: subscription
            /// </summary>
            [EnumMember(Value = "subscription")]
            Subscription = 31
        }

        /// <summary>
        /// Gets or Sets FieldName
        /// </summary>
        [DataMember(Name = "fieldName", EmitDefaultValue = false)]
        public FieldNameEnum? FieldName { get; set; }

        /// <summary>
        /// Defines FieldType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FieldTypeEnum
        {
            /// <summary>
            /// Enum DROPDOWN for value: DROPDOWN
            /// </summary>
            [EnumMember(Value = "DROPDOWN")]
            DROPDOWN = 1,
            /// <summary>
            /// Enum TEXT for value: TEXT
            /// </summary>
            [EnumMember(Value = "TEXT")]
            TEXT = 2,
            /// <summary>
            /// Enum PASSWORD for value: PASSWORD
            /// </summary>
            [EnumMember(Value = "PASSWORD")]
            PASSWORD = 3,
            /// <summary>
            /// Enum FILE value: FILE
            /// </summary>
            [EnumMember(Value = "FILE")]
            FILE = 4
        }

        /// <summary>
        /// Gets or Sets FieldType
        /// </summary>
        [DataMember(Name = "fieldType", EmitDefaultValue = false)]
        public FieldTypeEnum? FieldType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationDefFormField" /> class.
        /// </summary>
        /// <param name="defaultValue">defaultValue.</param>
        /// <param name="description">description.</param>
        /// <param name="fieldName">fieldName.</param>
        /// <param name="fieldType">fieldType.</param>
        /// <param name="label">label.</param>
        /// <param name="value">value.</param>
        /// <param name="valueOptions">valueOptions.</param>
        public IntegrationDefFormField(string defaultValue = default(string), string description = default(string), FieldNameEnum? fieldName = default(FieldNameEnum?), FieldTypeEnum? fieldType = default(FieldTypeEnum?), string label = default(string), string value = default(string), List<Option> valueOptions = default(List<Option>))
        {
            this.DefaultValue = defaultValue;
            this.Description = description;
            this.FieldName = fieldName;
            this.FieldType = fieldType;
            this.Label = label;
            this.Value = value;
            this.ValueOptions = valueOptions;
        }

        /// <summary>
        /// Gets or Sets DefaultValue
        /// </summary>
        [DataMember(Name = "defaultValue", EmitDefaultValue = false)]
        public string DefaultValue { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Label
        /// </summary>
        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets ValueOptions
        /// </summary>
        [DataMember(Name = "valueOptions", EmitDefaultValue = false)]
        public List<Option> ValueOptions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IntegrationDefFormField {\n");
            sb.Append(" DefaultValue: ").Append(DefaultValue).Append("\n");
            sb.Append(" Description: ").Append(Description).Append("\n");
            sb.Append(" FieldName: ").Append(FieldName).Append("\n");
            sb.Append(" FieldType: ").Append(FieldType).Append("\n");
            sb.Append(" Label: ").Append(Label).Append("\n");
            sb.Append(" Value: ").Append(Value).Append("\n");
            sb.Append(" ValueOptions: ").Append(ValueOptions).Append("\n");
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
            return this.Equals(input as IntegrationDefFormField);
        }

        /// <summary>
        /// Returns true if IntegrationDefFormField instances are equal
        /// </summary>
        /// <param name="input">Instance of IntegrationDefFormField to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IntegrationDefFormField input)
        {
            if (input == null)
                return false;

            return
            (
            this.DefaultValue == input.DefaultValue ||
            (this.DefaultValue != null &&
            this.DefaultValue.Equals(input.DefaultValue))
            ) &&
            (
            this.Description == input.Description ||
            (this.Description != null &&
            this.Description.Equals(input.Description))
            ) &&
            (
            this.FieldName == input.FieldName ||
            (this.FieldName != null &&
            this.FieldName.Equals(input.FieldName))
            ) &&
            (
            this.FieldType == input.FieldType ||
            (this.FieldType != null &&
            this.FieldType.Equals(input.FieldType))
            ) &&
            (
            this.Label == input.Label ||
            (this.Label != null &&
            this.Label.Equals(input.Label))
            ) &&
            (
            this.Value == input.Value ||
            (this.Value != null &&
            this.Value.Equals(input.Value))
            ) &&
            (
            this.ValueOptions == input.ValueOptions ||
            this.ValueOptions != null &&
            input.ValueOptions != null &&
            this.ValueOptions.SequenceEqual(input.ValueOptions)
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
                if (this.DefaultValue != null)
                    hashCode = hashCode * 59 + this.DefaultValue.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.FieldName != null)
                    hashCode = hashCode * 59 + this.FieldName.GetHashCode();
                if (this.FieldType != null)
                    hashCode = hashCode * 59 + this.FieldType.GetHashCode();
                if (this.Label != null)
                    hashCode = hashCode * 59 + this.Label.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                if (this.ValueOptions != null)
                    hashCode = hashCode * 59 + this.ValueOptions.GetHashCode();
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
