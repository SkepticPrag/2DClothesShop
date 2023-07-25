using Interaction;
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
            if (DetectInteractable())
            {
                IInteractable interactable = other.GetComponent<FurnitureInteract>();
                _interactableObject = interactable;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _interactableObject = null;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(detectionPoint.position, DetectionRadius);
        }
    }
}