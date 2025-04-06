using naa.AssemblingWords.Data;
using UnityEngine;

namespace naa.AssemblingWords.Game
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private Field _field;
        [SerializeField] private ClusterList _clusterList;

        private LevelData _levelData;

        public void Init(LevelData data)
        {
            _levelData = data;
            _field.Init(_levelData.Field);
            _clusterList.Init(_levelData.Clusters);
        }
    }
}
