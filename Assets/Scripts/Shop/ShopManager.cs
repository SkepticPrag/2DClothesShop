using Item;
using Player;
using UnityEngine;
using TMPro;

namespace Shop
{
    public class ShopManager : MonoBehaviour
    {
        public static ShopManager Instance;
        [HideInInspector]
        public PlayerClothes playerClothes;
        [HideInInspector]
        public CoinCounter playerCoins;
        public TMP_Text coinsText;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            playerClothes = FindObjectOfType<PlayerClothes>();
            playerCoins = FindObjectOfType<CoinCounter>();
        }

        private void Start()
        {
            coinsText.text = "Coins Collected: " + playerCoins.coinCount.ToString();
        }

        public void BuyItem(ItemToBuyDisplay itemToBuyDisplay)
        {
            if (playerCoins.coinCount <= itemToBuyDisplay.priceInt) return;
            
            playerCoins.coinCount -= itemToBuyDisplay.priceInt;
            coinsText.text = "Coins Collected: " + playerCoins.coinCount.ToString();
            itemToBuyDisplay.price.text = "Sold";
            itemToBuyDisplay.butButtonText.text = "Equip";
            itemToBuyDisplay.buyButton.onClick.RemoveAllListeners();
            itemToBuyDisplay.buyButton.onClick.AddListener(() => itemToBuyDisplay.EquipItem(playerClothes));
        }
    }
}