using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class moveBag : MonoBehaviour, IDragHandler
{
    public Canvas canvas;
    RectTransform currentRect;
    public void OnDrag(PointerEventData eventData)
    {
        currentRect.anchoredPosition += eventData.delta;//基础值+=轻微的鼠标移动，防止其掉到画面外
    }

    // Start is called before the first frame update
  
 void Awake()
    {
        currentRect.GetComponent<RectTransform>();
    }
    
}