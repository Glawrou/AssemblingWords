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


        private void Awake()
        {
            _checkValidButton.onClick.AddListener(ClickCheckValidHandler);
        }

        public void Init(string[] words, string[] clusters)
        {
            _field.Init(words);
            _clusterList.Init(clusters);
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
