using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class slot : MonoBehaviour
{
    // Start is called before the first frame update
    public int slotID;//ŒÔ∆∑À≥–Ú
    public item slotItem;
    public Image slotImage;
    public TMP_Text slotNum;
    public GameObject itemInSlot;
    public string slotInfo;
    public void itemOnClicked()
    {
        inventoryManager.updateItemInfo(slotInfo);
    }
    public void SetupSlot(item item)
    {
        if (item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }
        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;
    }
}
