using UnityEngine;

namespace Player
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField]private int coinCount;

        public void PickUpCoins()
        {
            var coinAmount = Random.Range(100, 500);

            coinCount += coinAmount;
        }
    }
}