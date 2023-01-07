using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationUIManager : MonoBehaviour
{
    public Text mackerelText;
    public Text tunaText;
    public Text sharkText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.UpdatePopulationCounts();
        mackerelText.text = "Mackerel Population: " + GameManager.instance.mackerelPopulation;
        tunaText.text = "Tuna Population: " + GameManager.instance.tunaPopulation;
        sharkText.text = "Shark Population: " + GameManager.instance.sharkPopulation;
    }
}
