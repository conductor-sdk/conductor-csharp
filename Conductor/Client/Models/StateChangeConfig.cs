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

namespace Conductor.Client.Models
{
    public class StateChangeConfig
    {
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public List<StateChangeEventType> Type { get; set; }

        /// <summary>
        /// Gets or sets Events
        /// </summary>
        public List<StateChangeEvent> Events { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateChangeConfig" /> class.
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="events"></param>
        public StateChangeConfig(List<StateChangeEventType> eventType = null, List<StateChangeEvent> events = null)
        {
            Type = eventType;
            Events = events;
        }
    }
}

/// <summary>
/// Defines StateChangeEventType
/// </summary>

[JsonConverter(typeof(StringEnumConverter))]
public enum StateChangeEventType
{
    /// <summary>
    /// Enum OnScheduled for value: onScheduled
    /// </summary>
    [EnumMember(Value = "onScheduled")]
    OnScheduled = 0,

    /// <summary>
    /// Enum OnStart for value: onStart
    /// </summary>
    [EnumMember(Value = "onStart")]
    OnStart = 1,

    /// <summary>
    /// Enum OnFailed for value: onFailed
    /// </summary>
    [EnumMember(Value = "onFailed")]
    OnFailed = 2,

    /// <summary>
    /// Enum OnSuccess for value: onSuccess
    /// </summary>
    [EnumMember(Value = "onSuccess")]
    OnSuccess = 3,

    /// <summary>
    /// Enum OnCancelled for value: onCancelled
    /// </summary>
    [EnumMember(Value = "onCancelled")]
    OnCancelled = 4
}

public class StateChangeEvent
{
    /// <summary>
    /// Gets or sets Type
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets Payload
    /// </summary>
    public Dictionary<string, object> Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StateChangeEvent" /> class
    /// </summary>
    /// <param name="type"></param>
    /// <param name="payload"></param>
    public StateChangeEvent(string type, Dictionary<string, object> payload)
    {
        Type = type;
        Payload = payload;
    }
}