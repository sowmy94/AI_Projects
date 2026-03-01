using OpenAI;
using OpenAI.Chat;
using System.Data;

namespace FirstLLMWebApp.Services
{
    public class OpenAIService
    {
        private OpenAIClient _client;

        public OpenAIService()
        {
            string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            // Directly initialize the client with API key
            _client = new OpenAIClient(apiKey);
        }

        public async Task<string> GetChatResponse(string userMessage)
        {
            ChatClient chatClient = _client.GetChatClient("gpt-4");

            List<ChatMessage> messages = new List<ChatMessage>
    {
        new UserChatMessage(userMessage)
    };

            var response = await chatClient.CompleteChatAsync(messages);

            return response.Value.Content[0].Text;
        }
    }
}
