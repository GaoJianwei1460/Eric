using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Item",menuName ="inventoryScripts/New Item")]
public class item:ScriptableObject
{
    // Start is called before the first frame update
    public string itemName;
    public Sprite itemImage;
    public int itemHeld;
    [TextArea]
    public string itemInfo;

    public bool equip;
}
