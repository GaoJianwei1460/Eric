using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMove : MonoBehaviour
{

  public float posX;
  public float posY;
  public int speed;
  
  void Update(){
    transform.position = new Vector2(posX,Mathf.PingPong(Time.time * speed , posY-3));
  }
}
