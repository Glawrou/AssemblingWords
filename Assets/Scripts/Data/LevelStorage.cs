using UnityEngine;

namespace naa.AssemblingWords.Data
{
    public class LevelStorage : MonoBehaviour
    {
        private LevelsData _levelsData;

        private const string PathDefaultLevels = @"Data\DefaultLevels";

        private void Awake()
        {
            _levelsData = GetDefaultLevels();
        }

        private LevelsData GetDefaultLevels()
        {
            var json = Resources.Load<TextAsset>(PathDefaultLevels);
            return JsonUtility.FromJson<LevelsData>(json.text);
        }

        public LevelData GetLevel(int levelNumber)
        {
            if (levelNumber < 0 || levelNumber >= _levelsData.Levels.Length)
            {
                return null;
            }

            return _levelsData.Levels[levelNumber];
        }
    }
}
