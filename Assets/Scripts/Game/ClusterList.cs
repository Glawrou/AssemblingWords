using UnityEngine;
using Zenject;

namespace naa.AssemblingWords.Game
{
    public class ClusterList : MonoBehaviour
    {
        [SerializeField] private Cluster _clusterPrefab;
        [SerializeField] private Transform _content;
        [SerializeField] private Transform _field;

        [Inject] private Camera _camera;

        private Cluster[] _clusters;

        public void Init(string[] clusters)
        {
            CreateClusters(clusters);
        }

        private void CreateClusters(string[] clusters)
        {
            _clusters = new Cluster[clusters.Length];
            for (int i = 0; i < clusters.Length; i++)
            {
                _clusters[i] = Instantiate(_clusterPrefab, _content);
                _clusters[i].Init(clusters[i], _camera, _content, _field);
            }
        }
    }
}
