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
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Conductor.Definition.TaskType
{
    public class HumanTask : Task
    {
        /// <summary>
        /// Defines AssignmentCompletionStrategy
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AssignmentCompletionStrategyEnum
        {
            /// <summary>
            /// Enum LEAVE_OPEN for value: LEAVE_OPEN
            /// </summary>
            [EnumMember(Value = "LEAVE_OPEN")]
            LEAVE_OPEN,

            /// <summary>
            /// Enum TERMINATE for value: TERMINATE
            /// </summary>
            [EnumMember(Value = "TERMINATE")]
            TERMINATE
        }

        /// <summary>
        /// Defines TriggerType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TriggerTypeEnum
        {
            /// <summary>
            /// Enum ASSIGNED for value: ASSIGNED
            /// </summary>
            [EnumMember(Value = "ASSIGNED")]
            ASSIGNED,
            /// <summary>
            /// Enum PENDING for value: PENDING
            /// </summary>
            [EnumMember(Value = "PENDING")]
            PENDING,

            /// <summary>
            /// Enum IN_PROGRESS for value: IN_PROGRESS
            /// </summary>
            [EnumMember(Value = "IN_PROGRESS")]
            IN_PROGRESS,

            /// <summary>
            /// Enum COMPLETED for value: COMPLETED
            /// </summary>
            [EnumMember(Value = "COMPLETED")]
            COMPLETED,

            /// <summary>
            /// Enum TIMED_OUT for value: TIMED_OUT
            /// </summary>
            [EnumMember(Value = "TIMED_OUT")]
            TIMED_OUT,

            /// <summary>
            /// Enum ASSIGNEE_CHANGED for value: ASSIGNEE_CHANGED
            /// </summary>
            [EnumMember(Value = "ASSIGNEE_CHANGED")]
            ASSIGNEE_CHANGED
        }

        /// <summary>
        /// Gets or sets DisplayName
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets FormTemplate
        /// </summary>
        public string FormTemplate { get; set; }

        /// <summary>
        /// Gets or sets FormVersion
        /// </summary>
        public int FormVersion { get; set; }

        /// <summary>
        /// Gets or sets AssignmentCompletionStrategy
        /// </summary>
        public AssignmentCompletionStrategyEnum AssignmentCompletionStrategy { get; set; }

        public const string ASSIGNMENTCOMPLETIONSTRATEGY = "assignmentCompletionStrategy";
        public const string DISPLAYNAME = "displayName";

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTask" /> class.
        /// </summary>
        /// <param name="taskRefName"></param>
        /// <param name="displayName"></param>
        /// <param name="formTemplate"></param>
        /// <param name="formVersion"></param>
        /// <param name="assignmentCompletionStrategy"></param>
        public HumanTask(string taskRefName, string displayName = null, string formTemplate = null, int formVersion = 0, AssignmentCompletionStrategyEnum assignmentCompletionStrategy = AssignmentCompletionStrategyEnum.LEAVE_OPEN)
        : base(taskRefName, WorkflowTaskTypeEnum.HUMAN)
        {
            DisplayName = displayName;
            FormTemplate = formTemplate;
            FormVersion = formVersion;
            AssignmentCompletionStrategy = assignmentCompletionStrategy;
            InitializeInputParameters();
        }

        /// <summary>
        /// Adds the HumanTaskDefinition to InputParameters
        /// </summary>
        private void InitializeInputParameters()
        {
            var humanTaskDefinition = new Dictionary<string, object>
{
{ ASSIGNMENTCOMPLETIONSTRATEGY, AssignmentCompletionStrategy.ToString() },
{ DISPLAYNAME, DisplayName },
{
"userFormTemplate", new Dictionary<string, object>
{
{ "name", FormTemplate },
{ "version", FormVersion }
}
}
};

            InputParameters["humanTaskDefinition"] = humanTaskDefinition;
        }
    }
}