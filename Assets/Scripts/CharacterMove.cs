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
    Transform camera;
    public GameObject heartOne;
    public GameObject heartTwo;
    public GameObject heartThree;
    Vector3 distance;
    bool squat = false;
    public float speed = 10f;
    int position = 2;
    Animator animController;
    private Vector3 pausedSpeed;

    bool inputFlag = false;


    bool jumping = false;
    void Start(){
        rb = GetComponent<Rigidbody>();
        heartOne = GameObject.Find("heart1");
        heartTwo = GameObject.Find("heart2");
        heartThree = GameObject.Find("heart3");
        rb.velocity = new Vector3(0f,0f,speed); // setting velocity at the beginning
        animController = this.GetComponent<Animator>();
        StopCharacter();
        camera = Camera.main.transform;
        distance = camera.position - this.transform.position;
    }

    
    public void StartMovement()
    {
        rb.velocity = pausedSpeed;
        animController.speed = 1;

    }

    void Update(){
        if (!GameManager.I.canPlay)
        {
            inputFlag = false;
            return;
        }
        CameraFollow();
        CalculateDashDirection();
        CharacterMovement();
    }

    private void CharacterMovement()
    {   
        if (speed < 25)
        {
            speed += 0.4f * Time.deltaTime;
        }
        if (rb.velocity.y == 0 && jumping == true)
        {
            jumping = false;
            animController.SetBool("isJumping", false);
        }
    }

    private void FixedUpdate() {
        if (!GameManager.I.canPlay) return;

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
            if(touch.phase == TouchPhase.Began  && !inputFlag){
                startPos = touch.position;
                inputFlag = true;
            }
            // dash left or right
            else if(touch.phase == TouchPhase.Ended && inputFlag){
                inputFlag = false;
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
                // lean
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
        camera.position = this.transform.position + distance;
    }

    private void RunningAgain(){
        animController.SetBool("isSliding",false);
        squat = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            HitObstacle();
        }
    }

    public void HitObstacle()
    {
        GameManager.I.Fail();
        heartOne.SetActive(false);
        heartTwo.SetActive(false);
        heartThree.SetActive(false);
    }

    public void StopCharacter()
    {
        pausedSpeed = rb.velocity;
        rb.velocity = Vector3.zero;
        animController.speed = 0f;
    }
}
