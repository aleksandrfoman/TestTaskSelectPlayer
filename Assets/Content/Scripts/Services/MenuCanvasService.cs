using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Content.Scripts.Services
{
    public class MenuCanvasService : MonoBehaviour
    {
        [SerializeField] private Button btnPlay;
        [SerializeField] private Button btnGenerate;
        
        [Inject]
        private void Construct(SelectionService selectionService)
        {
            btnPlay.onClick.AddListener(selectionService.Play);
            btnGenerate.onClick.AddListener(selectionService.Generate);
        }
    }
}
