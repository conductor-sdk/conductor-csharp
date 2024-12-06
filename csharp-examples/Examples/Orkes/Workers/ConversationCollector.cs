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
namespace Conductor.Examples.Orkes.Workers
{
    public static class ConversationCollector
    {
        public static string CollectorJs { get; }

        static ConversationCollector()
        {
            CollectorJs = @"
            (function(){
                var history = $.history;
                var lastAnswer = $.last_answer;
                var conversation = [];
                for(var i = 0; i < history.length - 1; i += 2) {
                conversation.push({
                'question': history[i].message,
                'answer': history[i + 1].message
                });
            }
            conversation.push({
            'question': history[i].message,
            'answer': lastAnswer
            });
            return conversation;
            })();
            ";
        }

        public static string GetConversation()
        {
            return CollectorJs;
        }
    }
}
