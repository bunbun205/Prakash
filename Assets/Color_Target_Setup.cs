using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class ColorTargetSetup : MonoBehaviour
{
    void Start()
    {

        System.Random Rnd = new System.Random ();
        List <GameObject> planes = new List<GameObject> ();
        for (int i = 0; i < transform.childCount; i++){

            planes.Add (transform.GetChild (i).gameObject);
        }
        System.Random rnd = new System.Random();
        int oddPlaneIndex = rnd.Next (0, transform.childCount);

        System.Random rand = new System.Random();
        int randVal = rand.Next(0, 255);
        planes [oddPlaneIndex].GetComponent <Renderer>().material.color = randVal * GetRandomPureColor();
        for (int i = 0; i < transform.childCount; i++){
            if (i != oddPlaneIndex){
                planes [i].GetComponent <Renderer>().material.color = randVal * Color.white;
            }
        }
    }

    private Color GetRandomPureColor()
    {
        int colorChoice = Random.Range(0, 3);
        switch (colorChoice)
        {
            case 0: return Color.red;
            case 1: return Color.green;
            case 2: return Color.blue;
            default: return Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
