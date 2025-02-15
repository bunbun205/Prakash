using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TargetController : MonoBehaviour
{

    public int targetFlag = 0;
    public float Score = 0;
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
            facesTargetScript = null;
            eTargetScript = null;
        }
        else if (currentScene.name.Contains("Faces")) {
            colorTargetScript = null;
            facesTargetScript = transform.parent.GetComponent<FaceTargetSetup>();
            eTargetScript = null;
        }
        else
        {
            colorTargetScript = null;
            facesTargetScript = null;
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

            string activeScene = SceneManager.GetActiveScene().name;
            float distanceToTarget = 0;

            playerScript.speed = 1;
            if (colorTargetScript != null)
            {
                colorTargetScript.clicked = true;
                if (colorTargetScript.counter == 0)
                {
                    Score += (40/19) * (colorTargetScript.distance - 1) + 10;
                }
                else
                {
                    Score += (9/19) * (colorTargetScript.distance - 1) + 1;
                    colorTargetScript.counter = 0;
                }
                distanceToTarget = colorTargetScript.distance;
            }
            else if (facesTargetScript != null)
            {
                facesTargetScript.clicked = true;
                if (facesTargetScript.counter == 0)
                {
                    Score += (40 / 19) * (facesTargetScript.distance - 1) + 10;
                }
                else
                {
                    Score += (9 / 19) * (facesTargetScript.distance - 1) + 1;
                    facesTargetScript.counter = 0;
                }
                distanceToTarget = facesTargetScript.distance;
            }
            else
            {
                eTargetScript.clicked = true;
                if (eTargetScript.counter == 0)
                {
                    Score += (40 / 19) * (eTargetScript.distance - 1) + 10;
                }
                else
                {
                    Score += (9 / 19) * (eTargetScript.distance - 1) + 1;
                    eTargetScript.counter = 0;
                }
                distanceToTarget = eTargetScript.distance;
            }

        }
        
        else {
            string activeScene = SceneManager.GetActiveScene().name;
            float distanceToTarget = 0;

            playerScript.audioSource.PlayOneShot(playerScript.wrongAnswerSFX);
            if (colorTargetScript != null)
            {
                colorTargetScript.counter++;
                distanceToTarget = colorTargetScript.distance;
            }
            else if (facesTargetScript != null)
            {
                facesTargetScript.counter++;
                distanceToTarget = facesTargetScript.distance;
            }
            else {
                eTargetScript.counter++;
                distanceToTarget = eTargetScript.distance;
            }
        }
    }

    public void Update() {
        scoreText.SetText(Score.ToString());
    }

}
