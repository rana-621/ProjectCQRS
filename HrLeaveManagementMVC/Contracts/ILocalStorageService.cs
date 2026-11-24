namespace HrLeaveManagementMVC.Contracts
{
    public interface ILocalStorageService
    {
        void ClearStorage(List<string> keys);
        bool Exists(string key);
        void SetStorageValue<T>(string key, T value);
        T GetStorageValue<T>(string key);
    }
}
