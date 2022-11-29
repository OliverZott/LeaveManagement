using Hanssens.Net;
using LeaveManagement.MVC.Contracts;

namespace LeaveManagement.MVC.Services;

public class LocalStorageService : ILocalStorageService
{
    private LocalStorage _localStorage;

    public LocalStorageService()
    {
        var config = new LocalStorageConfiguration()
        {
            AutoLoad = true,
            AutoSave = true,
            Filename = "LEAVEMGMT"
        };

        _localStorage = new LocalStorage(config);
    }

    public void ClearStorage(List<string> keys)
    {
        foreach (var key in keys)
        {
            _localStorage.Remove(key);
        }
    }

    public bool Exists(string key)
    {
        return _localStorage.Exists(key);
    }

    public T GetStorageValue<T>(string key)
    {
        //var result = _localStorage.Get(key);
        //return (T)result;
        return _localStorage.Get<T>(key);
    }

    public void SetStorageValue<T>(string key, T value)
    {
        _localStorage.Store(key, value);
        _localStorage.Persist();
    }
}
