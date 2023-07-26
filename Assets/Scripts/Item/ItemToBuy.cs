using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Item to Buy")]
    public class ItemToBuy : ScriptableObject
    {
        public new string name;

        public Sprite artwork;

        public int price;

        public RuntimeAnimatorController animationToPlay;

        public enum ClothesType
        {
            Hat,
            Hair,
            Clothes
        };

        public ClothesType clothesType;
    }
}