using System;
using UnityEngine;

namespace naa.AssemblingWords.Game
{
    public class CellLetter : MonoBehaviour
    {
        public event Action<int, Cluster> OnPutCluster;
        public event Action<int, Cluster> OnOutCluster;

        public const string Tag = "CellLetter";

        private int _cellNumber = 0;

        public void Init(int cellNumber)
        {
            _cellNumber = cellNumber;
        }

        public void PutCluster(Cluster cluster)
        {
            OnPutCluster?.Invoke(_cellNumber, cluster);
        }

        public void OutCluster(Cluster cluster)
        {
            OnOutCluster?.Invoke(_cellNumber, cluster);
        }
    }
}
