using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float playerVelocity;
    public float jumpForce;
    //public float moveForce;
    public float maxVelocity;

    private Rigidbody2D rb2d;
    private bool isJumping;


    private bool birdActive, batActive;
    private bool canSpreadWings;

    [SerializeField]
    private Sprite wingedSprite;
    [SerializeField]
    private Sprite normalSprite;

    void Awake () {
        //initialize
        rb2d = GetComponent<Rigidbody2D>();
        birdActive = false;  //can't fly
        batActive = false;   //can't move upsid down
        canSpreadWings = false;
    }
	
	void Update () {

        if(Input.GetKeyDown(KeyCode.Space)){
            //player is jumping
            isJumping = true;
        }
	}

    private void FixedUpdate()
    {

        if (!birdActive && !batActive)
            MoveAsHuman();
        else if (batActive)
            MoveAsLizard();
        else
            FlyAsBird();

        if(Input.GetKeyDown(KeyCode.B) && !birdActive){

            batActive = !batActive;
            //if bat is equipped, invert gravity
            InvertGravity();
        }
        else if(Input.GetKeyDown(KeyCode.F) && canSpreadWings){

            if (birdActive){ //gravity was set to 0, need to reassign it

                //change sprite back
                GetComponent<SpriteRenderer>().sprite = normalSprite;
                GetComponent<Rigidbody2D>().gravityScale = 1;
                batActive = false;
            }

            birdActive = !birdActive;
        }

       
        if(this.transform.position.y <= -7 || this.transform.position.y >= 50){
            GameSceneManager.instance.PlayerLosesALife();
        }
    }

    private void InvertGravity(){

        GetComponent<Rigidbody2D>().gravityScale *= -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("PointPickup")){

            GameSceneManager.instance.ShamrockPickedUp();
            //destroy pickup
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("EnemyTag")){
            //player loses a life
            GameSceneManager.instance.PlayerLosesALife();
            //Destroy the enemy
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Goal")){
            //Level cleared
            GameSceneManager.instance.PlayerClearsLevel();
        }
        if(collision.gameObject.CompareTag("Wings")){
            //Can equip wings and fly
            canSpreadWings = true;
            Destroy(collision.gameObject);
        }

    }

    private void MoveAsHuman(){

        //walk on platforms, jump

        if (Input.GetKey(KeyCode.LeftArrow) && !isJumping)
        {
            if (Mathf.Abs(rb2d.velocity.x) < maxVelocity)
            {
                rb2d.AddForce(Vector2.left * playerVelocity);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !isJumping)
        {
            if (Mathf.Abs(rb2d.velocity.x) < maxVelocity)
            {
                rb2d.AddForce(Vector2.right * playerVelocity);
            }
        }

        if (isJumping)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            isJumping = false;
        }
    }

    private void FlyAsBird(){

        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<SpriteRenderer>().sprite = wingedSprite;

        if (Input.GetKey(KeyCode.LeftArrow))
            rb2d.AddForce(Vector2.left * playerVelocity / 2);
        else if (Input.GetKey(KeyCode.RightArrow))
            rb2d.AddForce(Vector2.right * playerVelocity / 2);
        else if (Input.GetKey(KeyCode.UpArrow))
            rb2d.AddForce(Vector2.up * playerVelocity / 2);
        else if (Input.GetKey(KeyCode.DownArrow))
            rb2d.AddForce(Vector2.down * playerVelocity / 2);

    }

    private void MoveAsLizard(){

        if (Input.GetKey(KeyCode.LeftArrow) && !isJumping)
        {
            if (Mathf.Abs(rb2d.velocity.x) < maxVelocity)
            {
                rb2d.AddForce(Vector2.left * playerVelocity);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !isJumping)
        {
            if (Mathf.Abs(rb2d.velocity.x) < maxVelocity)
            {
                rb2d.AddForce(Vector2.right * playerVelocity);
            }
        }

        if(isJumping){
            rb2d.AddForce(Vector2.down * jumpForce);
            isJumping = false;
        }
    }
}
