using UnityEngine;

namespace Game
{
    public class ExitGame : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Quit");
                Application.Quit();
            }
        }
    }
}
