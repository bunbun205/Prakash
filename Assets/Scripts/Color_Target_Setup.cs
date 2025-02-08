using UnityEngine;
using System.Collections.Generic;

public class ColorTargetSetup : MonoBehaviour
{

    float grayValue = 0.0f;
    int transformIndex;
    public GameObject player;
    private PlayerMovementScript script;
    public bool clicked = false;
    public int counter = 0;
    ColorSetter setterScript;
    public float distance = 0;
    void Start()
    {
        transformIndex = transform.GetSiblingIndex();
        setterScript = transform.parent.GetComponent<ColorSetter>();
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerMovementScript>();
        List<Transform> planeTransforms = new List<Transform>();
        List<TargetController> controlScripts = new List<TargetController>();
        for (int i = 0; i < transform.childCount; i++)
        {

            planeTransforms.Add(transform.GetChild(i));
            controlScripts.Add(transform.GetChild(i).GetComponent<TargetController>());

        }
        System.Random rnd = new System.Random();
        int oddPlaneIndex = rnd.Next(0, transform.childCount);
        Color baseColor = GetRandomPureColor();
        planeTransforms[oddPlaneIndex].gameObject.GetComponent<Renderer>().material.color = baseColor;
        controlScripts[oddPlaneIndex].targetFlag = 1;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i != oddPlaneIndex)
            {
                planeTransforms[i].GetComponent<Renderer>().material.color = Color.HSVToRGB(H: 0.0f, S: 0.0f, V: grayValue);
            }
        }
    }

    private Color GetRandomPureColor()
    {
        int colorChoice = setterScript.colorChoices[transformIndex];
        float valueChoice1 = Random.Range(setterScript.minSaturation, setterScript.maxSaturation);
        float valueChoice2 = Random.Range(setterScript.minValue, setterScript.maxValue);
        float h, s, v;

        s = valueChoice1 / 256;
        switch (colorChoice)
        {
            case 0:
                h = 0;
                break;
            case 1:
                h = 0.33333333f;
                break;
            case 2:
                h = 0.66666666f;
                break;
            default:
                h = 0;
                s = 0;
                break;
        }

        v = valueChoice2 / 256;
        grayValue = v;

        Color finalColor = Color.HSVToRGB(H: h, S: s, V: v);

        return finalColor;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= 1 && !clicked)
        {
            script.speed = 0;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform plane = transform.GetChild(i);
            Vector3 direction = (player.transform.position - plane.position).normalized;
            // plane.rotation = Quaternion.LookRotation(direction, Vector3.up);
            float angle = Mathf.Atan2(direction.x, direction.z);

            // Set the plane's rotation using Euler angles
            plane.eulerAngles = new Vector3(90, angle * Mathf.Rad2Deg, 0);
        }

    }

}
