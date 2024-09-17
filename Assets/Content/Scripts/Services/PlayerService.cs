using Content.Scripts.SO;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] private Transform spawnPos;
        [SerializeField] private GameDataSO gameDataSO;
        private SceneService sceneService;
        private SaveService saveService;
        private GameObject curPlayer;
        
        [Inject]
        private void Construct(SceneService sceneService, SaveService saveService)
        {
            this.sceneService = sceneService;
            this.saveService = saveService;
            
            Spawn();
        }

        public void Back()
        {
            sceneService.LoadScene(gameDataSO.MenuNameScene);
        }

        private void Spawn()
        {
            int selectIndex = saveService.SaveData.PlayerSave.PlayerIndex;
            SpawnPlayer(selectIndex);
            AnimPlayer();
        }
        
        private void SpawnPlayer(int index)
        {
            if (curPlayer != null)
            {
                Destroy(curPlayer);
            }
            curPlayer = Instantiate(gameDataSO.PlayerPrefabs[index],spawnPos.position,Quaternion.identity);
        }
        
        private void AnimPlayer()
        {
            if (curPlayer != null)
            {
                curPlayer.transform.position = spawnPos.position + Vector3.up * 5f;
                curPlayer.transform.DOMove(spawnPos.position,0.5f).SetEase(Ease.OutBack);
                
                curPlayer.transform.localScale = Vector3.zero;
                curPlayer.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
            }
        }
    }
}
