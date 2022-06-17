using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_animations : MonoBehaviour
{
    public Animator charAnimator;
    private int rand;
    private void Start()
    {
        rand = Random.Range(0, 40);
        if (rand < 10) charAnimator.Play("laydown");
        else if (rand < 20 ) charAnimator.Play("DwarfIdle");
        else if (rand < 30 ) charAnimator.Play("layshrugging");
        else charAnimator.Play("idle");
        StartCoroutine(playAnimations());   
    }
    IEnumerator playAnimations() {
        StopCoroutine(playAnimations2());
        yield return new WaitForSeconds(rand);
        charAnimator.SetBool("Walking",true);
        
        StartCoroutine(playAnimations2());
    }
    IEnumerator playAnimations2() {
        StopCoroutine(playAnimations());
        yield return new WaitForSeconds(rand);
        charAnimator.SetBool("Walking", false);
    }
}
