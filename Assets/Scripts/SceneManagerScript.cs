using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadScene(string SectionName) {
        SceneManager.LoadScene(SectionName);
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
        if (SceneManager.GetActiveScene().name == "Entrypoint")
        {
            switch(transform.gameObject.name) {
                case "E":
                    LoadScene("E_Level_1");
                    break;
                case "Faces":
                    LoadScene("Faces_Level_1");
                    break;
                case "Colors":
                    LoadScene("Colors_Level_1");
                    break;
            }
        }

    }
}
