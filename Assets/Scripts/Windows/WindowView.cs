using UnityEngine;

namespace naa.AssemblingWords.Windows
{
    public class WindowView : MonoBehaviour
    {
        public bool Active
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }
    }
}
