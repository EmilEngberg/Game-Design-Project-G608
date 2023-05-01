using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    //Defining the different elements of the in game UI
    public GameObject scoreTextBackground;
    public GameObject countdownTextBackground;
    public TextMeshProUGUI peopleLeftText;
    public TextMeshProUGUI countdownText;

    //Defining the different elements of the gameOverScreen
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreText;
   
    //Defining the different elements of the YouWinScreen
    public GameObject YouWinScreen;
    public TextMeshProUGUI YouWinText;
    public TextMeshProUGUI SavedText;

    //Variables for holding the music
    private AudioSource backgroundAudio;
    public AudioClip winAudio;
    public AudioClip looseAudio;


    public void Awake()
    {
        backgroundAudio = GetComponent<AudioSource>();
    }

    public void SetGameOver() //Function that happens when the timer runs out
    {
        gameOverScreen.SetActive(true); //The gameOverScreen will become visible

        //sets and plays the loosing audio
        backgroundAudio.clip = looseAudio;
        backgroundAudio.Play(0);

        peopleLeftText.text = scoreText.text; //The scoreText will be shown with the score 

        scoreText.gameObject.SetActive(false); //The scoreText UI gameObject is removed
        scoreTextBackground.gameObject.SetActive(false); //The scoreText UI background gameObject is removed
        countdownText.gameObject.SetActive(false); //The countdown timer UI gameObject is removed
        countdownTextBackground.gameObject.SetActive(false); //The countdown timer background UI gameObject is removed


        Time.timeScale = 0; //pauses the game entirely
    }

    public void RestartGame() //button function that restarts the game
    {
        SceneManager.LoadScene("SampleScene"); //The scene is restarted - game is loaded again.
        Debug.Log("Game Restarted");
        gameOverScreen.SetActive(false); //The gameOverScreen is not active anymore
        Time.timeScale = 1; //Game time is set back to normal
    }

    public void SetYouWin() //Function that plays when you save the day!
    {
        YouWinScreen.SetActive(true);

        //sets and plays the winning audio
        backgroundAudio.clip = winAudio;
        backgroundAudio.Play(0);

        scoreText.gameObject.SetActive(false); //The scoreText UI gameObject is removed
        scoreTextBackground.gameObject.SetActive(false); //The scoreText UI background gameObject is removed
        countdownText.gameObject.SetActive(false); //The countdown timer UI gameObject is removed
        countdownTextBackground.gameObject.SetActive(false); //The countdown timer background UI gameObject is removed

        Time.timeScale = 0; //pauses the game entirely

    }
}
