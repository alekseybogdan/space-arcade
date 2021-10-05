using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public int totalScore;

    public int mediumDifficultySwitchScore;
    public int hardDifficultySwitchScore;

    private bool isMediumDifficulty;
    private bool isHardDifficulty;

    private AudioManager _audioManager;
    private Spawner _spawner;

    public float skyboxScrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            _spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();

            IncreaseDifficulty("easy");
        }

        if (scoreText != null)
        {
            UpdateScore(0);
        }
    }

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.timeSinceLevelLoad * skyboxScrollSpeed);
    }

    public void UpdateScore(int score)
    {
        totalScore += score;
        scoreText.text = "Score: " + totalScore;

        if (!isMediumDifficulty && totalScore >= mediumDifficultySwitchScore)
        {
            IncreaseDifficulty("medium");
            isMediumDifficulty = true;
        }

        if (!isHardDifficulty && totalScore >= hardDifficultySwitchScore)
        {
            IncreaseDifficulty("hard");
            isHardDifficulty = true;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void IncreaseDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            default:
                _spawner.difficulty = "easy";
                break;
            case "medium":
                _spawner.difficulty = "medium";
                _audioManager.PlayDifficultyIncrease();
                break;
            case "hard":
                _spawner.difficulty = "hard";
                _audioManager.PlayDifficultyIncrease();
                break;
        }
    }
}