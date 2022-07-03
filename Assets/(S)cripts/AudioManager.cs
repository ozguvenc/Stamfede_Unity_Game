using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager audioManagerInstance;
    public AudioSource audioSource;
    public AudioClip clip1;
    public AudioClip menuSoundtrack;
    public AudioClip chapter1Soundtrack;
    public AudioClip chapter2Soundtrack;
 

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Keep Character Manager through the levels to maintain character properties.
        DontDestroyOnLoad(this);

        if (audioManagerInstance == null)
        {
            audioManagerInstance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(SceneManager.GetActiveScene().name == "0.2_MainMenu")
        {
            audioSource.clip = menuSoundtrack;
            audioSource.Play();
        }
    }
}
