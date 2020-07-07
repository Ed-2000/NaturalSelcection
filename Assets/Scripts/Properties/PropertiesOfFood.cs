using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertiesOfFood : MonoBehaviour
{
    private Rigidbody _rb;
    private Transform _centerOfMass;

    private void Awake()
    {
        //  занижує центр мас їжі, щоб вона не каталася по землі
        _centerOfMass = transform.Find("CenterOfMass");
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = _centerOfMass.localPosition;
    }

}