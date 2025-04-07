using UnityEngine;
using UnityEngine.UI;

namespace naa.AssemblingWords.Game
{
    public class Letter : MonoBehaviour
    {
        [SerializeField] private Text _value;

        public void Set(char c)
        {
            _value.text = c.ToString().ToUpper();
        }
    }
}
