using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class FaceTargetSetup : MonoBehaviour
{

    public List <Material> FaceMaterials;
    public GameObject player;
    private PlayerMovementScript script;
    public bool clicked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerMovementScript>();
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
        controlScripts [oddPlaneIndex].targetFlag = 1;
        for (int i = 0; i < transform.childCount; i++){
            if (i != oddPlaneIndex){
                planeTransforms [i].GetComponent <Renderer>().material = randommat[1];
            }
        }
    }

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= 1 && !clicked) {
            script.speed = 0;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform plane = transform.GetChild(i);
            Vector3 direction = (player.transform.position - plane.position).normalized;
            // plane.rotation = Quaternion.LookRotation(direction, Vector3.up);
            float angle = Mathf.Atan2(direction.x, direction.z);

            // Set the plane's rotation using Euler angles
            plane.eulerAngles = new Vector3(90, angle * Mathf.Rad2Deg , 0);
        }

    }
}
