using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace naa.AssemblingWords.Game
{
    public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [Inject] private Camera _camera;

        private Vector2 _startOffset;

        public void OnPointerDown(PointerEventData eventData)
        {
            _startOffset = GetMyScreenPosition() - eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            var nearCell = FindNearCells();
            if (nearCell is null)
            {
                return;
            }

            transform.position = nearCell.transform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            SetPosition(eventData.position);
        }

        private void SetPosition(Vector2 screenPoint)
        {
            var worldPosition = _camera.ScreenToWorldPoint(screenPoint + _startOffset);
            worldPosition.z = 0;
            transform.position = worldPosition;
        }

        private CellLetter FindNearCells()
        {
            var nearestCell = Physics2D.OverlapBoxAll(transform.position, Vector2.one, 0)
                .Where(c => c.CompareTag(CellLetter.Tag))
                .OrderBy(c => (c.transform.position - transform.position).sqrMagnitude)
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
