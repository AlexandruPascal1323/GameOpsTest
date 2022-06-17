using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chimneysmoke : MonoBehaviour
{
    public ParticleSystem fxChimneySmoke;
    private int rand;
    void Start()
    {
        rand = Random.Range(0, 20);
        if (rand < 5) fxChimneySmoke.Play();
        StartCoroutine(StopEffect());
    }

    private IEnumerator StopEffect() {
        StopCoroutine(PlayEffect());
        yield return new WaitForSeconds(rand*10);
        fxChimneySmoke.Stop();
        StartCoroutine(PlayEffect());
    }
    private IEnumerator PlayEffect()
    {
        StopCoroutine(StopEffect());
        yield return new WaitForSeconds(rand);
        fxChimneySmoke.Play();
        StartCoroutine(StopEffect());
    }
}
