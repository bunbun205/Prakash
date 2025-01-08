using UnityEngine;

public class TargetController : MonoBehaviour
{
    public int targetFlag = 0;
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

        if(targetFlag == 1) Debug.Log("Correct option");
        else Debug.Log("Wrong option");
    }
}
