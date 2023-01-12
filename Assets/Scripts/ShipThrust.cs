using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThrust : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        var offset = Vector3.forward * Time.deltaTime * _speed;
        this.transform.Translate(offset);
    }
}
