using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ColorTargetSetup : MonoBehaviour
{

    float grayValue = 0.5f;
    [SerializeField] Color[] colors;
    [Range(0, 100f)]
    public float colorChangePercentage;
    public float percentageChange;
    public float delta;
    int transformIndex;
    public GameObject player;
    private PlayerMovementScript script;
    public bool clicked = false;
    public int counter = 0;
    public float distance = 0;

    private int randomColorIndex = 0;
    void Start()
    {
        transformIndex = transform.GetSiblingIndex();
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerMovementScript>();
        string currentScene = SceneManager.GetActiveScene ().name;
        switch (currentScene) {
            case "Colors_Level_1":
            delta = (colorChangePercentage +4 * percentageChange) / 100f; ;
            break;
            case "Colors_Level_2":
            delta = (colorChangePercentage +3 * percentageChange) / 100f; ;
            break;
            case "Colors_Level_3":
            delta = (colorChangePercentage + 2* percentageChange) / 100f; ;
            break;
            case "Colors_Level_4":
            delta = (colorChangePercentage + percentageChange)/100f;
            break;
            case "Colors_Level_5":
            delta = colorChangePercentage/100f;
            break;
        }
        List<Transform> planeTransforms = new List<Transform>();
        List<TargetController> controlScripts = new List<TargetController>();
        for (int i = 0; i < transform.childCount; i++)
        {

            planeTransforms.Add(transform.GetChild(i));
            controlScripts.Add(transform.GetChild(i).GetComponent<TargetController>());

        }
        System.Random rnd = new System.Random();
        int oddPlaneIndex = rnd.Next(0, transform.childCount);

        randomColorIndex = Random.Range(0, 3);
        Color baseColor = GetRandomPureColor();
        planeTransforms[oddPlaneIndex].gameObject.GetComponent<Renderer>().material.color = baseColor;
        controlScripts[oddPlaneIndex].targetFlag = 1;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i != oddPlaneIndex)
            {
                planeTransforms[i].GetComponent<Renderer>().material.color = colors[randomColorIndex];
            } else {
                Debug.Log(planeTransforms[i].GetComponent<Renderer>().material.color);
            }
        }
    }

    private Color GetRandomPureColor()
    {
        int colorChoice = Random.Range (0,3);
        //Color finalColor = new Color(r, g, b, 1.0f);
        Color finalColor = colors[randomColorIndex];
        finalColor[colorChoice] += delta;
        // float h, s;

        // // switch (colorChoice)
        // // {
        // //     case 0:
        // //         finalColor
        // //         break;
        // //     case 1:
        // //         h = 0.33333333f;
        // //         break;
        // //     case 2:
        // //         h = 0.66666666f;
        // //         break;
        // //     default:
        // //         h = 0;
        // //         s = 0;
        // //         break;
        // // }

        // s = grayValue + delta;

        //  = Color.HSVToRGB(H: h, S: s, V: grayValue);

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
