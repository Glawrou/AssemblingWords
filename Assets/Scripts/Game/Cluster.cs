using System.Collections.Generic;
using UnityEngine;

namespace naa.AssemblingWords.Game
{
    public class Cluster : MonoBehaviour
    {
        public string LetterText;

        [SerializeField] private Letter _letterPrefab;
        [SerializeField] private DragAndDrop _dragAndDrop;

        private const float CellSize = 1.1f;
        private const int FrameCellSize = 215;

        private List<Letter> _listLetters;
        private CellLetter _currentCellLetter;

        private void Awake()
        {
            _dragAndDrop.OnPutInCell += PutInCellHandler;
            _dragAndDrop.OnPickUp += PickUpHandler;
        }

        private void Start()
        {
            Init(LetterText);
        }

        public void Init(string text)
        {
            _listLetters = new List<Letter>();
            SetText(text);
            _dragAndDrop.Center = _listLetters[0].transform;
        }

        public void Respawn()
        {
            _dragAndDrop.SetPosition(Vector3.one * 100f);
        }

        private void PutInCellHandler(CellLetter cellLetter)
        {
            _currentCellLetter = cellLetter;
            cellLetter.PutCluster(this);
        }

        private void PickUpHandler()
        {
            if (!_currentCellLetter)
            {
                return;
            }

            _currentCellLetter.OutCluster(this);
            _currentCellLetter = null;
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

        private void OnDestroy()
        {
            _dragAndDrop.OnPutInCell -= PutInCellHandler;
            _dragAndDrop.OnPickUp -= PickUpHandler;
        }
    }
}
