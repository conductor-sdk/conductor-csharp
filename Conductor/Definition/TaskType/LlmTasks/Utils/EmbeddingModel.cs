namespace Conductor.Definition.TaskType.LlmTasks.Utils
{
    /// <summary>
    /// EmbeddingModel
    /// </summary>
    public class EmbeddingModel
    {
        /// <summary>
        /// Gets or Sets Provider
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Gets or Sets Model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddingModel" /> class
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="model"></param>
        public EmbeddingModel(string provider, string model)
        {
            Provider = provider;
            Model = model;
        }
    }
}
