using System.Collections;
using UnityEngine;

public class InstructionsPlayer : MonoBehaviour
{
    [Header("References")]
    public AudioClip[] clips;
    public AudioSource audioSource;

    [Header("Settings")]
    [Range(0f, 5f)]
    public float delay;

    private bool started = false, canPlaySecond = true;
    private PlayerMovementScript player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovementScript>();
        StartCoroutine(PlayInstructions());
    }

    private void Update()
    {
        if(!audioSource.isPlaying && started && canPlaySecond && player.speed == 0)
        {
            canPlaySecond = false;
            audioSource.clip = clips[1];
            audioSource.Play();
        }

        if(player.speed != 0)
        {
            audioSource.Stop();
        }
    }

    private IEnumerator PlayInstructions()
    {
        yield return new WaitForSeconds(delay);
        started = true;
        audioSource.clip = clips[0];
        audioSource.Play();
    }
}
