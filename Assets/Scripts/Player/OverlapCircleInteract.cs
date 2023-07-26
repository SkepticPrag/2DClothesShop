using Interactable;
using UnityEngine;

namespace Player
{
    public class OverlapCircleInteract : MonoBehaviour
    {
        [SerializeField] private Transform detectionPoint;
        [SerializeField] private LayerMask detectionLayer;
        private IInteractable _interactableObject;
        private const float DetectionRadius = 0.5f;

        private void Update()
        {
            if (DetectInteractable())
            {
                if (InteractInput())
                {
                    _interactableObject?.Interact();
                }
            }
        }

        bool InteractInput()
        {
            return Input.GetKeyDown(KeyCode.E);
        }

        bool DetectInteractable()
        {
            return Physics2D.OverlapCircle(detectionPoint.position, DetectionRadius, detectionLayer);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<IInteractable>() == null) return;
            
            IInteractable interactable = other.GetComponent<IInteractable>();
            _interactableObject = interactable;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _interactableObject?.CancelInteraction();
            _interactableObject = null;
        }
    }
}