using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementEvents : MonoBehaviour
{
	public int x = 0;
	public int y = 0;	
	    Animator anim;
    AnimatorClipInfo[] m_CurrentClipInfo;
    string m_ClipName;
	
	public void PressAndHoldUp()
         {
			 x = 0;
			 y = 1;
         }
	public void PressAndHoldComplete()
         {
			 x = 0;
			 y = 0;
         }
		 
	public void PressAndHoldDown()
         {
			 x = 0;
			 y = -1;
         }

	public void PressAndHoldLeft()
         {
			 x = -1;
			 y = 0;
         }

	public void PressAndHoldRight()
         {
			 x = 1;
			 y = 0;
         }

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag ("Player");
        anim = player.GetComponent<Animator>();		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
    public void onHitButtonPress()
    {
        StartCoroutine(AttackCo());
    }

    private IEnumerator AttackCo()
    {
        anim.SetBool("Hit", true);
        yield return null;
        anim.SetBool("Hit", false);
        yield return new WaitForSeconds(.33f);
    }
	
}
