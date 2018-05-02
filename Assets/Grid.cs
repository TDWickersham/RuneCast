using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour {
    public List<GameObject> Runes;
    public GameObject[] prefabs;
    public Sprite blank;
    public float space;
    public int width;
    public int height;
	// Use this for initialization
	void Start ()
    {
        Runes = new List<GameObject>();
		for (int i = 0; i < prefabs.Length; i++)
        {
            GameObject rune1 = Instantiate(prefabs[i]);
            GameObject rune2 = Instantiate(prefabs[i]);
            Runes.Add(rune1);
            Runes.Add(rune2);
        }
        int index = 0;
        reshuffle();
        for (int i = 0; i < width; i++)
        {
            
            for (int j = 0; j < height; j++)
            {
                
                Vector2 spawnPosition = (Vector2)transform.position + (Vector2.up * j * space) + (Vector2.right * i * space);
                Runes[index].GetComponent<RuneManager>().runes = Runes[index].GetComponent<Image>().sprite;
                Runes[index].GetComponent<Image>().sprite = blank;
                Runes[index].transform.position = spawnPosition;
                Runes[index].transform.parent = transform;
                index++;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void reshuffle()
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < Runes.Count; t++)
        {
            GameObject tmp = Runes[t];
            int r = Random.Range(t, Runes.Count);
           Runes[t] = Runes[r];
           Runes[r] = tmp;
        }
    }
}
