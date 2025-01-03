using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class FaceTargetSetup : MonoBehaviour
{

    public List <Material> FaceMaterials;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        System.Random Rnd = new System.Random ();
        List <Material> randommat = FaceMaterials.OrderBy (x=> Rnd.Next()).Take(2).ToList ();
        List <GameObject> planes = new List<GameObject> ();
        for (int i = 0; i < transform.childCount; i++){

            planes.Add (transform.GetChild (i).gameObject);
        }
        System.Random rnd = new System.Random();
        int oddPlaneIndex = rnd.Next (0, transform.childCount);
        planes [oddPlaneIndex].GetComponent <Renderer>().material = randommat[0];
        for (int i = 0; i < transform.childCount; i++){
            if (i != oddPlaneIndex){
                planes [i].GetComponent <Renderer>().material = randommat[1];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
