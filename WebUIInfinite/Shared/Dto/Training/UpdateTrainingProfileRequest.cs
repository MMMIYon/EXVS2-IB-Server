using WebUIInfinite.Shared.Dto.Request;

namespace WebUIInfinite.Shared.Dto.Training;

public class UpdateTrainingProfileRequest : BasicCardRequest
{
    public TrainingProfile TrainingProfile { get; set; } = new();
}