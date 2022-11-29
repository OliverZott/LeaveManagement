using LeaveManagement.Application.Responses;
using LeaveManagement.MVC.Contracts;
using System.Net.Http.Headers;

namespace LeaveManagement.MVC.Services.Base;

public class BaseHttpService
{
    protected readonly ILocalStorageService _localStorageService;
    protected IClient _client;

    public BaseHttpService(IClient client, ILocalStorageService localStorageService)
    {
        _client = client;
        _localStorageService = localStorageService;
    }

    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException exception)
    {
        if (exception.StatusCode == 400)
        {
            return new Response<Guid>()
            {
                Message = "Validation errors have occurred.",
                ValidationErrors = exception.Response,
                Success = false
            };
        }
        else if (exception.StatusCode == 404)
            return new Response<Guid>()
            {
                Message = "The requested item could not be found.",
                Success = false
            };
        else
        {
            return new Response<Guid>()
            {
                Message = "Unknown error.",
                Success = false
            };
        }

    }

    // Send token with http request
    protected void AddBearerToken()
    {
        if (_localStorageService.Exists("token"))
        {
            _client.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _localStorageService.GetStorageValue<string>("token"));
        }
    }
}
