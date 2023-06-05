using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class itemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform originalparent;
    public inventory myBag;
    private int currentItemID;
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        originalparent = transform.parent;
        currentItemID = originalparent.GetComponent<slot>().slotID;
        transform.SetParent(transform.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "Item Image")
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
            //在真实的列表中改变顺序
            var temp = myBag.itemList[currentItemID];
            myBag.itemList[currentItemID] = myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID];
            myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID] = temp;

            eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalparent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalparent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
        myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID] = myBag.itemList[currentItemID];
        myBag.itemList[currentItemID] = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true; 
    }//接口技术

    // Start is called before the first frame update
    
}
