using Microsoft.AspNetCore.Components.Authorization;

namespace UniKeyManagement.Frontend.Services;

/// <summary>
/// Implementation of ISetupService
/// </summary>
public class SetupService : ISetupService
{
    private readonly IApiClient _apiClient;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly ILogger<SetupService> _logger;

    public SetupService(
        IApiClient apiClient,
        AuthenticationStateProvider authStateProvider,
        ILogger<SetupService> logger)
    {
        _apiClient = apiClient;
        _authStateProvider = authStateProvider;
        _logger = logger;
    }

    public async Task<bool> IsSetupCompletedAsync()
    {
        try
        {
            var status = await _apiClient.GetSetupStatusAsync();
            return status?.IsSetupCompleted ?? false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error checking setup status");
            return false;
        }
    }

    public bool IsSuperAdmin()
    {
        try
        {
            var authState = _authStateProvider.GetAuthenticationStateAsync().Result;
            var user = authState.User;

            return user.IsInRole("SuperAdmin");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error checking if user is SuperAdmin");
            return false;
        }
    }
}
