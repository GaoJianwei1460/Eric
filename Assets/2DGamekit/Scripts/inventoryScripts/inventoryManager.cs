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
        //����һ���µ�Slot�����Դ洢�Ӷ�ӦItem�л�õ�����
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        //�������õ���Ʒ������Grid(������)��

        //���Slot�б����ĸ�ֵ(��ȡ��Ҫ������)
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
        //Ϊ�˱������ĸ��ӻ��ң����￼�ǽ�Grid��ȫ��������գ������´����ݿ��л�ȡ���º����Ϣ
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            //CreateNewItem(instance.myBag.ItemList[i]);//�����ݿ������е���Ʒ��Ϣȫ���������(����)
            //----------->instance.slots.Add(Instantiate(instance.emptySlot));//����Slot����ӵ��б���
            //----------->instance.slots[i].transform.SetParent(instance.slotGrid.transform);//�����ɵ�Slot��ӵ�Grid��
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<slot>().slotID = i;
            instance.slots[i].GetComponent<slot>().SetupSlot(instance.myBag.itemList[i]);
        }
    }

}
