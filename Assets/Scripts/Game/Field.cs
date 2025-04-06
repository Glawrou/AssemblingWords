using naa.AssemblingWords.Data;
using System.Linq;
using UnityEngine;

namespace naa.AssemblingWords.Game
{
    public class Field : MonoBehaviour
    {
        [SerializeField] private Word _wordPrefab;

        private Word[] _words;
        private FieldData _data;

        public void Init(FieldData data)
        {
            _data = data;
            CreateWords(_data.Words.Length);
        }

        private void CreateWords(int count)
        {
            _words = new Word[count];
            for (var i = 0; i < count; i++)
            {
                _words[i] = Instantiate(_wordPrefab, transform);
            }
        }

        [ContextMenu("ÑheckValid")]
        private void DebugField()
        {
            Debug.Log(ÑheckValid());
        }

        public bool ÑheckValid()
        {
            var answerWord = _words.Select(w => w.GetWord()).ToArray();
            var answerData = _data.Words;
            return answerWord.All(w => answerData.Any(d => d.ToUpper() == w.ToUpper()));
        }
    }
}
