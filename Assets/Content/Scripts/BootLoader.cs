using Content.Scripts.Services;
using Content.Scripts.SO;
using UnityEngine;
using Zenject;

namespace Content.Scripts
{
    public class BootLoader : MonoBehaviour
    {
        [SerializeField] private GameDataSO gameDataSO;
        
        [Inject]
        private void Construct(SceneService sceneService)
        {
            sceneService.LoadScene(gameDataSO.MenuNameScene);
        }
    }
}
