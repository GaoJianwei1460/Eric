using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    static inventoryManager instance;
    public inventory myBag;
    public GameObject slotGrid;
    //public slot slotPrefab;
    public GameObject emptySlot;
    public TMP_Text itemInformation;
    public List<GameObject> slots = new List<GameObject>();
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    public void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "info:";
    }
    /*public static void CreateNewItem(item item)
    {
        slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        //创建一个新的Slot，用以存储从对应Item中获得的数据
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        //将创建好的物品附着在Grid(背包栏)上

        //完成Slot中变量的赋值(获取需要的数据)
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();

    }*/
   public static void updateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription; 
    }
    public static void RefreshItem()
    {
        //为了避免代码的复杂混乱，这里考虑将Grid中全部内容清空，并重新从数据库中获取更新后的信息
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            //CreateNewItem(instance.myBag.ItemList[i]);//将数据库中所有的物品信息全部重新添加(舍弃)
            //----------->instance.slots.Add(Instantiate(instance.emptySlot));//生成Slot并添加到列表中
            //----------->instance.slots[i].transform.SetParent(instance.slotGrid.transform);//将生成的Slot添加到Grid中
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<slot>().slotID = i;
            instance.slots[i].GetComponent<slot>().SetupSlot(instance.myBag.itemList[i]);
        }
    }

}
