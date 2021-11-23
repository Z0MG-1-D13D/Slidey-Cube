using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public AudioMixer audioMixer;

    public Slider masterVolume;
    public Slider musicVolume;
    public Slider sfxVolume;

    public Text sensText;
    public Slider sensSlider;
    public float sensitivity;

    public Button firstSelect;

    private void OnEnable()
    {
        firstSelect.Select();
    }

    private void Awake()
    {
        //set slider values and volume levels
        masterVolume.value = PlayerPrefs.GetFloat("MasterVolume");
        audioMixer.SetFloat("Master", PlayerPrefs.GetFloat("MasterVolume"));
        musicVolume.value = PlayerPrefs.GetFloat("MusicVolume");
        audioMixer.SetFloat("Music", PlayerPrefs.GetFloat("MusicVolume"));
        sfxVolume.value = PlayerPrefs.GetFloat("SfxVolume");
        audioMixer.SetFloat("Sfx", PlayerPrefs.GetFloat("SfxVolume"));

        //cache and set sensitivity values
        sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        if(sensitivity == 0) { sensitivity = 100; }
        sensText.text = sensitivity.ToString();
        sensSlider.value = sensitivity;
    }

    private void Start()
    {
        //initialize main menu
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void SetVolumeMaster (float volume)
    {
        audioMixer.SetFloat("Master", volume);
    }

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }

    public void SetVolumeSfx(float volume)
    {
        audioMixer.SetFloat("Sfx", volume);
    }

    public void SetSensitivity(float sens)
    {
        sensitivity = sens;
        sensText.text = sensitivity.ToString();
    }

    public void BackToMain()
    {
        //disable options menu elements
        optionsMenu.SetActive(false);

        //enable main menu elements
        mainMenu.SetActive(true);

        //save settings to PlayerPrefs
        PlayerPrefs.SetFloat("MasterVolume", masterVolume.value);
        print("Master Volume set to: " + PlayerPrefs.GetFloat("MasterVolume"));
        PlayerPrefs.SetFloat("MusicVolume", musicVolume.value);
        print("Music Volume set to: " + PlayerPrefs.GetFloat("MusicVolume"));
        PlayerPrefs.SetFloat("SfxVolume", sfxVolume.value);
        print("Music Volume set to: " + PlayerPrefs.GetFloat("MusicVolume"));
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
        print("Control Sensitivity set to: " + PlayerPrefs.GetFloat("Sensitivity"));
        
    }

    public void ResetHighScore()
    {
        Debug.Log("High Score has been reset.");
        PlayerPrefs.SetFloat("HighScore", 0f);
    }
}
