using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;
    public UnityEvent OnClick;

    public void OnPointerEnter() 
    {
        OnEnter.Invoke();
    }

    public void OnPointerExit() 
    {
        OnExit.Invoke();
    }

    public void OnPointerClick() {
        OnClick.Invoke();
    }
}
