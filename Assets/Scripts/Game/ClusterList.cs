using System.Linq;
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

        private void ClearClusters()
        {
            if (_clusters != null)
            {
                _clusters.ToList().ForEach(c => Destroy(c.gameObject));
                _clusters = null;
            }
        }

        private void CreateClusters(string[] clusters)
        {
            clusters = RandomArray(clusters);
            ClearClusters();
            _clusters = new Cluster[clusters.Length];
            for (int i = 0; i < clusters.Length; i++)
            {
                _clusters[i] = Instantiate(_clusterPrefab, _content);
                _clusters[i].Init(clusters[i], _camera, _content, _field);
            }
        }

        public T[] RandomArray<T>(T[] array)
        {
            if (array == null || array.Length <= 1)
            {
                return array?.Clone() as T[];
            }

            var shuffledArray = (T[])array.Clone();
            for (int i = shuffledArray.Length - 1; i > 0; i--)
            {
                var randomIndex = Random.Range(0, i + 1);
                T temp = shuffledArray[i];
                shuffledArray[i] = shuffledArray[randomIndex];
                shuffledArray[randomIndex] = temp;
            }

            return shuffledArray;
        }
    }
}
