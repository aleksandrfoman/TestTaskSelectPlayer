using System;
using System.IO;
using UnityEngine;

namespace Content.Scripts.Save
{
    [CreateAssetMenu(fileName = "SavesDataJson", menuName = "GameData/SavesDataJson", order = 5)]
    public class SaveDataObjectJson : SavesDataObject
    {
        private static SaveDataObjectJson defaultValues;
        private string path;

        private void SetPath()
        {
            if (string.IsNullOrEmpty(path))
            {
                path = Application.persistentDataPath + "/Save.json";
            }
        }

        public override void Save()
        {
            SetPath();
            var json = JsonUtility.ToJson(this);
            File.WriteAllText(path, json);
        }
        
        public override void Load()
        {
            ResetObject();
            SetPath();
            try
            {
                if (File.Exists(path))
                {
                    var json = File.ReadAllText(path);
                    JsonUtility.FromJsonOverwrite(json, this);
                }
            }
            catch (Exception e)
            {
                ResetObject();
            }

        }

        public void ResetObject()
        {
            if (defaultValues == null)
            {
                defaultValues = CreateInstance<SaveDataObjectJson>();
            }
            var json = JsonUtility.ToJson(defaultValues);
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }
}
