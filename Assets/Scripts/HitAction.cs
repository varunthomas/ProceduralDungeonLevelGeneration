using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAction : MonoBehaviour
{
    Animator anim;
    AnimatorClipInfo[] m_CurrentClipInfo;
    string m_ClipName;
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
        Debug.Log("Triggered hit");
        StartCoroutine(AttackCo());
        //anim.SetBool("Hit", false);
        //m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
        //m_ClipName = m_CurrentClipInfo[0].clip.name;
        //Debug.Log("current anim is " + m_ClipName);
    }

    private IEnumerator AttackCo()
    {
        anim.SetBool("Hit", true);
        yield return null;
        anim.SetBool("Hit", false);
        yield return new WaitForSeconds(.33f);
    }
}
