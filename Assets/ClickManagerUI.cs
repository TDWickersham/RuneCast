using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickManagerUI : MonoBehaviour {
    public Text score;
    public Text fail;
    // Use this for initialization
    void Start ()
    {
        score.text = "Pairs: " + ClickManager.instance.pairs.ToString();
        fail.text = "Misses: " + ClickManager.instance.possibleFails.ToString();

        ClickManager.instance.scores += scoreUpdate;
    }

    void scoreUpdate()
    {   
     score.text = "Pairs: " + ClickManager.instance.pairs.ToString();
     fail.text = "Misses: " + ClickManager.instance.possibleFails.ToString();

        if (ClickManager.instance.pairs == 0)
        {
            SceneManager.LoadScene("Win");
        }
        else if (ClickManager.instance.possibleFails == 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
