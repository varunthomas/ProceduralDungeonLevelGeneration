using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    //public float force;
    //public float knockbackTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.CompareTag("Rock"))
		{
            Debug.Log("collided rock");
            Obstacle obstacle;
			GameObject dungeon = GameObject.FindGameObjectWithTag ("Dungeon");
			DungeonGenerator dungeonGenerator = dungeon.GetComponent<DungeonGenerator> ();
			Room room = dungeonGenerator.GetCurrentRoom();
            obstacle = room.FindObstInstance(new float[] {collider.transform.position.x, collider.transform.position.y});
            if(obstacle == null)
            {
                Debug.Log("Obstacle is null");
            }
            obstacle.DestroyObstacle();
			collider.GetComponent<RockSmash>().Smash();
		}
        /*else if(collider.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
            Rigidbody2D enemyRB = collider.GetComponent<Rigidbody2D>();
            enemyRB.isKinematic = false;
            Vector2 difference = collider.transform.position - transform.position;
            difference = difference.normalized * force;
            //collider.transform.position = new Vector2(collider.transform.position.x + difference.x, collider.transform.position.y + difference.y);            //difference = difference.normalized*force;
            enemyRB.AddForce(difference, ForceMode2D.Impulse);
            StartCoroutine(KnockCo(enemyRB));
        }*/
	}

    /*IEnumerator KnockCo(Rigidbody2D enemyRB)
    {
        yield return new WaitForSeconds(knockbackTime);
        enemyRB.velocity = Vector2.zero;
        Debug.Log("enemy vel set to 0");
        enemyRB.isKinematic = true;
    }*/
}
