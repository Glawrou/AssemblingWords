using UnityEngine;
using Zenject;

namespace naa.AssemblingWords.Data
{
    public class LevelStorage : MonoBehaviour
    {
        [Inject] private ConfigManager _configManager;

        private LevelsData _levelsData;

        private const string PathDefaultLevels = @"Data\DefaultLevels";

        private LevelsData GetDefaultLevels()
        {
            var json = Resources.Load<TextAsset>(PathDefaultLevels);
            return JsonUtility.FromJson<LevelsData>(json.text);
        }

        private LevelsData GetRemoteLevels()
        {
            var json = _configManager.GetLevels();
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            return JsonUtility.FromJson<LevelsData>(json);
        }

        private LevelsData GetLevelsData()
        {
            var remote = GetRemoteLevels();
            if (remote is null)
            {
                return GetDefaultLevels();
            }

            return remote;
        }

        public LevelData GetLevel(int levelNumber)
        {
            if (_levelsData is null)
            {
                _levelsData = GetLevelsData();
            }

            if (levelNumber < 0 || levelNumber >= _levelsData.Levels.Length)
            {
                return null;
            }

            return _levelsData.Levels[levelNumber];
        }
    }
}
