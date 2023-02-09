using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField] private float _warningRadius = 400.0f;
    [SerializeField] private float _destroyRadius = 450.0f;

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _warningRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _destroyRadius);
    }
}
