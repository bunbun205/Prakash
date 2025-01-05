using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class ColorTargetSetup : MonoBehaviour
{
    void Start()
    {

        System.Random Rnd = new System.Random ();
        List <Transform> planeTransforms = new List<Transform> ();
        List <TargetController> controlScripts = new List<TargetController> ();
        for (int i = 0; i < transform.childCount; i++){
            
            planeTransforms.Add (transform.GetChild (i));
            controlScripts.Add (transform.GetChild (i).GetComponent<TargetController>());

        }
        System.Random rnd = new System.Random();
        int oddPlaneIndex = rnd.Next (0, transform.childCount);

        System.Random rand = new System.Random();
        int randVal = rand.Next(0, 255);
        planeTransforms[oddPlaneIndex].gameObject.GetComponent <Renderer>().material.color = randVal * GetRandomPureColor();
        controlScripts [0].targetFlag = 1;
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
