using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneManager : MonoBehaviour {
    public Sprite runes;

    public void addToList()
    {
        ClickManager.instance.addRune(gameObject);
    }

    public bool matched;
}
