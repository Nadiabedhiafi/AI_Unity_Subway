using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 200f;
    public float jumpForce = 500f;
    public LayerMask groundLayer;

    public enum PlayerPosition { Left, Center, Right };
    public PlayerPosition currentPosition = PlayerPosition.Center;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, speed * Time.deltaTime);

        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f, groundLayer))
        {
            Debug.DrawRay(transform.position, Vector3.down * 1.1f, Color.red); 
            
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                rb.useGravity = false;
                rb.velocity = new Vector3(0, 0, speed * Time.deltaTime);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.down * 1.1f, Color.green); 
            
            rb.useGravity = true;
        }
    }

    
    void MoveRight()
    {
        if (currentPosition == PlayerPosition.Left)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            currentPosition = PlayerPosition.Center;
        }
        else if (currentPosition == PlayerPosition.Center)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            currentPosition = PlayerPosition.Right;
        }
    }

    
    void MoveLeft()
    {
        if (currentPosition == PlayerPosition.Right)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            currentPosition = PlayerPosition.Center;
        }
        else if (currentPosition == PlayerPosition.Center)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            currentPosition = PlayerPosition.Left;
        }
    }

    
    void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
