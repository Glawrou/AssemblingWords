using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace naa.AssemblingWords.Game
{
    public class Word : MonoBehaviour
    {
        [SerializeField] private CellLetter[] _cellLetters;

        private Dictionary<int, Cluster> _content = new Dictionary<int, Cluster>();

        private const char WordStub = '-';

        private void Awake()
        {
            _cellLetters.ToList().ForEach(c => c.OnPutCluster += PutClusterHandler);
            _cellLetters.ToList().ForEach(c => c.OnOutCluster += OutClusterHandler);
        }

        private void Start()
        {
            for (int i = 0; i < _cellLetters.Length; i++)
            {
                _cellLetters[i].Init(i);
            }
        }

        private void PutClusterHandler(int cellNumber, Cluster cluster)
        {
            TryPutCluster(cellNumber, cluster);
        }

        private void OutClusterHandler(int cellNumber, Cluster cluster)
        {
            cellNumber -= cluster.LetterText.Length - 1;
            _content.Remove(cellNumber);
        }

        private bool TryPutCluster(int cellNumber, Cluster cluster)
        {
            cellNumber -= cluster.LetterText.Length - 1;
            if (cellNumber < 0 || cellNumber > _cellLetters.Length)
            {
                cluster.Respawn();
                return false;
            }

            var endCluster = cellNumber + cluster.LetterText.Length - 1;
            foreach (var cell in _content)
            {
                var end = cell.Key + cell.Value.LetterText.Length - 1;
                if (CheckRange(cellNumber, endCluster, cell.Key, end))
                {
                    cluster.Respawn();
                    return false;
                }
            }

            if (!_content.TryAdd(cellNumber, cluster))
            {
                cluster.Respawn();
                return false;
            }

            return true;
        }

        public string GetWord()
        {
            var word = new StringBuilder();
            for (int i = 0; i < _cellLetters.Length; i++)
            {
                var isCharacterFound = false;
                foreach (var item in _content)
                {
                    int clusterEnd = item.Key + item.Value.LetterText.Length - 1;
                    if (item.Key <= i && i <= clusterEnd)
                    {
                        word.Append(item.Value.LetterText[i - item.Key]);
                        isCharacterFound = true;
                        break;
                    }
                }

                if (!isCharacterFound)
                {
                    word.Append(WordStub);
                }
            }

            return word.ToString().ToUpper();
        }

        private bool CheckRange(int startNumber1, int endNumber1, int startNumber2, int endNumber2)
        {
            return startNumber1 <= endNumber2 && startNumber2 <= endNumber1;
        }

        private void OnDestroy()
        {
            _cellLetters.ToList().ForEach(c => c.OnPutCluster -= PutClusterHandler);
            _cellLetters.ToList().ForEach(c => c.OnOutCluster -= OutClusterHandler);
        }
    }
}
