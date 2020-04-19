using UnityEngine;

public class HealingPlant : MonoBehaviour
{

    public GameObject plantEffect;

    private PlayerMovement2D playerMovement2D;

    private AudioSource audioSource;
    public AudioClip plantSound;

    private void Start()
    {
        playerMovement2D = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement2D>();

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.clip = plantSound;
            audioSource.Play();
            Instantiate(plantEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            playerMovement2D.plantsCollected++;
        }
    }
}
