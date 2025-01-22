using TMPro;


using UnityEngine;
using UnityEngine.SceneManagement;
public class TargetController : MonoBehaviour
{

    public int targetFlag = 0;
    public float Score = 0;
    private int counter = 0; 
    private float maxdistance = 10;

    public TMP_Text scoreText;
    private GameObject player;
    private PlayerMovementScript playerScript;
    private ColorTargetSetup colorTargetScript;
    private ETargetSetup eTargetScript;
    private FaceTargetSetup facesTargetScript;
    Scene currentScene;

    public void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovementScript>();
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name.Contains("Colors")) {
            colorTargetScript = transform.parent.GetComponent<ColorTargetSetup>();
        } else if(currentScene.name.Contains("Faces")) {
            facesTargetScript = transform.parent.GetComponent<FaceTargetSetup>();
        } else {
            eTargetScript = transform.parent.GetComponent<ETargetSetup>();
        }
    }

    public void OnPointerEnter()
    {
        // Debug.Log(targetFlag);
    }
    public void OnPointerExit()
    {
        // Debug.Log("exit");
    }

    public void OnPointerClick()
    {
        if(targetFlag == 1){

            playerScript.audioSource.PlayOneShot(playerScript.rightAnswerSFX);

            playerScript.speed = 1;
            if(colorTargetScript != null) colorTargetScript.clicked = true;
            else if(facesTargetScript != null) facesTargetScript.clicked = true;
            else eTargetScript.clicked = true;

            if (counter == 0){
                Score += 50;
            }
            else {
                Score += 1;
            }

        }
        
        else {
            playerScript.audioSource.PlayOneShot(playerScript.wrongAnswerSFX);
            counter++;
        }
    }

    public void Update() {
        scoreText.SetText(Score.ToString());
    }

}
