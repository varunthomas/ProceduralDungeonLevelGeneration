using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	
	public string sceneToLoad;
	public Animator transition;
	public float transitionTime = 1f;
	public int dir;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Player" && gameObject.tag == "DungeonDoor")
		{
			GameObject dungeon = GameObject.FindGameObjectWithTag ("Dungeon");
			DungeonGenerator dungeonGenerator = dungeon.GetComponent<DungeonGenerator> ();
			Room room = dungeonGenerator.GetCurrentRoom();

			dungeonGenerator.SetCurrentRoom(room.NeighbourRoom[dir]);

			LoadNextLevel();
		}
		else if(collider.gameObject.tag == "Player")
		{
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
}
