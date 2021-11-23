using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    public bool gameHasEnded = false;
    public bool newHighScore = false;

    public float restartDelay = 2f;

    public GameObject gameOverUI;
    public GameObject highScoreUI;
    public GameObject scoreUI;
    public GameObject newHighScoreUI;
    public GameObject pauseUI;

    public Transform player;

    public Animator gameOverAnim;

    public AudioMixer audioMixer;


    private void Awake()
    {
        audioMixer.SetFloat("Master", PlayerPrefs.GetFloat("MasterVolume"));
        audioMixer.SetFloat("Music", PlayerPrefs.GetFloat("MusicVolume"));
        audioMixer.SetFloat("Sfx", PlayerPrefs.GetFloat("SfxVolume"));
    }


    private void Start()
    {
        scoreUI.SetActive(true);
        gameOverUI.SetActive(false);
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }


    private void LateUpdate()
    {
        if(newHighScore)
        {
            newHighScoreUI.SetActive(true);
        } else
        {
            newHighScoreUI.SetActive(false);
        }

        if (gameHasEnded)
        {
            Invoke(nameof(EndGame), restartDelay);
        }
    }


    public void EndGame()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
        highScoreUI.SetActive(false);
        gameOverAnim.SetTrigger("playAnim");
    }


    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
