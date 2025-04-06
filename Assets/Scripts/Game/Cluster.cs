using System.Collections.Generic;
using UnityEngine;

namespace naa.AssemblingWords.Game
{
    public class Cluster : MonoBehaviour
    {
        public string LetterText { get; private set; }

        [SerializeField] private Letter _letterPrefab;
        [SerializeField] private DragAndDrop _dragAndDrop;

        private const float CellSize = 1.1f;
        private const int FrameCellSize = 215;

        private List<Letter> _listLetters;
        private CellLetter _currentCellLetter;
        private Transform _listTransform;
        private Transform _fieldTransform;

        private void Awake()
        {
            _dragAndDrop.OnPutInCell += PutInCellHandler;
            _dragAndDrop.OnPickUp += PickUpHandler;
        }

        public void Init(string text, Camera camera, Transform listTransform, Transform fieldTransform)
        {
            _listLetters = new List<Letter>();
            SetText(text);
            _dragAndDrop.Init(camera, _listLetters[0].transform);
            _listTransform = listTransform;
            _fieldTransform = fieldTransform;
        }

        public void Respawn()
        {
            transform.SetParent(_listTransform);
        }

        private void PutInCellHandler(CellLetter cellLetter)
        {
            if (!cellLetter)
            {
                Respawn();
                return;
            }

            _currentCellLetter = cellLetter;
            cellLetter.PutCluster(this);
        }

        private void PickUpHandler()
        {
            transform.SetParent(_fieldTransform);
            if (!_currentCellLetter)
            {
                return;
            }

            _currentCellLetter.OutCluster(this);
            _currentCellLetter = null;
        }

        private void SetText(string text)
        {
            LetterText = text;
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
