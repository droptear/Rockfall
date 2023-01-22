using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private int _damageToSelf = 5;

    void HitObject(GameObject theObject)
    {
        var theirDamage = theObject.GetComponentInParent<DamageTaking>();

        if (theirDamage)
        {
            theirDamage.TakeDamage(_damage);
        }

        var ourDamage = this.GetComponentInParent<DamageTaking>();

        if (ourDamage)
        {
            ourDamage.TakeDamage(_damageToSelf);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HitObject(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HitObject(collision.gameObject);
    }
}