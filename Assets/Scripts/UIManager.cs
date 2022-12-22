using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button startButton;
    public Text inputMackerelPopulation;
    private int defaultMackerelPopulation = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void clickStartButton()
    {
        if (!string.IsNullOrEmpty(inputMackerelPopulation.text))
        {
            int inputPop;
            bool canParseInput = int.TryParse(inputMackerelPopulation.text, out inputPop);
            if (canParseInput)
            {
                GameManager.instance.mackerelPopulation = inputPop;
            }
            else
            {
                Debug.Log("Can't parse input population");
                return;
            }
        }
        else
        {
            GameManager.instance.mackerelPopulation = defaultMackerelPopulation;
        }

        SceneManager.LoadScene(1);
    }

}
