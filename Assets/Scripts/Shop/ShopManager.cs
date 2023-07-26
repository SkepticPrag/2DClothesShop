using Item;
using Player;
using UnityEngine;

namespace Shop
{
    public class ShopManager : MonoBehaviour
    {
        public static ShopManager Instance;
        public PlayerClothes playerClothes;
        public CoinCounter playerCoins;

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

        public void BuyItem(ItemToBuyDisplay itemToBuyDisplay)
        {
            if (playerCoins.coinCount <= itemToBuyDisplay.priceInt) return;
            
            playerCoins.coinCount -= itemToBuyDisplay.priceInt;
            itemToBuyDisplay.price.text = "Sold";
            itemToBuyDisplay.butButtonText.text = "Equip";
            itemToBuyDisplay.buyButton.onClick.RemoveAllListeners();
            itemToBuyDisplay.buyButton.onClick.AddListener(() => itemToBuyDisplay.EquipItem(playerClothes));
        }
    }
}