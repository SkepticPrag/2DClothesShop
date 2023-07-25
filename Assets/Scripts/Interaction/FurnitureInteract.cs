using Player;
using UnityEngine;

namespace Interaction
{
    public class FurnitureInteract : MonoBehaviour, IInteractable
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _coinCounter = other.GetComponent<CoinCounter>();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _coinCounter = null;
        }
    }
}