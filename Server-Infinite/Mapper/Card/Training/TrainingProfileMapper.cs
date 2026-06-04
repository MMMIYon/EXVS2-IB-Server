using Riok.Mapperly.Abstractions;
using WebUIInfinite.Shared.Dto.Training;

namespace ServerInfinite.Mapper.Card.Training;

[Mapper]
public static partial class TrainingProfileMapper
{
    public static partial TrainingProfile ToTrainingProfile(this Models.Cards.Profile.TrainingProfile trainingProfile);
}