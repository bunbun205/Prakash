using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;

public class PlayerMovementScript : MonoBehaviour

{
    public List<GameObject> Waypoints;
    int index = 0;
    public float speed = 0.0f;
    public float dist = 0;

    public bool move = false;

    public GameObject Targets;
    
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
       foreach (Transform target in Targets.transform.GetChild){
        
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget > 1 || move) {
            speed = 5;
        } 
        
        else {
            speed = 0;
            move = false;
        }

        } 
        
    }
}
