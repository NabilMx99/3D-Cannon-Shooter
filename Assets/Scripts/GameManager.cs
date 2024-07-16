using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public bool isGameOver;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    void Reset()
    {

      score = 0;

    }
    
    void Start()
    {

      score = 0;
      scoreText.text = "Score: " + score.ToString();
      scoreText.color = Color.black;
      scoreText.fontSize = 70.0f;
      scoreText.fontStyle= FontStyles.Bold;
      scoreText.alignment = TextAlignmentOptions.TopLeft;

      gameOverText.text = "Game Over";
      gameOverText.color = Color.red;
      gameOverText.fontSize = 70.0f;
      gameOverText.fontStyle = FontStyles.Bold;
      gameOverText.alignment = TextAlignmentOptions.Center;

      isGameOver = false;
      restartButton.gameObject.SetActive(false);
      gameOverText.gameObject.SetActive(false);
        
    }
    void Update()
    {

      CheckGameOver();
        
    }

    public void UpdateScore()
    {

      scoreText.SetText("Score: " + score);

    }

    void CheckGameOver()
    {
        if(score == 0 && !isGameOver)
        {

          return;

        }
        if(score <= 0)
        {

          isGameOver = true;
          gameOverText.gameObject.SetActive(true);
          restartButton.gameObject.SetActive(true);
          Debug.Log("Game Over");

        } else {

          isGameOver = false;

        }
    }
    public void RestartGame()
    {

      SceneManager.LoadScene("3D Cannon Shooter");
      print("The restart button is working");

    }
}
