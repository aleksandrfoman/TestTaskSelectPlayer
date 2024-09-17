using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Content.Scripts.Services
{
    public class GameCanvasService : MonoBehaviour
    {
        [SerializeField] private Button btnBack;
        
        [Inject]
        private void Construct(PlayerService playerService)
        {
            btnBack.onClick.AddListener(playerService.Back);
        }
    }
}
