using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int m_MackerelPopulation = 2000;
    public int tunaPopulation { get; private set; }
    public int sharkPopulation { get; private set; }

    // ENCAPSULATION
    public int mackerelPopulation
    {
        get { return m_MackerelPopulation; }

        set
        {
            if (value < 0)
            {
                Debug.LogError("Mackerel population must be zero or more.");
            }
            else
            {
                m_MackerelPopulation = value;
            }
        }
    }

    // Implement singleton pattern
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void UpdatePopulationCounts()
    {
        m_MackerelPopulation = GameObject.FindObjectsOfType<Mackerel>().Length;
        tunaPopulation = GameObject.FindObjectsOfType<Tuna>().Length;
        //sharkPopulation = GameObject.FindObjectsOfType<Shark>().Length;
    }

}
