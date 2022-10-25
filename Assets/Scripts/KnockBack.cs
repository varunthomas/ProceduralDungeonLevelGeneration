using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    
    public float force;
    public float knockbackTime;
    void OnTriggerEnter2D(Collider2D collider)
	{

        if(collider.CompareTag("Enemy"))
        {
            Debug.Log("knockback script of " + gameObject.tag + " hit");
            Rigidbody2D hitRb = collider.GetComponent<Rigidbody2D>();
            if(hitRb.GetComponent<Enemy>().currentState != EnemyState.Stagger)
            {
                Vector2 difference = collider.transform.position - transform.position;
                difference = difference.normalized * force;
                hitRb.AddForce(difference, ForceMode2D.Impulse);
                hitRb.GetComponent<Enemy>().currentState = EnemyState.Stagger;
                collider.GetComponent<Enemy>().Knock(hitRb, knockbackTime);
                //Debug.Log("Collider is enemy force is " + difference);
            }
        }
        else if(collider.CompareTag("Player"))
        {
            Debug.Log("knockback other script of " + gameObject.tag + " hit");
            /*if(gameObject.GetComponent<Enemy>().currentState != EnemyState.Stagger && gameObject.GetComponent<Enemy>().currentState != EnemyState.Attack)
            {
                Animator anim;
                
                anim = gameObject.GetComponent<Animator>();
                anim.SetBool("Attack", true);
                gameObject.GetComponent<Enemy>().currentState = EnemyState.Attack;
            }*/
            /*Rigidbody2D hitRb = collider.GetComponent<Rigidbody2D>();
            if(hitRb.GetComponent<PlayerMovement>().currentState != PlayerState.Stagger)
            {
                Vector2 difference = collider.transform.position - transform.position;
                difference = difference.normalized * force;
                hitRb.AddForce(difference, ForceMode2D.Impulse);
                hitRb.GetComponent<PlayerMovement>().currentState = PlayerState.Stagger;
                collider.GetComponent<PlayerMovement>().Knock(knockbackTime);
                //Debug.Log("Collider is player force is " + difference);
            }*/
        }
        /*if(collider.CompareTag("Enemy") || collider.CompareTag("Player"))
        {
            Debug.Log("knockback script of " + gameObject.tag + " hit");
            //gameObject.SetActive(false);
            Rigidbody2D hitRb = collider.GetComponent<Rigidbody2D>();
            if(collider.CompareTag("Enemy") && hitRb.GetComponent<Enemy>().currentState != EnemyState.Stagger)
            {
                Vector2 difference = collider.transform.position - transform.position;
                difference = difference.normalized * force;
            //collider.transform.position = new Vector2(collider.transform.position.x + difference.x, collider.transform.position.y + difference.y);            //difference = difference.normalized*force;
                hitRb.AddForce(difference, ForceMode2D.Impulse);
                if(collider.CompareTag("Enemy"))
                {
                //Debug.Log("Collider is enemy");
                    hitRb.GetComponent<Enemy>().currentState = EnemyState.Stagger;
                    collider.GetComponent<Enemy>().Knock(hitRb, knockbackTime);
                }
                else if(collider.CompareTag("Player"))
                {
                    hitRb.GetComponent<PlayerMovement>().currentState = PlayerState.Stagger;
                    collider.GetComponent<PlayerMovement>().Knock(knockbackTime);
                //Debug.Log("Collider is player");
                }
            //enemyRB.isKinematic = false;
            
            if(collider.CompareTag("Player"))
            {
                Debug.Log("Collider is player force is " + difference);
            }
            else if(collider.CompareTag("Enemy"))
            {
                Debug.Log("Collider is enemy force is " + difference);
            }
            }
            //StartCoroutine(KnockCo(hitRb, collider));
        }*/
	}

    /*IEnumerator KnockCo(Rigidbody2D enemyRB, Collider2D collider)
    {
        yield return new WaitForSeconds(knockbackTime);
        enemyRB.velocity = Vector2.zero;
        Debug.Log("Collider is " + collider.name);
        Debug.Log("enemy vel set to 0");
        if(collider.CompareTag("Enemy"))
        {
            Debug.Log("Enemy tag detected");
            enemyRB.GetComponent<Enemy>().currentState = EnemyState.Idle;
        }
        //enemyRB.isKinematic = true;
    }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
