using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using System.Linq;

public enum PlayerState
{
	Walk,
	Idle,
	Attack,
	Stagger
}
public class PlayerMovement : MonoBehaviour
{
	public PlayerState currentState;
	public int health;
	public float moveSpeed = 5f;
	    AnimatorClipInfo[] m_CurrentClipInfo;
    string m_ClipName;
	public Rigidbody2D rb;
	public Animator animator;
	Vector2 movement;
	public MovementEvents moveEvent;
	HealthBar healthBar;

	public AnimationClip[] clip;
	

	int dir;

	void Start()
	{
		
		GameObject healthBarObj = GameObject.FindGameObjectWithTag ("HealthBar");
		healthBar = healthBarObj.GetComponent<HealthBar> ();
		healthBar.SetHealth(health);
		currentState = PlayerState.Walk;
		dir = GetDirection();

		var animatorOverrideController = (AnimatorController)animator.runtimeAnimatorController;
		var state = animatorOverrideController.layers[0].stateMachine.states.FirstOrDefault(s => s.state.name.Equals("Default")).state;
		if (state == null)
		{
    		Debug.Log("Couldn't get the state!");
    		
		}
		else
		{
			animatorOverrideController.SetStateEffectiveMotion(state, clip[dir]);
		}

	}
    // Update is called once per frame
    void Update()
    {

		/*if(currentState == PlayerState.Stagger)
		{
			Debug.Log("Player staggered");
		}*/
		if(currentState == PlayerState.Walk)
		{
		if(moveEvent.x == 1)
		{
			animator.SetBool("Init", false);
			movement.x = 1;
			
		}
		else if(moveEvent.x == -1)
		{
			movement.x = -1;
			animator.SetBool("Init", false);
		}
		else
		{
			movement.x = 0;
		}
		
		if (moveEvent.y == 1)
		{
			animator.SetBool("Init", false);
			movement.y = 1;
		}
		else if (moveEvent.y == -1)
		{
			animator.SetBool("Init", false);
			movement.y = -1;
		}
		else
		{
			movement.y = 0;
		}
		
		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		if(movement.x == 0 && movement.y == 0)
		{
		}
		else
		{
			animator.SetFloat("LastX",movement.x);
			animator.SetFloat("LastY",movement.y);
			animator.SetFloat("HitX",movement.x);
			animator.SetFloat("HitY",movement.y);
		}
		animator.SetFloat("Speed", movement.sqrMagnitude);
		animator.SetInteger("Direction", dir);
		}
    }
	
	void FixedUpdate()
	{
		if(currentState == PlayerState.Walk)
			rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}

	public void SetDirection(int d)
	{
		dir = d;
	}

	public int GetDirection()
	{
		return dir;
	}

	public void Knock(float knockbackTime)
	{
		StartCoroutine(KnockCo(knockbackTime));
	}

	IEnumerator KnockCo(float knockbackTime)
    {
		health--;
		healthBar.SetHealth(health);
        yield return new WaitForSeconds(knockbackTime);
        rb.velocity = Vector2.zero;
		currentState = PlayerState.Walk;
        //Debug.Log("Collider is " + collider.name);
        //Debug.Log("player knocked");
        /*if(collider.CompareTag("Enemy"))
        {
            Debug.Log("Enemy tag detected");
            enemyRB.GetComponent<Enemy>().currentState = EnemyState.Idle;
        }*/
        //enemyRB.isKinematic = true;
    }
}
