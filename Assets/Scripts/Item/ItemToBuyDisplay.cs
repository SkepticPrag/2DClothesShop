using System;
using Player;
using Shop;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Item
{
    public class ItemToBuyDisplay : MonoBehaviour
    {
        public ItemToBuy itemToBuy;
        public TMP_Text itemName;
        public Image artwork;
        public TMP_Text price;
        public TMP_Text butButtonText;
        public Button buyButton;
        public int priceInt;
        public ItemToBuy.ClothesType clothesType;

        public void Start()
        {
            itemName.text = itemToBuy.name;
            artwork.sprite = itemToBuy.artwork;
            price.text = itemToBuy.price.ToString();
            priceInt = itemToBuy.price;
            clothesType = itemToBuy.clothesType;
            buyButton.onClick.AddListener(() => ShopManager.Instance.BuyItem(this));
        }

        public void EquipItem(PlayerClothes playerClothes)
        {
            switch (clothesType)
            {
                case ItemToBuy.ClothesType.Hat:
                    playerClothes.hatRenderer.sprite = artwork.sprite;
                    break;
                case ItemToBuy.ClothesType.Hair:
                    playerClothes.hairRenderer.sprite = artwork.sprite;
                    break;
                case ItemToBuy.ClothesType.Clothes:
                    playerClothes.clothesRenderer.sprite = artwork.sprite;
                    break;
            }
        }
    }
}