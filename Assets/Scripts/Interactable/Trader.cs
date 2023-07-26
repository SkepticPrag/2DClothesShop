using System.Runtime.CompilerServices;
using UnityEngine;

namespace Interactable
{
    public class Trader : MonoBehaviour,  IInteractable
    {
        public void Interact()
        {
            Debug.Log("Open Shop");
        }

        public void CancelInteraction()
        {
            Debug.Log("Cancel Interaction");
        }
    }
}
