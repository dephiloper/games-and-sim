using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _spherePrefab;
    [SerializeField] private Text _timerText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private GameObject _gameOverPanel;
    private bool _gameOver = false;
    private const float AvailableTime = 120;

    private int _sphereHoleCounter;

    private void Start()
    {
        _restartButton.onClick.AddListener(Restart);
        StartCoroutine(UpdateTimer());
        SpawnSphere();
    }

    private void Update() {
        if (_gameOver) return;
        if (AvailableTime - Time.timeSinceLevelLoad < 0) GameOver(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameOver(false);
        }
        else if (other.gameObject.tag == "Sphere")
        {
            _sphereHoleCounter++;

            if (_sphereHoleCounter == 5)
                GameOver(true);

            Destroy(other.gameObject);
            SpawnSphere();
        }
    }

    private void SpawnSphere()
    {
        Instantiate(_spherePrefab, new Vector3(Random.Range(-12, 12), 10, Random.Range(-12, 12)), Quaternion.identity);
    }

    private IEnumerator UpdateTimer()
    {
        while (true)
        {
            _timerText.text = $"Time left {AvailableTime - Time.timeSinceLevelLoad:0.00}";
            _timerText.text += $"\nSpheres holed: {_sphereHoleCounter}/5";
            if (_sphereHoleCounter > 0)
                _timerText.text += $"\nAvg time: {Time.time / _sphereHoleCounter:0.00}";

            yield return new WaitForSeconds(.1f);
        }
    }

    private IEnumerator SlowDownTime()
    {
        while (Time.timeScale > 0)
        {
            Time.timeScale *= 0.9975f;
            if (Time.timeScale < 0.5) Time.timeScale = 0;
            yield return null;
        }

        _gameOverPanel.SetActive(true);
    }

    private void GameOver(bool hasWon)
    {
        _gameOver = true;
        _gameOverText.text = hasWon ? "You won! Hurray :)" : "You loose! Not hurray :(";
        StartCoroutine(SlowDownTime());
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
