using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int finalScore = 0;
    private int targetHealth = 150;
    public int multiplier = 1;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI targetHealthText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI crosshair;
    public Button restartButton;
    public GameObject titleScreen;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame()
    {
        isGameActive = true;                                                        
        UpdateScore(0);                                    
        titleScreen.gameObject.SetActive(false);
        crosshair.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {   
        score += scoreToAdd;                                
        scoreText.text = "Score: " + score;

        finalScore = multiplier * score;
        finalScoreText.text = "Final Score: " + finalScore;                 
    }

    public void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        isGameActive = false;                             
        gameOverText.gameObject.SetActive(true);            
        restartButton.gameObject.SetActive(true); 
        finalScoreText.gameObject.SetActive(true);
        restartButton.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     
    }

    public void DamageTarget(int enemyDamage)
    {
        targetHealth -= enemyDamage;
        targetHealthText.text = "Base HP: " + targetHealth;

        if (targetHealth == 0)
        {
            GameOver();
        }
    }

    public void IncreaseMultiplier()
    {
      multiplier++;
    }
}