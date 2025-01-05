using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovementScript : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List <GameObject> Waypoints;
    int index = 0;
    public static float speed = 0.0f;

    
    void Start()
    {
        speed = 10.0f;
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
    }
}
