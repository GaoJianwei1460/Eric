using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject backpack;
    bool isOpen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Openbackpack();
    }
    void Openbackpack()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            backpack.SetActive(isOpen);
        }
    }
}
