using UnityEngine;
namespace Content.Scripts.SO
{
    [CreateAssetMenu(fileName = "GameDataSO", menuName = "GameData/GameDataSO", order = 0)]
    public class GameDataSO : ScriptableObject
    {
        [field: SerializeField] public GameObject[] PlayerPrefabs { get; private set; }
        [field: SerializeField] public string MenuNameScene;
        [field: SerializeField] public string GameNameScene;
    }
}
