using UniKeyManagement.Frontend.Models;

namespace UniKeyManagement.Frontend.Services;

/// <summary>
/// Interface for API client to communicate with the backend
/// </summary>
public interface IApiClient
{
    /// <summary>
    /// Gets the setup status from the API
    /// </summary>
    Task<SetupStatusResponse?> GetSetupStatusAsync();

    /// <summary>
    /// Completes the initial setup
    /// </summary>
    Task<bool> CompleteSetupAsync(CompleteSetupRequest request);

    /// <summary>
    /// Gets current user information
    /// </summary>
    Task<UserInfoResponse?> GetUserInfoAsync();
}
