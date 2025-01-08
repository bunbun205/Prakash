using UnityEngine;

public class TargetController : MonoBehaviour
{
    public int targetFlag = 0;
    public float Score = 0;
    private int counter = 0; 
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
            if (counter == 0){
                Score += 50;
            }
            else {
                Score += 0.1;
            }
        }
        
        else {
            Debug.Log("Wrong option");
            counter++;
        }
        
    }

}
