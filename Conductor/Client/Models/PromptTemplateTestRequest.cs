using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Conductor.Client.Models
{
    /// <summary>
    /// PromptTemplateTestRequest
    /// </summary>
    [DataContract]
    public partial class PromptTemplateTestRequest : IEquatable<PromptTemplateTestRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PromptTemplateTestRequest" /> class.
        /// </summary>
        /// <param name="llmProvider">llmProvider.</param>
        /// <param name="model">model.</param>
        /// <param name="prompt">prompt.</param>
        /// <param name="promptVariables">promptVariables.</param>
        /// <param name="stopWords">stopWords.</param>
        /// <param name="temperature">temperature.</param>
        /// <param name="topP">topP.</param>
        public PromptTemplateTestRequest(string llmProvider = default(string), string model = default(string), string prompt = default(string), Dictionary<string, Object> promptVariables = default(Dictionary<string, Object>), List<string> stopWords = default(List<string>), double? temperature = default(double?), double? topP = default(double?))
        {
            this.LlmProvider = llmProvider;
            this.Model = model;
            this.Prompt = prompt;
            this.PromptVariables = promptVariables;
            this.StopWords = stopWords;
            this.Temperature = temperature;
            this.TopP = topP;
        }

        /// <summary>
        /// Gets or Sets LlmProvider
        /// </summary>
        [DataMember(Name = "llmProvider", EmitDefaultValue = false)]
        public string LlmProvider { get; set; }

        /// <summary>
        /// Gets or Sets Model
        /// </summary>
        [DataMember(Name = "model", EmitDefaultValue = false)]
        public string Model { get; set; }

        /// <summary>
        /// Gets or Sets Prompt
        /// </summary>
        [DataMember(Name = "prompt", EmitDefaultValue = false)]
        public string Prompt { get; set; }

        /// <summary>
        /// Gets or Sets PromptVariables
        /// </summary>
        [DataMember(Name = "promptVariables", EmitDefaultValue = false)]
        public Dictionary<string, Object> PromptVariables { get; set; }

        /// <summary>
        /// Gets or Sets StopWords
        /// </summary>
        [DataMember(Name = "stopWords", EmitDefaultValue = false)]
        public List<string> StopWords { get; set; }

        /// <summary>
        /// Gets or Sets Temperature
        /// </summary>
        [DataMember(Name = "temperature", EmitDefaultValue = false)]
        public double? Temperature { get; set; }

        /// <summary>
        /// Gets or Sets TopP
        /// </summary>
        [DataMember(Name = "topP", EmitDefaultValue = false)]
        public double? TopP { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PromptTemplateTestRequest {\n");
            sb.Append("  LlmProvider: ").Append(LlmProvider).Append("\n");
            sb.Append("  Model: ").Append(Model).Append("\n");
            sb.Append("  Prompt: ").Append(Prompt).Append("\n");
            sb.Append("  PromptVariables: ").Append(PromptVariables).Append("\n");
            sb.Append("  StopWords: ").Append(StopWords).Append("\n");
            sb.Append("  Temperature: ").Append(Temperature).Append("\n");
            sb.Append("  TopP: ").Append(TopP).Append("\n");
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
            return this.Equals(input as PromptTemplateTestRequest);
        }

        /// <summary>
        /// Returns true if PromptTemplateTestRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of PromptTemplateTestRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PromptTemplateTestRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    this.LlmProvider == input.LlmProvider ||
                    (this.LlmProvider != null &&
                    this.LlmProvider.Equals(input.LlmProvider))
                ) &&
                (
                    this.Model == input.Model ||
                    (this.Model != null &&
                    this.Model.Equals(input.Model))
                ) &&
                (
                    this.Prompt == input.Prompt ||
                    (this.Prompt != null &&
                    this.Prompt.Equals(input.Prompt))
                ) &&
                (
                    this.PromptVariables == input.PromptVariables ||
                    this.PromptVariables != null &&
                    input.PromptVariables != null &&
                    this.PromptVariables.SequenceEqual(input.PromptVariables)
                ) &&
                (
                    this.StopWords == input.StopWords ||
                    this.StopWords != null &&
                    input.StopWords != null &&
                    this.StopWords.SequenceEqual(input.StopWords)
                ) &&
                (
                    this.Temperature == input.Temperature ||
                    (this.Temperature != null &&
                    this.Temperature.Equals(input.Temperature))
                ) &&
                (
                    this.TopP == input.TopP ||
                    (this.TopP != null &&
                    this.TopP.Equals(input.TopP))
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
                if (this.LlmProvider != null)
                    hashCode = hashCode * 59 + this.LlmProvider.GetHashCode();
                if (this.Model != null)
                    hashCode = hashCode * 59 + this.Model.GetHashCode();
                if (this.Prompt != null)
                    hashCode = hashCode * 59 + this.Prompt.GetHashCode();
                if (this.PromptVariables != null)
                    hashCode = hashCode * 59 + this.PromptVariables.GetHashCode();
                if (this.StopWords != null)
                    hashCode = hashCode * 59 + this.StopWords.GetHashCode();
                if (this.Temperature != null)
                    hashCode = hashCode * 59 + this.Temperature.GetHashCode();
                if (this.TopP != null)
                    hashCode = hashCode * 59 + this.TopP.GetHashCode();
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
