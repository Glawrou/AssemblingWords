using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using System;

namespace naa.AssemblingWords.Game
{
    public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public event Action<CellLetter> OnPutInCell;
        public event Action OnPickUp;

        public Transform Center;

        [SerializeField] private RectTransform _rectTransform;

        [Inject] private Camera _camera;

        private float RectToWordFactor = 0.005f;

        private Vector2 _startOffset;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnPickUp?.Invoke();
            _startOffset = GetMyScreenPosition() - eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            var nearCell = FindNearCells();
            if (nearCell is null)
            {
                return;
            }

            transform.position = nearCell.transform.position + Center.position - transform.position;
            OnPutInCell?.Invoke(nearCell);
        }

        public void OnDrag(PointerEventData eventData)
        {
            SetPosition(eventData.position);
        }

        public void SetPosition(Vector2 screenPoint)
        {
            var worldPosition = _camera.ScreenToWorldPoint(screenPoint + _startOffset);
            worldPosition.z = 0;
            transform.position = worldPosition;
        }

        private CellLetter FindNearCells()
        {
            var xOffset = Vector3.Distance(Center.position, transform.position) * 2f;
            var nearestCell = Physics2D.OverlapBoxAll(_rectTransform.transform.position, _rectTransform.rect.size * RectToWordFactor, 0)
                .Where(c => c.CompareTag(CellLetter.Tag))
                .OrderBy(c => Vector3.Distance(c.transform.position, Center.position + Vector3.right * xOffset))
                .FirstOrDefault();

            if (nearestCell is null)
            {
                return null;
            }

            return nearestCell.GetComponent<CellLetter>();
        }

        private Vector2 GetMyScreenPosition()
        {
            return _camera.WorldToScreenPoint(transform.position);
        }
    }
}
