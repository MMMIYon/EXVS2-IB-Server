namespace WebUIInfinite.Shared.Dto.Enum;

// Aligned with client schema (new version):
//  - 0: Extend  (renamed from legacy "Covering")
//  - 1: Fighting
//  - 2: Shooting
//  Legacy "Vertical" (3) has been removed.
public enum BurstType : uint
{
    Extend = 0,
    Fighting = 1,
    Shooting = 2
}

public static class BurstTypeUi
{
    /// <summary>Chip layout: Shooting (left), Extend (center), Fighting (right). Enum values unchanged.</summary>
    public static readonly BurstType[] ChipSelectionOrder = [BurstType.Shooting, BurstType.Extend, BurstType.Fighting];
}
