using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementEvents : MonoBehaviour
{
	public int x = 0;
	public int y = 0;	
	    Animator anim;

        PlayerState pm;
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
        pm = player.GetComponent<PlayerMovement>().currentState;
        anim = player.GetComponent<Animator>();		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
    public void onHitButtonPress()
    {
        if (pm != PlayerState.Attack && pm != PlayerState.Stagger)
        {
            Debug.Log("Hit pressed");
            StartCoroutine(AttackCo());
        }
    }

    private IEnumerator AttackCo()
    {
        anim.SetBool("Hit", true);
        pm = PlayerState.Attack;
        yield return null;
        anim.SetBool("Hit", false);
        yield return new WaitForSeconds(.33f);
        pm = PlayerState.Walk;
    }
	
}
