using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Client.Services.CustomizeComment;

public interface ICustomizeCommentService
{
    Task InitializeAsync();
    IdValuePair? GetCustomizeCommentSentenceById(uint id);
    IReadOnlyList<IdValuePair> GetCustomizeCommentSentenceSortedById();
    IdValuePair? GetCustomizeCommentPhraseById(uint id);
    IReadOnlyList<IdValuePair> GetCustomizeCommentPhraseSortedById();
    string GetCustomizeCommentSentenceName(uint id);
    string GetCustomizeCommentPhraseName(uint id);
}