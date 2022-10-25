using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Attack,
    Walk,
    Stagger,
    Dead
}
public class Enemy : MonoBehaviour
{
    public int health;
    //public string name;
    public float moveSpeed;
    public EnemyState currentState;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Knock(Rigidbody2D rb, float knockbackTime)
	{
		StartCoroutine(KnockCo(rb, knockbackTime));
	}
	
	IEnumerator KnockCo(Rigidbody2D rb, float knockbackTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.velocity = Vector2.zero;
        //Debug.Log("Collider is " + collider.name);
        Debug.Log("Enemy knocked");
        rb.GetComponent<Enemy>().currentState = EnemyState.Idle;
        /*if(collider.CompareTag("Enemy"))
        {
            Debug.Log("Enemy tag detected");
            enemyRB.GetComponent<Enemy>().currentState = EnemyState.Idle;
        }*/
        //enemyRB.isKinematic = true;
    }

    
}
