using System.Linq;
using UnityEngine;

namespace naa.AssemblingWords.Game
{
    public class Field : MonoBehaviour
    {
        [SerializeField] private Word _wordPrefab;

        private Word[] _words;
        private string[] _data;

        public void Init(string[] data)
        {
            _data = data;
            CreateWords(_data.Length);
        }

        private void ClearWords()
        {
            if (_words != null)
            {
                _words.ToList().ForEach(w => Destroy(w.gameObject));
                _words = null;
            }
        }

        private void CreateWords(int count)
        {
            ClearWords();
            _words = new Word[count];
            for (var i = 0; i < count; i++)
            {
                _words[i] = Instantiate(_wordPrefab, transform);
            }
        }

        public string[] GetWords()
        {
            return _words.Select(w => w.GetWord()).ToArray();
        }

        public bool ÑheckValid()
        {
            var answerWord = GetWords();
            var answerData = _data;
            return answerWord.All(w => answerData.Any(d => d.ToUpper() == w.ToUpper()));
        }
    }
}
