using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;
    private bool isDoorOpen = false;
    private int setPassword;

    // 开启门
    public void OpenDoor()
    {
        if (!isDoorOpen)
        {
            doorAnimator.SetBool("IsOpen", true);
            isDoorOpen = true;
        }
    }

    // 关闭门
    public void CloseDoor()
    {
        if (isDoorOpen)
        {
            doorAnimator.SetBool("IsOpen", false);
            isDoorOpen = false;
        }
    }

    // 检查解密窗口中输入的数字是否正确
    private bool CheckPassword(int password)
    {
        // 在这里实现你的检查逻辑
        return password == setPassword;
    }
    
    // 触发器接近时调用的方法
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 显示提示信息和解密窗口
            Debug.Log("Press E to open the password window.");
            // TODO: 显示解密窗口并禁用门的交互能力
        }
    }
}