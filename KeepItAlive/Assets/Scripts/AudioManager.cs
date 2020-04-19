using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip music;
    private AudioSource audioSource;

    public bool inGame;

    private void Awake()
    { 
        if (inGame == true)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = music;
        audioSource.Play();
    }


}
