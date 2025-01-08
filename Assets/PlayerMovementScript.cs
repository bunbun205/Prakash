using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovementScript : MonoBehaviour

{
    public List<GameObject> Waypoints;
    int index = 0;
    public float speed = 0.0f;
    public float dist = 0;
    
    void Start()
    {
        index = 0;
        transform.position = Waypoints[index].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = Waypoints[index].transform.position;
        float distance = Vector3.Distance(transform.position, destination);
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        if (distance <= 0.01)
        {
            index++;
        }
    }
}
