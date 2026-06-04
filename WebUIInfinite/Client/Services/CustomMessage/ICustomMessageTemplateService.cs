using WebUIInfinite.Shared.Dto.Message;

namespace WebUIInfinite.Client.Services.CustomMessage;

public interface ICustomMessageTemplateService
{
    public Task InitializeAsync();
    public MessageTemplates GetMessageTemplates();
}