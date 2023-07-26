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

        public void Start()
        {
            itemName.text = itemToBuy.name;
            artwork.sprite = itemToBuy.artwork;
            price.text = itemToBuy.price.ToString();
        }
    }
}