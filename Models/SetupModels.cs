namespace UniKeyManagement.Frontend.Models;

/// <summary>
/// Response model for setup status
/// </summary>
public class SetupStatusResponse
{
    public bool IsSetupCompleted { get; set; }
    public string? DatabaseType { get; set; }
}

/// <summary>
/// Request model for completing setup
/// </summary>
public class CompleteSetupRequest
{
    public string DatabaseType { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
}

/// <summary>
/// Response model for user information
/// </summary>
public class UserInfoResponse
{
    public string? Identity { get; set; }
    public bool IsAuthenticated { get; set; }
    public List<ClaimInfo> Claims { get; set; } = new();
    public List<string> Roles { get; set; } = new();
}

/// <summary>
/// Claim information
/// </summary>
public class ClaimInfo
{
    public string Type { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
