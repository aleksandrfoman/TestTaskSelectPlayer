using System;
using System.IO;
using UnityEngine;

namespace Content.Scripts.Save
{
    [CreateAssetMenu(fileName = "SavesDataPrefs", menuName = "GameData/SavesDataPrefs", order = 5)]
    public class SaveDataObjectPrefs : SavesDataObject
    {
        private const string PREFS_KEY = "PrefsSaves";
        private static SaveDataObjectPrefs defaultValues;
        
        
        public override void Save()
        {
            var json = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(PREFS_KEY, json);
        }
        
        public override void Load()
        {
            var json = PlayerPrefs.GetString(PREFS_KEY);
            
            if (!PlayerPrefs.HasKey(PREFS_KEY))
            {
                ResetObject();
            }
            else
            {
                JsonUtility.FromJsonOverwrite(json, this);
            }
        }
        
        public void Clear()
        {
            
            if (PlayerPrefs.HasKey(PREFS_KEY))
            {
                PlayerPrefs.DeleteKey(PREFS_KEY);
                Load();
            }
            PlayerPrefs.DeleteAll();
            ResetObject();
        }
        
        public void ResetObject()
        {
            if (defaultValues == null)
            {
                defaultValues = CreateInstance<SaveDataObjectPrefs>();
            }
            var json = JsonUtility.ToJson(defaultValues);
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }
}
