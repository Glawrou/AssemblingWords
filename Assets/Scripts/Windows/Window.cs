using UnityEngine;

namespace naa.AssemblingWords.Windows
{
    public abstract class Window : MonoBehaviour
    {
        public string Name { get; protected set; }
        public bool Active => _windowView.Active;
        
        [SerializeField] private WindowView _windowView;

        public void Open() => SetActive(true);

        public void Close() => SetActive(false);

        protected void SetActive(bool isActive)
        {
            _windowView.Active = isActive;
        }
    }
}
