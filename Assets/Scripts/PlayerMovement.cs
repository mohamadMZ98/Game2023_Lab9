using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidBody;

    [SerializeField]
    //[Range(0, 100)]
    private float Speed = 10;

    [SerializeField]
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 oldPosition = transform.position;



       

        Vector3 velocity = new Vector3(xInput, yInput, 0) * Speed;
        //transform.position = oldPosition + new Vector3(xInput, yInput, 0) * Speed * Time.deltaTime;
        animator.SetFloat("Speed", velocity.sqrMagnitude);

        WalkAnimationController facing = WalkAnimationController.SOUTH;

        if(velocity.x > 0)
        {
            facing = WalkAnimationController.EAST;
            
        }else if (velocity.x < 0)
        {
            facing = WalkAnimationController.WEST;
        }
        else if (velocity.y > 0)
        {
            facing = WalkAnimationController.NORTH;
        }
        else if (velocity.y < 0)
        {
            facing = WalkAnimationController.SOUTH;
        }

        animator.speed = Speed;

        animator.SetInteger("FacingDirection", (int) facing);
            
        rigidBody.MovePosition(oldPosition + velocity * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collided with: " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player triggered with: " + collision.gameObject.name);
    }
}
