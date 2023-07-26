using UnityEngine;

namespace Interactable
{
    public class Trader : MonoBehaviour,  IInteractable
    {
        [SerializeField] private GameObject blacksmithShop;
        public void Interact()
        {
            blacksmithShop.SetActive(true);
        }

        public void CancelInteraction()
        {
            blacksmithShop.SetActive(false);
        }
    }
}
