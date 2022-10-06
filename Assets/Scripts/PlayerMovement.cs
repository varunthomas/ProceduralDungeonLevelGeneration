using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	public Animator animator;
	Vector2 movement;
	public Joystick joystick;

    // Update is called once per frame
    void Update()
    {

		if (joystick.Horizontal > .2f)
		{
			movement.x = 1;
		}
		else if (joystick.Horizontal <= -.2f)
		{
			movement.x = -1;
		}
		else
		{
			movement.x = 0;
		}

		if (joystick.Vertical > .2f)
		{
			movement.y = 1;
		}
		else if (joystick.Vertical <= -.2f)
		{
			movement.y = -1;
		}
		else
		{
			movement.y = 0;
		}
		
		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		animator.SetFloat("Speed", movement.sqrMagnitude);

    }
	
	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}
}
