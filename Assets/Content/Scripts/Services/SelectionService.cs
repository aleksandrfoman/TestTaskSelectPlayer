using Content.Scripts.SO;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class SelectionService : MonoBehaviour
    {
        [SerializeField] private Transform spawnPos;
        [SerializeField] private GameDataSO gameDataSO;
        private int curIndex;
        private GameObject curPlayer;
        private SceneService sceneService;
        private SaveService saveService;
        
        [Inject]
        private void Construct(SceneService sceneService, SaveService saveService)
        {
            this.sceneService = sceneService;
            this.saveService = saveService;
            
            int playerIndex = saveService.SaveData.PlayerSave.PlayerIndex;
            GeneratePlayer(playerIndex);
        }
        
        public void Play()
        {
            sceneService.LoadScene(gameDataSO.GameNameScene);
        }

        public void Generate()
        {
            GeneratePlayer();
            AnimPlayer();
            saveService.SaveData.PlayerSave.SetPlayerIndex(curIndex);
            saveService.SaveData.Save();
        }

        private void GeneratePlayer()
        {
            if (curPlayer != null)
            {
                Destroy(curPlayer);
            }
            int rndIndex = Random.Range(0, gameDataSO.PlayerPrefabs.Length);
            curPlayer = Instantiate(gameDataSO.PlayerPrefabs[rndIndex],spawnPos.position,Quaternion.identity);
            curIndex = rndIndex;
        }

        public void GeneratePlayer(int index)
        {
            if (curPlayer != null)
            {
                Destroy(curPlayer);
            }
            curPlayer = Instantiate(gameDataSO.PlayerPrefabs[index],spawnPos.position,Quaternion.identity);
            curIndex = index;
        }

        private void AnimPlayer()
        {
            if (curPlayer != null)
            {
                curPlayer.transform.localScale = Vector3.zero;
                curPlayer.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
            }
        }
    }
}
