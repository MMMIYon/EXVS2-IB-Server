using System.Net.Http.Json;
using Throw;
using WebUIInfinite.Shared.Dto.Common;
using WebUIInfinite.Shared.Dto.Message;

namespace WebUIInfinite.Client.Services.CustomMessage;

public class CustomMessageTemplateService : ICustomMessageTemplateService
{
    private readonly HttpClient _client;
    private MessageTemplates _messageTemplates = new();

    public CustomMessageTemplateService(HttpClient client)
    {
        _client = client;
    }

    public async Task InitializeAsync()
    {
        var messageTemplates = await _client.GetFromJsonAsync<MessageTemplates>("data/messages/MessageTemplates.json");
        messageTemplates.ThrowIfNull();

        _messageTemplates = messageTemplates;
    }

    public MessageTemplates GetMessageTemplates()
    {
        return _messageTemplates;
    }
}