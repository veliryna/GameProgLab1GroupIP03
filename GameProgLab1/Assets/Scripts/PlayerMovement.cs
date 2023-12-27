using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public bool isJumping;
    private float horizontalInput;
    private Rigidbody2D body;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(speed*horizontalInput, body.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space) && isJumping == false){
            body.AddForce(new Vector2(body.velocity.x, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Ground")){
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.CompareTag("Ground")){
            isJumping = true;
        }
    }
}
