using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter2 : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public bool isGround;
    float timerY; //空格计时器

    public float Spring;
    bool isLadder;
    bool isClimbing;
    float vertical;
    public float climbSpeed=1f;

    Rigidbody2D rigidbody2d;
    SpriteRenderer SpriteRenderer;
    Animator animator;
    Damageable2 playerDamageable;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        SpriteRenderer = transform.GetComponent<SpriteRenderer>();
        animator=transform.GetComponent<Animator>();
        
        playerDamageable = transform.GetComponent<Damageable2>();
        playerDamageable.onDead+=this.onDead;
        playerDamageable.onHurt+=this.onHurt;


        HP._instance.InitHP(playerDamageable.health);
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space) && isGround){
            timerY=0;
            SetSpeedY(speedY);
        }
        if(Input.GetKey(KeyCode.Space)){
            timerY+=Time.deltaTime;
            if(timerY < 0.2f){
            SetSpeedY(speedY);
            }
        }

        if(Input.GetKey(KeyCode.A)){
            SetSpeedX(-speedX);
        }

        if(Input.GetKey(KeyCode.D)){
            SetSpeedX(speedX);
        }

        if(!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D)){
            SetSpeedX(0);
        }

        CheckGround();
        animator.SetBool("isJump" , !isGround);

        //Climb Ladder
        vertical =  Input.GetAxis("Vertical");

        if(isLadder && Mathf.Abs(vertical) > 0f){
            isClimbing = true;
            SetSpeedY(vertical*climbSpeed);
        }
    }


    public void SetSpeedX(float x){
        //动画状态机
        animator.SetBool("isRun" , x != 0);
        //翻转人物
        if(x < 0) {
            SpriteRenderer.flipX=true;
        }else if(x>0){
            SpriteRenderer.flipX=false;
        }
        rigidbody2d.velocity = new Vector2(x,rigidbody2d.velocity.y);
    }

    public void SetSpeedY(float y){
        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x,y);
    }

    public void CheckGround(){
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position , Vector3.down, 0.2f,1<<31);       
        isGround=raycastHit2D;

        if(raycastHit2D != null){

        }
    }

//  Collision检测器
    public void OnCollisionEnter2D(Collision2D obj){
        if(obj.gameObject.CompareTag("mushroom")){
            SetSpeedY(Spring);
        }
    }


//  Trigger检测器
    public void OnTriggerEnter2D(Collider2D obj){
        if(obj.CompareTag("Ladder")){
            isLadder = true;
            rigidbody2d.gravityScale=0f;
        }


    }

    public void OnTriggerExit2D(Collider2D obj){
        if(obj.CompareTag("Ladder")){
            isLadder = false;
            isClimbing = false;
            rigidbody2d.gravityScale=5f;
        }
    }
//-------------

    public void onHurt(){
        animator.SetTrigger("Hurt");
        HP._instance.UpdateHP(playerDamageable.health);
    }

    public void onDead(){
        Debug.Log("DEEEEEEEEEEEEAD");
    }

    public void Attack(){
        Debug.Log("DEEEEEEEEEEEEAD");
    }
}
