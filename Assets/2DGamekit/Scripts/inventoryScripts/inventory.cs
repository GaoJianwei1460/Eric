using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Inventory",menuName ="inventoryScripts/New Inventory")]
public class inventory : ScriptableObject
{
    // Start is called before the first frame update
    public List<item> itemList = new List<item>();
}
