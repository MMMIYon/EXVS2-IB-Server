using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServerInfinite.Models.Cards.Message;

[Table("exvs2ob_online_shuffle_result_message")]
[Index(nameof(Id))]
[Index(nameof(MessageSettingId))]
public class OnlineShuffleResultMessage : Message
{
}