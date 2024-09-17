using Content.Scripts.Save;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class SaveService : MonoBehaviour
    {
        [field: SerializeField] public SavesDataObject SaveData { get; private set; }

        [Inject]
        private void Construct()
        {
            SaveData.Load();
        }
    }
}
