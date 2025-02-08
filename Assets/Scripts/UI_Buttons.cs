using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PlayerMovementScript player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovementScript>();
    }
    public void OnPointerEnter() { }

    public void OnPointerExit() { }

    public void OnPointerClick() {
        switch(transform.parent.gameObject.name)
        {
            case "Start":
                player.speed = 1.0f;
                break;
            case "Return":
                SceneManager.LoadScene("Entrypoint");
                break;
            case "Restart":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case "Next Level":
                Scene activeScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(activeScene.buildIndex + 1);
                break;
        }
    }
}
