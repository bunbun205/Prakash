using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour
{
    [Header("References")]
    [SerializeField] ColorSO colorSO;
    [SerializeField] Image original, changed;
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] TMP_Text percentageChangeText;

    [Header("Settings")]
    [Range(0f, 100f)]
    [SerializeField] float  level5PercentageChange;
    [Range(0f, 100f)]
    [SerializeField] float betweenLevelsPercentageChange;

    private int currOptionIdx = 0;
    private Color currentOriginalColor;

    private void Start()
    {
        currentOriginalColor = original.color;
    }

    public void OnDropdownValueChange(int idx)
    {
        currOptionIdx = idx;
        TMP_Dropdown.OptionData selectedOption = dropdown.options[idx];
        switch(selectedOption.text)
        {
            case "1":
                ShowLevelColors(1);
                break;
            case "2":
                ShowLevelColors(2);
                break;
            case "3":
                ShowLevelColors(3);
                break;
            case "4":
                ShowLevelColors(4);
                break;
            case "5":
                ShowLevelColors(5);
                break;
        }
    }

    private void Update()
    {
        if(currentOriginalColor != original.color)
        {
            OnDropdownValueChange(currOptionIdx);
            currentOriginalColor = original.color;
        }
    }

    private void ShowLevelColors(int levelNum)
    {
        Color color = original.color;

        float change = (level5PercentageChange / 100f) + (5 - levelNum) * (betweenLevelsPercentageChange / 100f);
        percentageChangeText.text = $"Percentage Change: {change * 100}%";
        color.r += change;
        color.g += change;
        color.b += change;

        changed.color = color;

        colorSO.level5PercentageChange = level5PercentageChange;
        colorSO.betweenLevelPercentageChange = betweenLevelsPercentageChange;
    }

    private void OnValidate()
    {
        OnDropdownValueChange(currOptionIdx);
    }

    public void AddColorAction()
    {
        colorSO.Add(original.color);
        colorSO.level5PercentageChange = level5PercentageChange;
        colorSO.betweenLevelPercentageChange = betweenLevelsPercentageChange;
    }
}
