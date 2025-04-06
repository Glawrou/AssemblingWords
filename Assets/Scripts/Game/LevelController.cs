using naa.AssemblingWords.Data;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace naa.AssemblingWords.Game
{
    public class LevelController : MonoBehaviour
    {
        public event Action<string[]> OnLevelComplite;

        [SerializeField] private Field _field;
        [SerializeField] private ClusterList _clusterList;
        [SerializeField] private Button _checkValidButton;

        private LevelData _levelData;

        private void Awake()
        {
            _checkValidButton.onClick.AddListener(ClickCheckValidHandler);
        }

        public void Init(LevelData data)
        {
            _levelData = data;
            _field.Init(_levelData.Field);
            _clusterList.Init(_levelData.Clusters);
        }

        private void ClickCheckValidHandler()
        {
            if (_field.ÑheckValid())
            {
                OnLevelComplite?.Invoke(_field.GetWords());
            }
        }

        private void OnDestroy()
        {
            _checkValidButton.onClick.RemoveListener(ClickCheckValidHandler);
        }
    }
}
