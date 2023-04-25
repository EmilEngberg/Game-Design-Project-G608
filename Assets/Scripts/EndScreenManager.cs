using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI peopleLeftText;
    public TextMeshProUGUI countdownText;

    public void SetGameOver()
    {
        gameOverScreen.SetActive(true);

        peopleLeftText.text = scoreText.text;

        scoreText.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(false);

        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Game Restarted");
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
