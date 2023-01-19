using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public VirtualJoystick steering;

    [SerializeField] private float _fireRate = 0.2f;

    private ShipWeapons _currentWeapons;
    private bool isFiring = false;

    public void SetWeapons(ShipWeapons weapons)
    {
        this._currentWeapons = weapons;
    }

    public void RemoveWeapons(ShipWeapons weapons)
    {
        if (this._currentWeapons == weapons)
        {
            this._currentWeapons = null;
        }
    }

    public void StartFiring()
    {
        StartCoroutine(FireWeapons());
    }

    IEnumerator FireWeapons()
    {
        isFiring = true;

        while (isFiring)
        {
            if (this._currentWeapons != null)
            {
                _currentWeapons.Fire();
            }

            yield return new WaitForSeconds(_fireRate);
        }
    }

    public void StopFiring()
    {
        isFiring = false;
    }

}
