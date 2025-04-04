using TMPro;
using UnityEngine;

namespace naa.AssemblingWords.Game
{
    public class Letter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _value;

        public void Set(char c)
        {
            _value.text = c.ToString();
        }
    }
}
