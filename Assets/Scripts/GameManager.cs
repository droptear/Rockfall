using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _shipPrefab;
    [SerializeField] private GameObject _spaceStationPrefab;
    [SerializeField] private Transform _shipStartPosition;
    [SerializeField] private Transform _spaceStationStartPosition;

    [SerializeField] private SmoothFollow _cameraFollow;
    [SerializeField] private AsteroidSpawner _asteroidSpawner;

    [SerializeField] private GameObject _inGameUI;
    [SerializeField] private GameObject _pausedUI;
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _mainMenuUI;

    public GameObject currentShip { get; private set; }
    public GameObject currentSpaceStation { get; private set; }

    public bool gameIsPlaying { get; private set; }
    public bool isPaused;

    void Start()
    {
        ShowMainMenu();
    }

    void ShowUI(GameObject newUI)
    {
        GameObject[] allUI = { _inGameUI, _pausedUI, _gameOverUI, _mainMenuUI };

        foreach (GameObject UIToHide in allUI)
        {
            UIToHide.SetActive(false);
            newUI.SetActive(true);
        }
    }

    public void ShowMainMenu()
    {
        ShowUI(_mainMenuUI);

        gameIsPlaying = false;

        _asteroidSpawner.isSpawningAsteroids = false;
    }

    public void StartGame()
    {
        ShowUI(_inGameUI);

        gameIsPlaying = true;

        if (currentShip != null)
        {
            Destroy(currentShip);
        }

        if (currentSpaceStation != null)
        {
            Destroy(currentSpaceStation);
        }

        currentShip = Instantiate(_shipPrefab, _shipStartPosition.position, _shipStartPosition.rotation);
        currentSpaceStation = Instantiate(_spaceStationPrefab, _spaceStationStartPosition.position, _spaceStationStartPosition.rotation);

        _cameraFollow.target = currentShip.transform;

        _asteroidSpawner.isSpawningAsteroids = true;
        _asteroidSpawner.target = currentSpaceStation.transform;
    }

    public void GameOver()
    {
        ShowUI(_gameOverUI);

        gameIsPlaying = false;

        if (currentShip != null)
        {
            Destroy(currentShip);
        }

        if (currentSpaceStation != null)
        {
            Destroy(currentSpaceStation);
        }

        _asteroidSpawner.isSpawningAsteroids = false;
        _asteroidSpawner.DestroyAllAsteroids();
    }

    public void SetPaused(bool paused)
    {
        _inGameUI.SetActive(!paused);
        _pausedUI.SetActive(paused);

        if (paused)
        {
            Time.timeScale = 0.0f;
        } else
        {
            Time.timeScale = 1.0f;
        }
    }
}
