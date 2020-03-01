
using Newtonsoft.Json;
using UnityEngine;

namespace WCH
{
    public class IPreservable<T>  where T:new()
    {
        const string Key = "WCH-STATE-SAVEKEY";

        public static T Load()
        {
            string state = PlayerPrefs.GetString(Key);
            if (string.IsNullOrWhiteSpace(state))
            {
                return new T();
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(state);
            }
        }
        public void Save()
        {
            PlayerPrefs.SetString(Key, JsonConvert.SerializeObject(this));
        }

    }

}
