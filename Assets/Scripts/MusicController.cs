using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    public AudioSource audioSource;
    public ObsSpawner obsSpawner;
    public GameManager gameManager;

    public float pitchStart;
    public float pitchScale;


    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); return; }

        DontDestroyOnLoad(gameObject);
    }


    private void LateUpdate()
    {
        if(obsSpawner == null)
        {
            obsSpawner = FindObjectOfType<ObsSpawner>();
            audioSource.pitch = pitchStart;
            return;
        } 
        if(gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
            return;
        }
        if (gameManager != null && gameManager.gameHasEnded == true)
        {
            StartCoroutine(AudioPitchFade(audioSource, pitchStart, 2f));
        }
        else
        {
            audioSource.pitch = obsSpawner.difficulty * pitchScale + pitchStart;
        }
    }


    private IEnumerator AudioPitchFade(AudioSource source, float endValue, float fadeTime)
    {
        float timeElapsed = 0f;
        
        while(timeElapsed < fadeTime)
        {
            source.pitch = Mathf.Lerp(source.pitch, endValue, timeElapsed / fadeTime);
            timeElapsed += Time.unscaledDeltaTime;
            
            yield return null;
        }

        source.pitch = endValue;
    }
}