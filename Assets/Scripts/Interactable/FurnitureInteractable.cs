using Player;
using UnityEngine;

namespace Interactable
{
    public class FurnitureInteractable : MonoBehaviour, IInteractable
    {
        private bool _interacted;
        private Animator _animator;
        private CoinCounter _coinCounter;
        private static readonly int HasInteracted = Animator.StringToHash("HasInteracted");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Interact()
        {
            if (_interacted) return;
            
            _interacted = true;
            _animator.SetBool(HasInteracted, _interacted);

            if (_coinCounter)
                _coinCounter.PickUpCoins();
        }

        public void CancelInteraction()
        {
            _coinCounter = null;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _coinCounter = other.GetComponent<CoinCounter>();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            CancelInteraction();
        }
    }
}