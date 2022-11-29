namespace LeaveManagement.MVC.Services.Base;

public partial class Client : IClient
{
    // ReSharper disable once ConvertToAutoProperty
    public HttpClient HttpClient => _httpClient;
}
