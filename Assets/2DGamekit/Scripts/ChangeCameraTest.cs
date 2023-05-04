using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private CinemachineVirtualCamera cine;
    private float totaltime;
    void Start()
    {
        changefollow();
    }

    // Update is called once per frame
    void Update()
    {
        totaltime += Time.deltaTime;
        if (totaltime >= 5)
        {
            reverse();
        }
    }
    public void changefollow()
    {
        cine = GameObject.FindGameObjectWithTag("cineMachine").GetComponent<CinemachineVirtualCamera>();
        GameObject ChangeCamera = GameObject.Find("ChangeCamera").gameObject;

        cine.Follow = ChangeCamera.GetComponent<Transform>();
    }
    public void reverse()
    {
        cine = GameObject.FindGameObjectWithTag("cineMachine").GetComponent<CinemachineVirtualCamera>();
        GameObject player = GameObject.Find("Ellen").gameObject;
        cine.Follow = player.transform;
    }
}
