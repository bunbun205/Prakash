using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System;

public class ETargetSetup : MonoBehaviour
{

    public GameObject player;
    private PlayerMovementScript script;
    public bool clicked = false;
    public int counter = 0;
    public float distance = 0;

    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerMovementScript>();
        List<int> rotationVals = new List<int> { 0, 90, 180, 270 };
        System.Random Rnd = new System.Random();
        List<int> rotvals = rotationVals.OrderBy(x => Rnd.Next()).Take(2).ToList();
        List<Transform> planeTransforms = new List<Transform>();
        List<TargetController> controlScripts = new List<TargetController>();
        for (int i = 0; i < transform.childCount; i++)
        {
            planeTransforms.Add(transform.GetChild(i));
            controlScripts.Add(transform.GetChild(i).GetComponent<TargetController>());
        }
        System.Random rnd = new System.Random();
        int oddPlaneIndex = rnd.Next(0, transform.childCount);
        planeTransforms[oddPlaneIndex].Rotate(0, rotvals[0], 0);
        controlScripts[oddPlaneIndex].targetFlag = 1;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i != oddPlaneIndex)
            {
                planeTransforms[i].Rotate(0, rotvals[1], 0);
            }
        }

        setTargetSizeAndPosition();

    }

    private void setTargetSizeAndPosition()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        switch (sceneName) {
            case "E_Level_1" :
                transform.GetChild(0).localScale = new Vector3(0.03f, 0.03f, 0.03f);
                transform.GetChild(1).localScale = new Vector3(0.03f, 0.03f, 0.03f);
                transform.GetChild(2).localScale = new Vector3(0.03f, 0.03f, 0.03f);
                transform.GetChild(0).localPosition = new Vector3(-0.4f, 0, 0);
                transform.GetChild(1).localPosition = new Vector3(0, 0, 0);
                transform.GetChild(2).localPosition = new Vector3(0.4f, 0, 0);
                break;
            case "E_Level_2" :
                transform.GetChild(0).localScale = new Vector3(0.025f, 0.025f, 0.025f);
                transform.GetChild(1).localScale = new Vector3(0.025f, 0.025f, 0.025f);
                transform.GetChild(2).localScale = new Vector3(0.025f, 0.025f, 0.025f);
                transform.GetChild(0).localPosition = new Vector3(-0.3f, 0, 0);
                transform.GetChild(1).localPosition = new Vector3(0, 0, 0);
                transform.GetChild(2).localPosition = new Vector3(0.3f, 0, 0);
                break;
            case "E_Level_3" :
                transform.GetChild(0).localScale = new Vector3(0.020f, 0.020f, 0.020f);
                transform.GetChild(1).localScale = new Vector3(0.020f, 0.020f, 0.020f);
                transform.GetChild(2).localScale = new Vector3(0.020f, 0.020f, 0.020f);
                transform.GetChild(0).localPosition = new Vector3(-0.25f, 0, 0);
                transform.GetChild(1).localPosition = new Vector3(0, 0, 0);
                transform.GetChild(2).localPosition = new Vector3(0.25f, 0, 0);
                break;
            case "E_Level_4" :
                transform.GetChild(0).localScale = new Vector3(0.015f, 0.015f, 0.015f);
                transform.GetChild(1).localScale = new Vector3(0.015f, 0.015f, 0.015f);
                transform.GetChild(2).localScale = new Vector3(0.015f, 0.015f, 0.015f);
                transform.GetChild(0).localPosition = new Vector3(-0.2f, 0, 0);
                transform.GetChild(1).localPosition = new Vector3(0, 0, 0);
                transform.GetChild(2).localPosition = new Vector3(0.2f, 0, 0);
                break;
            case "E_Level_5" :
                transform.GetChild(0).localScale = new Vector3(0.01f, 0.01f, 0.01f);
                transform.GetChild(1).localScale = new Vector3(0.01f, 0.01f, 0.01f);
                transform.GetChild(2).localScale = new Vector3(0.01f, 0.01f, 0.01f);
                transform.GetChild(0).localPosition = new Vector3(-0.15f, 0, 0);
                transform.GetChild(1).localPosition = new Vector3(0, 0, 0);
                transform.GetChild(2).localPosition = new Vector3(0.15f, 0, 0);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= 1 && !clicked)
        {
            script.speed = 0;
        }

    }
}
