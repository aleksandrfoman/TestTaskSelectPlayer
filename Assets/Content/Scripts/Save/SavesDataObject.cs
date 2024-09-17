using UnityEngine;

namespace Content.Scripts.Save
{
    public abstract class SavesDataObject : ScriptableObject
    {
        [System.Serializable]
        public class PlayerSaveData
        {
            [field: SerializeField] public int PlayerIndex { get; private set; }
            public void SetPlayerIndex(int index)
            {
                PlayerIndex = index;
            }
        }
        
        [SerializeField] private PlayerSaveData playerSaveData = new PlayerSaveData();
        public PlayerSaveData PlayerSave => playerSaveData;
        
        public abstract void Save();
        public abstract void Load();
        
    }
}