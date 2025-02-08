using UnityEngine;
using System.Collections.Generic;
public class PlayerMovementScript : MonoBehaviour

{
    public List<GameObject> Waypoints;
    public GameObject Targets;
    public int waypointIndex = 0;
    public float speed = 1.0f;
    public float dist = 0;

    public bool move = false;

    public string debugFlag;

    public GameObject startScreen;
    public GameObject endScreen;
    public AudioClip rightAnswerSFX;
    public AudioClip wrongAnswerSFX;
    public AudioClip gameStartedSFX;
    public AudioSource audioSource;

    
    public void Move()
    {
        waypointIndex = 0;
        speed = 1.0f;
        transform.position = Waypoints[waypointIndex].transform.position;
        startScreen.SetActive(false);
        audioSource.PlayOneShot(gameStartedSFX);
    }

    // Update is called once per frame
    void Update()
    {

        if(waypointIndex >= Waypoints.Count) return;

        Vector3 destination = Waypoints[waypointIndex].transform.position;
        float distance = Vector3.Distance(transform.position, destination);
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        if (distance <= 0.01f)
        {
            waypointIndex++;
        }
    }
}
