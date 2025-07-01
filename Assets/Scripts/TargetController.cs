using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TargetController : MonoBehaviour
{

    public int targetFlag = 0;
    public float Score = 0;
    //public TMP_Text scoreText;
    private GameObject player;
    private PlayerMovementScript playerScript;
    private ColorTargetSetup colorTargetScript;
    private ETargetSetup eTargetScript;
    private FaceTargetSetup facesTargetScript;
    Scene currentScene;
    private DataManagement dbmngr;

    public void Start()
    {
        dbmngr = GameObject.Find("DataManager").GetComponent<DataManagement>().dbmgr;
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
        Parameters param = dbmngr.param;

        dbmngr.mode = SceneManager.GetActiveScene().name;
        dbmngr.numTarget = transform.parent.GetSiblingIndex() + 1;

        if (targetFlag == 1){

            param.hit = "correct hit";

            playerScript.audioSource.PlayOneShot(playerScript.rightAnswerSFX);
            playerScript.speed = 3;
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
                param.distanceToTarget = colorTargetScript.distance;
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
                param.distanceToTarget = facesTargetScript.distance;
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
                param.distanceToTarget = eTargetScript.distance;
            }

            param.score = Score;

        }
        
        else {
            param.hit = "incorrect hit";
            playerScript.audioSource.PlayOneShot(playerScript.wrongAnswerSFX);
            if (colorTargetScript != null)
            {
                colorTargetScript.counter++;
                param.distanceToTarget = colorTargetScript.distance;
            }
            else if (facesTargetScript != null)
            {
                facesTargetScript.counter++;
                param.distanceToTarget = facesTargetScript.distance;
            }
            else {
                eTargetScript.counter++;
                param.distanceToTarget = eTargetScript.distance;
            }
        }

        dbmngr.SendData();
    }

    public void Update() {
        //scoreText.SetText(Score.ToString());
    }

}
