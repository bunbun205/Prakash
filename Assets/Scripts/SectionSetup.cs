using Unity.Mathematics;
using UnityEngine;

public class SectionSetup : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Transform child1 = transform.GetChild(0);
        Transform child2 = transform.GetChild(1);
        Transform child3 = transform.GetChild(2);

        child1.position = new Vector3(3 * math.sqrt(3)/2, 1.5f, 1.5f);
        child2.position = new Vector3(3, 1.5f, 0);
        child3.position = new Vector3(3 * math.sqrt(3)/2, 1.5f, -1.5f);

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform plane = transform.GetChild(i);
            Vector3 direction = (player.transform.position - plane.position).normalized;
            float angle = Mathf.Atan2(direction.x, direction.z);

            // Set the plane's rotation using Euler angles
            plane.eulerAngles = new Vector3(90, angle * Mathf.Rad2Deg, 0);
        }
    }
}
