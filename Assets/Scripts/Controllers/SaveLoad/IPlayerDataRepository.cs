using System.Collections.Generic;

namespace Controllers.SaveLoad
{
    public interface IPlayerDataRepository : IDataRepository
    {
        public T Load<T>(string key, string timestamp, T defaultValue = default);
        public List<string> GetAllTimestamps();
    }
}