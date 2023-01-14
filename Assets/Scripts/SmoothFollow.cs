using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _height = 5.0f;
    [SerializeField] private float _distance = 10.0f;

    [SerializeField] private float _rotationDamping;
    [SerializeField] private float _heightDamping;


    // Update is called once per frame
    void LateUpdate()
    {
        if (!_target)
            return;

        var wantedRotationAngle = _target.eulerAngles.y;
        var wantedHeight = _target.position.y + _height;

        var currentRotationAngle = transform.eulerAngles.y;
        var currentHeight = transform.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, _rotationDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, _heightDamping * Time.deltaTime);

        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        transform.position = _target.position;
        transform.position -= currentRotation * Vector3.forward * _distance;

        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, _target.rotation, _rotationDamping * Time.deltaTime);
    }
}
