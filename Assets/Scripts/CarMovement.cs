using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    public Animator carAnimator;
    public ParticleSystem fxCarExhaust;
    public int randomMax = 20;
    public int carSpeed = 10;
    public bool isMoving = false;
    private Rigidbody m_Rigidbody;
    int rand;
    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        rand = Random.Range(0, randomMax);
        StartCoroutine(MoveCar());
    }

    private IEnumerator MoveCar() {

        
        yield return new WaitForSeconds(rand);
        carAnimator.SetBool("CarEngineRunning", true);
        fxCarExhaust.Play();
    }
    void Update()
    {
       if(isMoving) m_Rigidbody.velocity = transform.forward * carSpeed;
    
    }
}
