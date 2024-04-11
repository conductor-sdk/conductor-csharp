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
