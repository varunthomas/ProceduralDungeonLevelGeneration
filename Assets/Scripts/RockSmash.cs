using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSmash : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash()
    {
        anim.SetBool("Hit", true);
        StartCoroutine(breakCo());
    }

    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(0.7f);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
