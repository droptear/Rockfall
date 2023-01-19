using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapons : MonoBehaviour
{
    [SerializeField] private GameObject _shotPrefab;
    [SerializeField] private Transform[] _firePoints;

    private int _firePointIndex;

    public void Awake()
    {
        InputManager.instance.SetWeapons(this);
    }

    public void OnDestroy()
    {
        if (Application.isPlaying == true)
        {
            InputManager.instance.RemoveWeapons(this);
        }
    }

    public void Fire()
    {
        if (_firePoints.Length == 0)
            return;

        var firePointToUse = _firePoints[_firePointIndex];

        Instantiate(_shotPrefab, firePointToUse.position, firePointToUse.rotation);

        _firePointIndex++;

        if (_firePointIndex >= _firePoints.Length)
            _firePointIndex = 0;
    }
}