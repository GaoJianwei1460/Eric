using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yidongpingtai : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float speed;
    bool isMoveToEnd = true;

    Rigidbody2D rigidbody2d;

    public ContactFilter2D contactFilter;
    ContactPoint2D[] contactPoint = new ContactPoint2D[10];

    private void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        
    }

    public void FollowObjects(){
        int count = rigidbody2d.GetContacts(contactFilter, contactPoint);
        for(int i = 0;i<count;i++){
            contactPoint[i].rigidbody.velocity += new Vector2(isMoveToEnd?  speed : -speed,0);
        }
    }
    private void LateUpdate(){
       
    }


    void Update() {
           
        if(isMoveToEnd)
    {
        transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        if(transform.position == endPos){
            isMoveToEnd = false;
        }
    
}      else{
    transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        if(transform.position == startPos){
                   isMoveToEnd = true;
        }
            }
             FollowObjects();
    }
 
}