using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    Rigidbody2D minotaurRB;
    Animator anim;
    GameObject player;
    Rigidbody2D hitRb;
    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.Idle;
        player = GameObject.FindGameObjectWithTag ("Player");
        target = player.transform;
        hitRb = player.GetComponent<Rigidbody2D> ();
        minotaurRB = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        TriggerEnemyAction();
        //AttackPlayer();
    }

    void TriggerEnemyAction()
    {
        
        /*if(health <= 0)
        {
            if(currentState != EnemyState.Dead)
            {
                Debug.Log("Enemy died");
                StartCoroutine(DeathCo());
            }
        }
        else */if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius) // Move to player
        {
            if(currentState == EnemyState.Idle || currentState == EnemyState.Walk)
            {
                //Debug.Log("Walking to player");
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed*Time.deltaTime);
                
                minotaurRB.MovePosition(temp);
                anim.SetBool("Seen", true);
                //anim.SetTrigger("Seen");
                if(target.position.x < transform.position.x )
                {
                    anim.SetFloat("MoveX", -1);
                }
                else
                {
                    anim.SetFloat("MoveX", 1);
                }
                ChangeState(EnemyState.Walk);
            }
        }
        else if(Vector3.Distance(target.position, transform.position) <= attackRadius) //Attack player
        {
            //anim.SetBool("Seen", false);
            if(currentState != EnemyState.Attack && currentState != EnemyState.Dead)
            {
                StartCoroutine(AttackCo());
                Debug.Log("In attacking range");
		    

                if(player.GetComponent<PlayerMovement>().currentState != PlayerState.Stagger)
                {
                    Vector2 difference = target.position - transform.position;
                    difference = difference.normalized * 4f;
                    hitRb.AddForce(difference, ForceMode2D.Impulse);
                    hitRb.GetComponent<PlayerMovement>().currentState = PlayerState.Stagger;
                    player.GetComponent<PlayerMovement>().Knock(0.4f);
                    Debug.Log("Collider is player force is " + difference);
                }
            }
            
        }
        else    //Stop moving
        {
            anim.SetBool("Seen", false);
            Debug.Log("Stop moving");
            ChangeState(EnemyState.Idle);
        }
    }

    IEnumerator AttackCo()
    {
            Debug.Log("Start attack anim");
            ChangeState(EnemyState.Attack);
            //minotaurRB.velocity = Vector2.zero;
            anim.SetTrigger("Attack");
            yield return new WaitForSeconds(0.7f);
            ChangeState(EnemyState.Walk);
            Debug.Log("End attack anim");
            
    }

    public void TriggerDeath()
    {
        Debug.Log("Triggering death");
        StartCoroutine(DeathCo());
    }
    IEnumerator DeathCo()
    {
        ChangeState(EnemyState.Dead);
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Dead");
        gameObject.SetActive(false);
    }
    void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
