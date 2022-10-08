using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
	
	public string sceneToLoad;
	public Animator transition;
	public float transitionTime = 1f;
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
		if(collider.gameObject.tag == "Player" && gameObject.tag == "DungeonDoor")
		{
			
			Debug.Log("Collided with dungeon door");

			LoadNextLevel();
		}
		else if(collider.gameObject.tag == "Player")
		{
			LoadNextLevel();
			Debug.Log("Triggered");
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
