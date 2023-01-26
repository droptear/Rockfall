using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float _radius = 250.0f;
    [SerializeField] private Rigidbody _asteroidPrefab;

    [SerializeField] private float _spawnRate = 5.0f;
    [SerializeField] private float _variance = 1.0f;

    public Transform target;

    public bool isSpawningAsteroids;

    void Start()
    {
        StartCoroutine(CreateAsteroids());        
    }

    IEnumerator CreateAsteroids()
    {
        while(true)
        {
            float nextSpawnTime = _spawnRate + Random.Range(-_variance, _variance);

            yield return new WaitForSeconds(nextSpawnTime);
            yield return new WaitForFixedUpdate();

            CreateNewAsteroid();
        }
    }

    void CreateNewAsteroid()
    {
        if (!isSpawningAsteroids)
            return;

        var asteroidPosition = Random.onUnitSphere * _radius;
        asteroidPosition.Scale(transform.lossyScale);
        asteroidPosition += transform.position;

        var newAsteroid = Instantiate(_asteroidPrefab);
        newAsteroid.transform.position = asteroidPosition;

        newAsteroid.transform.LookAt(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawWireSphere(Vector3.zero, _radius);
    }

    public void DestroyAllAsteroids() 
    {
        foreach(var asteroid in FindObjectsOfType<Asteroid>())
        {
            Destroy(asteroid.gameObject);
        }
    }
}
