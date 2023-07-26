using Shop;
using UnityEngine;

namespace Player
{
    public class CoinCounter : MonoBehaviour
    {
        public int coinCount;

        public void PickUpCoins()
        {
            var coinAmount = Random.Range(100, 500);

            coinCount += coinAmount;

            ShopManager.Instance.coinsText.text = "Coins Collected: " + coinCount.ToString();
        }
    }
}