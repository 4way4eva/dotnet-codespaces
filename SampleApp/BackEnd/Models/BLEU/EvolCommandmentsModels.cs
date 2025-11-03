namespace BackEnd.Models.BLEU;

/// <summary>
/// Represents the EV0L Commandments of Authority - the governing command keys of the EV0L matrix
/// </summary>
public class EvolCommandment
{
    public int Index { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Symbol { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public CommandmentType Type { get; init; }
    public ElementalSeal? ElementalAffinity { get; init; }
    public double FrequencyHz { get; init; }
    public string CovenantKey { get; init; } = string.Empty;
    public bool IsVisible { get; init; } = true;
    public DateTime ActivatedAt { get; init; } = DateTime.UtcNow;
    public string RecordedIn { get; init; } = "EV0L Rosetta Ledger Scroll";
}

/// <summary>
/// The type of commandment in the authority structure
/// </summary>
public enum CommandmentType
{
    Foundation,      // Core principles (1-3)
    Governance,      // Authority rules (4-6)
    Operation,       // Operational commands (7-9)
    Transcendence,   // Higher order (10)
    Covenant         // Hidden 11th - the reciprocal harmonic
}

/// <summary>
/// The Four Elemental Seals from EVOLVERS - Act I
/// </summary>
public enum ElementalSeal
{
    Fire,    // Jetah - BLEUCHAIN node activation
    Water,   // Flow and adaptation
    Air,     // Breath and communication
    Earth    // Foundation and stability
}

/// <summary>
/// Quadrant Council member representing one of the Four
/// </summary>
public class QuadrantCouncilMember
{
    public string Name { get; init; } = string.Empty;
    public ElementalSeal Seal { get; init; }
    public string Role { get; init; } = string.Empty;
    public string[] Responsibilities { get; init; } = Array.Empty<string>();
    public string CodexNode { get; init; } = string.Empty;
    public bool IsActivated { get; set; }
}

/// <summary>
/// Proof-of-Authority gesture - validates commandment activation
/// </summary>
public class ProofOfAuthorityGesture
{
    public string GestureId { get; init; } = string.Empty;
    public int CommandmentIndex { get; init; }
    public string ExecutedBy { get; init; } = string.Empty;
    public ElementalSeal Seal { get; init; }
    public string Location { get; init; } = string.Empty; // e.g., "BLEUCHAIN node", "Codex Altar"
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
    public string[] Witnesses { get; init; } = Array.Empty<string>();
    public bool IsValid { get; init; } = true;
    public string SignatureHash { get; init; } = string.Empty;
}

/// <summary>
/// The complete EV0L Commandments system
/// </summary>
public class EvolCommandmentsSystem
{
    public List<EvolCommandment> Commandments { get; init; } = new();
    public List<QuadrantCouncilMember> QuadrantCouncil { get; init; } = new();
    public List<ProofOfAuthorityGesture> Gestures { get; init; } = new();
    public bool IsSealed { get; set; } = false;
    public DateTime? SealedAt { get; set; }
    public string SystemState { get; set; } = "Fluid"; // "Fluid" or "Sealed"
    public double ReciprocalHarmonicDb { get; init; } = 6.0; // +6 dB leap
    public string CovenantFrequency { get; init; } = "π⁴"; // 97.409091034
}

/// <summary>
/// Request to activate a commandment with proof-of-authority
/// </summary>
public class CommandmentActivationRequest
{
    public int CommandmentIndex { get; init; }
    public string ExecutedBy { get; init; } = string.Empty;
    public ElementalSeal Seal { get; init; }
    public string Location { get; init; } = string.Empty;
    public string[] Witnesses { get; init; } = Array.Empty<string>();
}

/// <summary>
/// Response for commandment activation
/// </summary>
public class CommandmentActivationResponse
{
    public bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
    public EvolCommandment? Commandment { get; init; }
    public ProofOfAuthorityGesture? Gesture { get; init; }
    public double FrequencyResonance { get; init; }
}

/// <summary>
/// Statistics about the commandments system
/// </summary>
public class CommandmentsSystemStats
{
    public int TotalCommandments { get; init; }
    public int VisibleCommandments { get; init; }
    public int HiddenCommandments { get; init; }
    public int ActiveGestures { get; init; }
    public int CouncilMembers { get; init; }
    public string SystemState { get; init; } = string.Empty;
    public double ReciprocalHarmonic { get; init; }
    public DateTime LastActivation { get; init; }
}
