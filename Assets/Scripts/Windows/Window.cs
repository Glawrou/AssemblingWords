using UnityEngine;

namespace naa.AssemblingWords.Windows
{
    public abstract class Window : MonoBehaviour
    {
        public string Name { get; protected set; }
        public bool Active => _windowView.Active;
        
        [SerializeField] private WindowView _windowView;

        public abstract void Open();

        public abstract void Close();

        protected void SetActive(bool isActive)
        {
            _windowView.Active = isActive;
        }
    }
}
