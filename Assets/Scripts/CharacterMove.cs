using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    Vector2 startPos; // Starting position of the touches on screen
    Vector2 endPos; // Ending position of the touches on the screen
    Vector2 directionIn2D; // 2D Vector from startpos to endpos
    Vector3 directionIn3D; // 3D Vector of the 2D Vector from startpos to endpos
    Vector3 directionLocalToWorld; // 3D direction vector according to which direction character faces.(from local to world)
    bool moving = false; // bool for to determine if the character is moving right or left
    float timer; // timer for how many seconds to move left or right
    Rigidbody rb;
    GameObject Camera;
    Vector3 distance;
    bool squat = false;
    public float speed =15f;
    int position = 2;
    Animator animController;
    
    bool jumping = false;
    void Start(){
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f,0f,speed); // setting velocity at the beginning
        Camera = GameObject.Find("Main Camera");
        distance = Camera.transform.position - this.transform.position;
        animController = this.GetComponent<Animator>();
    }

    
    void Update(){
        CameraFollow();
        CalculateDashDirection();
        if(speed < 45){
            speed += 0.3f*Time.deltaTime;
        }
        if(rb.velocity.y == 0 && jumping == true){
            jumping = false;
            animController.SetBool("isJumping",false);
        }
    }

    private void FixedUpdate() {
        if(moving == true){
            timer -= Time.fixedDeltaTime;// decreasing timer
        }
        if(timer < 0f){ // if time is up then not allowing to move left or right and setting velocity 
            rb.velocity = new Vector3(0f,0f,speed);
            moving = false;
            timer = 0f; 
        }
    }

    private void CalculateDashDirection(){
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began ){
                startPos = touch.position; 
            }
            // dash left or right
            else if(touch.phase == TouchPhase.Ended){
                endPos = touch.position;
                directionIn2D = endPos - startPos; // Calculating 2D vector on the screen
                if(Mathf.Abs(directionIn2D.x) > 50f && Mathf.Abs(directionIn2D.y) < 200f && moving == false){
                    directionIn3D = new Vector3(directionIn2D.x,0f,directionIn2D.y);
                    directionLocalToWorld = transform.TransformDirection(directionIn3D); // Calculating world space vectors
                    timer = 0.3f;
                    Dash(directionLocalToWorld);
                    moving = true;
                }
                // jump
                else if(directionIn2D.y > 50f && Mathf.Abs(directionIn2D.x) < 200f){
                    if(squat == false && jumping == false){
                        rb.velocity = new Vector3(0f,12f,speed);
                        jumping = true;
                        animController.SetBool("isJumping",true);
                    }
                }
                
                else if(directionIn2D.y < -50f && Mathf.Abs(directionIn2D.x) < 200f){
                    squat = true;
                    animController.SetBool("isSliding",true);
                    Invoke("RunningAgain",1f);
                }
            }
        }
    }

    private void Dash(Vector3 DashDirection){
        if(DashDirection.x > 0f && position+1 < 4){ // Dash to right
            position++;
            rb.velocity = new Vector3(12f,0f,speed);
        }
        else if(DashDirection.x < 0f && position-1 > 0){ // Dash to left
            position--;
            rb.velocity = new Vector3(-12f,0f,speed);
        }
    }
    // CameraFollow
    private void CameraFollow(){
        Camera.transform.position = this.transform.position + distance;
    }

    private void RunningAgain(){
        animController.SetBool("isSliding",false);
        squat = false;
    }

}
