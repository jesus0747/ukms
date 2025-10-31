using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using UniKeyManagement.Frontend.Models;

namespace UniKeyManagement.Frontend.Services;

/// <summary>
/// Implementation of IApiClient for communicating with the backend API
/// </summary>
public class ApiClient : IApiClient
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly ILogger<ApiClient> _logger;

    public ApiClient(
        HttpClient httpClient,
        AuthenticationStateProvider authStateProvider,
        ILogger<ApiClient> logger)
    {
        _httpClient = httpClient;
        _authStateProvider = authStateProvider;
        _logger = logger;
    }

    private async Task AddAuthorizationHeaderAsync()
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity?.IsAuthenticated == true)
        {
            // In production, you would get an access token here
            // For now, we'll use the authentication cookie
            // TODO: Implement proper token acquisition using Microsoft.Identity.Web
        }
    }

    public async Task<SetupStatusResponse?> GetSetupStatusAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<SetupStatusResponse>("api/setup/status");
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting setup status");
            return null;
        }
    }

    public async Task<bool> CompleteSetupAsync(CompleteSetupRequest request)
    {
        try
        {
            await AddAuthorizationHeaderAsync();

            var response = await _httpClient.PostAsJsonAsync("api/setup/complete", request);
            response.EnsureSuccessStatusCode();

            _logger.LogInformation("Setup completed successfully");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error completing setup");
            return false;
        }
    }

    public async Task<UserInfoResponse?> GetUserInfoAsync()
    {
        try
        {
            await AddAuthorizationHeaderAsync();

            var response = await _httpClient.GetFromJsonAsync<UserInfoResponse>("api/setup/user-info");
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting user info");
            return null;
        }
    }
}
