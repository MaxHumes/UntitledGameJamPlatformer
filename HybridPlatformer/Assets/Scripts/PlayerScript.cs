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

    void Awake () {
        //initialize
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	void Update () {

        if(Input.GetKeyDown(KeyCode.Space)){
            //player is jumping
            isJumping = true;
        }
	}

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && !isJumping){
            if(Mathf.Abs(rb2d.velocity.x) < maxVelocity){
                rb2d.AddForce(Vector2.left * playerVelocity);
            }
        }else if(Input.GetKeyDown(KeyCode.RightArrow) && ! isJumping){
            if (Mathf.Abs(rb2d.velocity.x) < maxVelocity)
            {
                rb2d.AddForce(Vector2.right * playerVelocity);
            }
        }

        if(isJumping){
            rb2d.AddForce(Vector2.up * jumpForce);
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("LivePickup")){
            //
            Debug.Log("1UP!");
            //destroy pickup
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("PointPickup")){

            Debug.Log("+10");
            //destroy pickup
            Destroy(collision.gameObject);
        }
    }
}
