namespace WebUIInfinite.Client.Services.Stamp;

/// <summary>
/// Wire-format IDs for LoadCard command message slots (confirmed via client capture).
/// </summary>
public static class CommunicationMessageStampIds
{
    public const uint Disable = 0;
    public const uint CustomizeText = 1;
    public const uint StampOffset = 10000;

    public static bool AllowsCustomText(uint uniqueMessageId) => uniqueMessageId == CustomizeText;

    public static bool IsStampImage(uint uniqueMessageId) => uniqueMessageId > CustomizeText;

    /// <summary>
    /// Maps a Stamps.json row ID to the wire UniqueMessageId on cards / image file names.
    /// JSON wire layout: 0=None, 1=CustomizeText, 10001+=stamp images (10001 is first shop stamp).
    /// Legacy rows with ID in (1, 10000) are still shifted by StampOffset.
    /// </summary>
    public static uint ToWireStampId(uint jsonStampId)
    {
        if (jsonStampId > 1 && jsonStampId < StampOffset)
            return jsonStampId + StampOffset;

        return jsonStampId;
    }

    public static string GetStampImageWebPath(uint uniqueMessageId) =>
        $"images/stamps/{uniqueMessageId}.webp";
}
