using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	
	public string sceneToLoad;
	public Animator transition;
	public float transitionTime = 0.3f;
	public int dir;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Player" && gameObject.tag == "DungeonDoor")
		{
			FreezePlayer();
			GameObject dungeon = GameObject.FindGameObjectWithTag ("Dungeon");
			DungeonGenerator dungeonGenerator = dungeon.GetComponent<DungeonGenerator> ();
			Room room = dungeonGenerator.GetCurrentRoom();

			dungeonGenerator.SetCurrentRoom(room.NeighbourRoom[dir]);
			room.NeighbourRoom[dir].SetEntryPoint(dir);

			Debug.Log("In scene current room " + room.getPrefabName() + " count is " + room.room_num);
			Debug.Log("In scene next room " + room.NeighbourRoom[dir].getPrefabName() + " count is " + room.NeighbourRoom[dir].room_num);

			
			LoadNextLevel();
		}
		else if(collider.gameObject.tag == "Player" && !collider.isTrigger)
		{
			FreezePlayer();
			LoadNextLevel();
		}
	}
	
	void LoadNextLevel()
	{
		StartCoroutine(LoadLevel(sceneToLoad));
	}
	
	IEnumerator LoadLevel(string sceneToLoad)
	{
		transition.SetTrigger("Start");
		yield return new WaitForSeconds(transitionTime);
		SceneManager.LoadScene(sceneToLoad);
	}

	void FreezePlayer()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		Rigidbody2D rbPlayer = player.GetComponent<Rigidbody2D> ();
		Animator animator = player.GetComponent<Animator> ();
		rbPlayer.constraints = RigidbodyConstraints2D.FreezeAll;
		animator.enabled = false;
	}
}
