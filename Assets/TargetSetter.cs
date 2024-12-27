using UnityEngine;
using System.Linq;
using System.Collections.Generic;


public class TargetSetter : MonoBehaviour
{
    public List<Material> FaceMaterials;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        System.Random rnd = new System.Random();
        List<Material> randomMats = FaceMaterials.OrderBy(x => rnd.Next()).Take(2).ToList();

        Debug.Log(randomMats);


        List<GameObject> planes = new List<GameObject>();

        for (int i = 0; i < transform.childCount; i++) {
            planes.Add(transform.GetChild(i).gameObject);
        }

        System.Random rand = new System.Random();
        int oddPlaneIndex = rand.Next(0, transform.childCount);
        planes[oddPlaneIndex].GetComponent<Renderer>().material = randomMats[0];

        for (int i = 0; i < transform.childCount; i++)
        {
            if (i != oddPlaneIndex)
            {
                planes[i].GetComponent<Renderer>().material = randomMats[1];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
