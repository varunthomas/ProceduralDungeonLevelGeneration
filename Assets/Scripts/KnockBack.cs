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
            
            collider.GetComponent<Enemy>().health--;
            if( collider.GetComponent<Enemy>().health <= 0)
            {
                collider.GetComponent<Minotaur>().TriggerDeath();
            }
            if(hitRb.GetComponent<Enemy>().currentState != EnemyState.Stagger && hitRb.GetComponent<Enemy>().currentState != EnemyState.Dead)
            {
                Vector2 difference = collider.transform.position - transform.position;
                difference = difference.normalized * force;
                hitRb.AddForce(difference, ForceMode2D.Impulse);
                hitRb.GetComponent<Enemy>().currentState = EnemyState.Stagger;
                collider.GetComponent<Enemy>().Knock(hitRb, knockbackTime);
                Debug.Log("Enemy health is " + collider.GetComponent<Enemy>().health);
            }
        }
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
