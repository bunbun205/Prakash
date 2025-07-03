using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ColorTargetSetup : MonoBehaviour
{

    float grayValue = 0.5f;
    [SerializeField] ColorSO colorSO;
    Color[] colors;
    [Range(0, 100f)]
    float level5PercentageChange;
    float betweenLevelPercentageChange;
    float delta;
    int transformIndex;
    public GameObject player;
    private PlayerMovementScript script;
    public bool clicked = false;
    public int counter = 0;
    public float distance = 0;

    private int randomColorIndex = 0;
    void Start()
    {
        colors = colorSO.GetArray();
        level5PercentageChange = colorSO.level5PercentageChange;
        betweenLevelPercentageChange = colorSO.betweenLevelPercentageChange;

        transformIndex = transform.GetSiblingIndex();
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerMovementScript>();
        string currentScene = SceneManager.GetActiveScene ().name;
        switch (currentScene) {
            case "Colors_Level_1":
            delta = (level5PercentageChange + 4 * betweenLevelPercentageChange) / 100f; ;
            break;
            case "Colors_Level_2":
            delta = (level5PercentageChange + 3 * betweenLevelPercentageChange) / 100f; ;
            break;
            case "Colors_Level_3":
            delta = (level5PercentageChange + 2* betweenLevelPercentageChange) / 100f; ;
            break;
            case "Colors_Level_4":
            delta = (level5PercentageChange + betweenLevelPercentageChange)/100f;
            break;
            case "Colors_Level_5":
            delta = level5PercentageChange/100f;
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
        int colorChoice = Random.Range (0,colors.Length);
        Color finalColor = colors[randomColorIndex];

        finalColor.r += delta;
        finalColor.g += delta;
        finalColor.b += delta;

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
