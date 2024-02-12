using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverScreen;
    public TMP_Text scoreText;

    // Method to display the game over screen with the score
    public void ShowGameOverScreen(int score)
    {
        scoreText.text = "Score: " + score.ToString();
        gameOverScreen.SetActive(true);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
 
    }
}
