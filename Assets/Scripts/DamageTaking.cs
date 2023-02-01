using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaking : MonoBehaviour
{
    [SerializeField] private int _hitPoints = 10;
    [SerializeField] private bool gameOverOnDestroyed = false;
    [SerializeField] private GameObject _destructionPrefab;
    
    public void TakeDamage(int amount)
    {
        Debug.Log(gameObject.name + "damaged!");

        _hitPoints -= amount;

        if (_hitPoints <= 0)
        {
            Debug.Log(gameObject.name + "destroyed!");

            Destroy(gameObject);

            if (_destructionPrefab != null)
            {
                Instantiate(_destructionPrefab, transform.position, transform.rotation);
            }

            if (gameOverOnDestroyed == true)
            {
                GameManager.instance.GameOver();
            }
        }
    }
}