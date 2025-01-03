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
        List <GameObject> planes = new List<GameObject> ();
        for (int i = 0; i < transform.childCount; i++){
            planes.Add (transform.GetChild (i).gameObject);
        }
        System.Random rnd = new System.Random();
        int oddPlaneIndex = rnd.Next (0, transform.childCount);
        planes [oddPlaneIndex].transform.Rotate(0, rotvals[0], 0);
        for (int i = 0; i < transform.childCount; i++){
            if (i != oddPlaneIndex){
                planes [i].transform.Rotate(0, rotvals[1], 0);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
