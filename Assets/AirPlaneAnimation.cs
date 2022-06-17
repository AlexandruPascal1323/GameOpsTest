using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AirPlaneAnimation : MonoBehaviour
{
    [SerializeField]
    protected GameObject m_AirPlane;
    [SerializeField]
    protected float m_Duration = 10;
    [SerializeField]
    protected Vector3 _target;
    private void Start()
    {
        m_AirPlane.transform.DOMove(_target, m_Duration, false);
    }
}

