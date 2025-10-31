namespace UniKeyManagement.Frontend.Services;

/// <summary>
/// Service for managing setup state and checks
/// </summary>
public interface ISetupService
{
    /// <summary>
    /// Checks if the system setup has been completed
    /// </summary>
    Task<bool> IsSetupCompletedAsync();

    /// <summary>
    /// Checks if the current user is a SuperAdmin
    /// </summary>
    bool IsSuperAdmin();
}
