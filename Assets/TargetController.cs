using TMPro;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public int targetFlag = 0;
    public float Score = 0;
    private int counter = 0; 
    private float max distance = 10;

    public TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

    public void onPointerEnter() {
        Debug.Log("enter");
    }

    public void onPointerExit() {
        Debug.Log("exit");
    }
    public void OnPointerClick(){

        if(targetFlag == 1){
            Debug.Log("Correct option");
            PlayerMovementScript player = new PlayerMovementScript();
            if(!player.move) {
                player.move = true;
            }
            if (counter == 0){
                Score += (40/(max distance - 1)) * player.distanceToTarget;
            }
            else {
                Score += 1;
            }

        }
        
        else {
            Debug.Log("Wrong option");
            counter++;
        }
        
    }

    public void Update() {
        scoreText.SetText(Score.ToString());
    }

}
