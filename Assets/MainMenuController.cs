using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    private SceneManagerScript _sceneManager;
    private UIDocument _document;
    private Button _ebutton;
    private Button _facesbutton;
    private Button _colorsbutton;

    private List<Event> _events;

    private void Awake() {
        _document = GetComponent<UIDocument>();
        _sceneManager = new SceneManagerScript();
        _ebutton = _document.rootVisualElement.Q("E") as Button;
        _facesbutton = _document.rootVisualElement.Q("Faces") as Button;
        _colorsbutton = _document.rootVisualElement.Q("Colors") as Button;
        _ebutton.RegisterCallback<ClickEvent>(LoadEScene);
        _facesbutton.RegisterCallback<ClickEvent>(LoadEScene);
        _colorsbutton.RegisterCallback<ClickEvent>(LoadEScene);
    }

    private void OnDisable() {
        _ebutton.UnregisterCallback<ClickEvent>(LoadEScene);
    }

    private void LoadEScene(ClickEvent e) {
        Button button = e.target as Button;
        switch(button.name) {
            case "E":
                _sceneManager.LoadScene("E_Level_1");
            break;
            case "Faces":
                _sceneManager.LoadScene("Faces_Level_1");
            break;
            case "Colors":
                _sceneManager.LoadScene("Colors_Level_1");
            break;
        }
    }
}
