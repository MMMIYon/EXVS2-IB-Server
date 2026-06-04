namespace ServerInfinite.Models.Cards.Message;

/// <summary>
/// Discriminator for the new client-aligned CommandMessageData rows.
/// Tied to client's solo / team / instant_team CommandMessageData slots.
/// </summary>
public enum CommandMessageMode : uint
{
    Solo = 0,
    Team = 1,
    InstantTeam = 2,
}
