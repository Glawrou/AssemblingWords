using System.Collections.Generic;
using UnityEngine;

namespace naa.AssemblingWords.Game
{
    public class Cluster : MonoBehaviour
    {
        [SerializeField] private Letter _letterPrefab;
        [SerializeField] private DragAndDrop _dragAndDrop;
        [SerializeField] private string _letterText;

        private const float CellSize = 1.1f;
        private const int FrameCellSize = 215;

        private List<Letter> _listLetters;

        private void Start()
        {
            Init(_letterText);
        }

        public void Init(string text)
        {
            _listLetters = new List<Letter>();
            SetText(text);
            _dragAndDrop.Center = _listLetters[0].transform;
        }

        private void SetText(string text)
        {
            var cellCount = text.Length;
            for (int i = 0; i < cellCount; i++)
            {
                var xPosition = CellSize * i;
                var position = transform.position + Vector3.right * xPosition;
                var letter = Instantiate(_letterPrefab, position, Quaternion.identity, transform);
                letter.Set(text[i]);
                _listLetters.Add(letter);
            }
        }
    }
}
