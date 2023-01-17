using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSteering : MonoBehaviour
{
    [SerializeField] private float _turnRate = 6.0f;
    [SerializeField] private float _levelDamping = 1.0f;

    void Update()
    {
        Vector2 steeringInput = InputManager.instance.steering.delta;
        Vector2 rotation = new Vector2();

        rotation.y = steeringInput.x;
        rotation.x = steeringInput.y;

        rotation *= _turnRate;

        rotation.x = Mathf.Clamp(rotation.x, -Mathf.PI * 0.9f, Mathf.PI * 0.9f);

        var newOrientation = Quaternion.Euler(rotation);

        transform.rotation *= newOrientation;

        var levelAngles = transform.eulerAngles;
        levelAngles.z = 0.0f;
        var levelOrientation = Quaternion.Euler(levelAngles);

        transform.rotation = Quaternion.Slerp(transform.rotation, levelOrientation, _levelDamping * Time.deltaTime);
    }
}
