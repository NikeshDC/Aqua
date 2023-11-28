using UnityEngine;
using UnityEngine.UI;

public class InventoryItemDisplay : MonoBehaviour
{
    [SerializeField] private InventoryItem itemDetails;

    [SerializeField] Text itemName;
    [SerializeField] Image itemIcon;
    [SerializeField] Text itemCost;

    private void Start()
    {
        itemName.text = itemDetails.name;
        itemIcon.sprite = itemDetails.icon;
        itemCost.text = itemDetails.cost.ToString();
    }

}
