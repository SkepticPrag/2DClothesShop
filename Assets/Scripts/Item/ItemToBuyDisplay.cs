using Player;
using Shop;
using UnityEngine;
using TMPro;
using UnityEditor.Animations;
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
        public AnimatorController clothesAnimation;

        public void Start()
        {
            itemName.text = itemToBuy.name;
            artwork.sprite = itemToBuy.artwork;
            price.text = itemToBuy.price.ToString();
            priceInt = itemToBuy.price;
            clothesType = itemToBuy.clothesType;
            clothesAnimation = itemToBuy.animationToPlay;
            buyButton.onClick.AddListener(() => ShopManager.Instance.BuyItem(this));
        }

        public void EquipItem(PlayerClothes playerClothes)
        {
            switch (clothesType)
            {
                case ItemToBuy.ClothesType.Hat:
                    if (playerClothes.hatRenderer.runtimeAnimatorController != clothesAnimation)
                        playerClothes.hatRenderer.runtimeAnimatorController = clothesAnimation;
                    break;
                case ItemToBuy.ClothesType.Hair:
                    if (playerClothes.hatRenderer.runtimeAnimatorController != clothesAnimation)
                        playerClothes.hairRenderer.runtimeAnimatorController = clothesAnimation;
                    break;
                case ItemToBuy.ClothesType.Clothes:
                    if (playerClothes.hatRenderer.runtimeAnimatorController != clothesAnimation)
                        playerClothes.clothesRenderer.runtimeAnimatorController = clothesAnimation;
                    break;
            }
        }
    }
}