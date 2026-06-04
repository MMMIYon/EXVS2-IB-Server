using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServerInfinite.Models.Cards.Message;

[Table("exvs2ob_playing_message")]
[Index(nameof(Id))]
[Index(nameof(MessageSettingId))]
public class PlayingMessage : Message
{
}