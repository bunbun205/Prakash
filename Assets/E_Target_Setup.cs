using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class ETargetSetup : MonoBehaviour
{

    void Start()
    {

        List <int> rotationVals = new List<int> {0, 90, 180, 270};
        System.Random Rnd = new System.Random ();
        List <int> rotvals = rotationVals.OrderBy (x=> Rnd.Next()).Take(2).ToList ();
        List <Transform> planeTransforms = new List<Transform> ();
        List <TargetController> controlScripts = new List<TargetController> ();
        for (int i = 0; i < transform.childCount; i++){
            planeTransforms.Add (transform.GetChild (i));
            controlScripts.Add (transform.GetChild (i).GetComponent<TargetController>());
        }
        System.Random rnd = new System.Random();
        int oddPlaneIndex = rnd.Next (0, transform.childCount);
        planeTransforms [oddPlaneIndex].Rotate(0, rotvals[0], 0);
        controlScripts [oddPlaneIndex].targetFlag = 1;
        for (int i = 0; i < transform.childCount; i++){
            if (i != oddPlaneIndex){
                planeTransforms [i].Rotate(0, rotvals[1], 0);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
