using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
    public GameObject deathEffect;
    [Space]
    public GameObject deathMenuUI;
    [Space]
    public float deathPenalty = 3;
    [Space]
    public Transform player;

    private void Start()
    {
        deathMenuUI.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(KillPlayer());
        }
    }

    public IEnumerator KillPlayer()
    {
        Instantiate(deathEffect, player.transform.position, Quaternion.identity);
        Destroy(player.gameObject);
        yield return new WaitForSecondsRealtime(deathPenalty);
        deathMenuUI.SetActive(true);
    }
}
