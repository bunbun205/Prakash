using System.Collections.Generic;
using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    public int Rcount = 0, Gcount = 0, Bcount = 0;
    public int minSaturation, maxSaturation, minValue, maxValue;
    public List<int> colorChoices;

    void Awake()
    {
        for (int i = 0; i < 15; i++)
        {
            // Select a color that is not yet at its maximum count
            int colorChoice = GetNextColor();

            // Add the color to the list
            colorChoices.Add(colorChoice);

            // Increment the count for the selected color
            if (colorChoice == 0)
            {
                Rcount++;
            }
            else if (colorChoice == 1)
            {
                Gcount++;
            }
            else
            {
                Bcount++;
            }
        }

        setMinMaxValues();

    }

    private void setMinMaxValues()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "Colors_Level_1":
                minSaturation = 200;
                maxSaturation = 256;
                minValue = 150;
                maxValue = 250;
                break;
            case "Colors_Level_2":
                minSaturation = 150;
                maxSaturation = 200;
                minValue = 150;
                maxValue = 200;
                break;
            case "Colors_Level_3":
                minSaturation = 100;
                maxSaturation = 150;
                minValue = 100;
                maxValue = 200;
                break;
            case "Colors_Level_4":
                minSaturation = 50;
                maxSaturation = 100;
                minValue = 100;
                maxValue = 150;
                break;
        }
    }

    private int GetNextColor()
    {
        // Get a list of colors that are not yet at their maximum count
        List<int> availableColors = new List<int>();
        if (Rcount < 5)
        {
            availableColors.Add(0);
        }
        if (Gcount < 5)
        {
            availableColors.Add(1);
        }
        if (Bcount < 5)
        {
            availableColors.Add(2);
        }

        // Select a random color from the available colors
        int randomIndex = Random.Range(0, availableColors.Count);
        return availableColors[randomIndex];
    }
}
