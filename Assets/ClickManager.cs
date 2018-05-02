using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    int possibleFails = 10;
    int pairs = 9;
    public List<GameObject> compared;
    public static ClickManager instance;
    public Sprite blank;
    public Text score;
    public Text fail;
    public float blankDelay;
    bool display;
	// Use this for initialization
	void Start ()
    {
		if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        score.text = "Pairs: " + pairs.ToString();
        fail.text = "Misses: " + possibleFails.ToString();
        compared = new List<GameObject>();
	}

    // Update is called once per frame
    public void addRune(GameObject addedRune)
    {
        if (compared.Contains(addedRune) == false)
        {
            compared.Add(addedRune);
            display = false;
            addedRune.GetComponent<Image>().sprite = addedRune.GetComponent<RuneManager>().runes;
        }
        

        if (compared.Count == 2)
        {
            if (compared[0].tag == compared[1].tag)
            {
                if (addedRune.GetComponent<RuneManager>().matched == true && compared[0].GetComponent<RuneManager>().matched == true)
                {
                    possibleFails--;
                }
                else
                {
                    compared[0].GetComponent<RuneManager>().matched = true;
                    addedRune.GetComponent<RuneManager>().matched = true;
                    pairs--;
                }
            }
            else
            {
                playBlank(compared[0], compared[1]);
               // compared[0].GetComponent<Image>().sprite = blank;
               // addedRune.GetComponent<Image>().sprite = blank;
                possibleFails--;
            }

            compared.Clear();
        }
    }

    void playBlank(GameObject rune1, GameObject rune2)
    {
        display = true;
        StartCoroutine(setBlankWithDelay(rune1, rune2));
    }


    IEnumerator setBlankWithDelay(GameObject rune1, GameObject rune2)
    {
        float t = 0;
        while (t < 1 && display == true)
        {
            t += Time.deltaTime / blankDelay;
            yield return null;
        }
        rune1.GetComponent<Image>().sprite = blank;
        rune2.GetComponent<Image>().sprite = blank;

    }


    private void Update()
    {
        score.text = "Pairs: " + pairs.ToString();
        fail.text = "Misses: " + possibleFails.ToString();
        if (pairs == 0)
        {
            SceneManager.LoadScene("Win");
        }
        else if (possibleFails == 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
    
}

