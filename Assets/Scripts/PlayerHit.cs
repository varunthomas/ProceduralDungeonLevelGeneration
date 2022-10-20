using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
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
            float[] coordList = new float[2];
            Obstacle obstacle;
            coordList[0] = collider.transform.position.x;
            coordList[1] = collider.transform.position.y;
            
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
	}
}
