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
        List <Transform> planeTransforms = new List<Transform> ();
        List <TargetController> controlScripts = new List<TargetController> ();
        for (int i = 0; i < transform.childCount; i++){

            planeTransforms.Add (transform.GetChild (i));
            controlScripts.Add (transform.GetChild (i).GetComponent<TargetController>());

        }
        System.Random rnd = new System.Random();
        int oddPlaneIndex = rnd.Next (0, transform.childCount);
        planeTransforms[oddPlaneIndex].gameObject.GetComponent <Renderer>().material = randommat[0];
        controlScripts [0].targetFlag = 1;
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