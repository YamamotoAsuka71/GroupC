using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryManager : MonoBehaviour
{
    public GameObject[] gallery = new GameObject[9];
    public static bool[] picture = new bool[9];
    public GameObject[] panel = new GameObject[9];
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("scene1", 0) == 1)
        {
            gallery[0].SetActive(true);
        }
        else
        {
            gallery[0].SetActive(false);
        }
        if (PlayerPrefs.GetInt("scene2", 0) == 1)
        {
            gallery[1].SetActive(true);
        }
        else
        {
            gallery[1].SetActive(false);
        }
        if (PlayerPrefs.GetInt("scene3", 0) == 1)
        {
            gallery[2].SetActive(true);
        }
        else
        {
            gallery[2].SetActive(false);
        }
        if (PlayerPrefs.GetInt("scene4", 0) == 1)
        {
            gallery[3].SetActive(true);
        }
        else
        {
            gallery[3].SetActive(false);
        }
        if (PlayerPrefs.GetInt("scene5", 0) == 1)
        {
            gallery[4].SetActive(true);
        }
        else
        {
            gallery[4].SetActive(false);
        }
        if (PlayerPrefs.GetInt("scene6", 0) == 1)
        {
            gallery[5].SetActive(true);
        }
        else
        {
            gallery[5].SetActive(false);
        }
        if (PlayerPrefs.GetInt("scene7", 0) == 1)
        {
            gallery[6].SetActive(true);
        }
        else
        {
            gallery[6].SetActive(false);
        }
        if (PlayerPrefs.GetInt("scene8", 0) == 1)
        {
            gallery[7].SetActive(true);
        }
        else
        {
            gallery[7].SetActive(false);
        }
        if (PlayerPrefs.GetInt("scene9", 0) == 1)
        {
            gallery[8].SetActive(true);
        }
        else
        {
            gallery[8].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            if (picture[i] == true)
            {
                for (int n = 0; n < 9; n++)
                {
                    panel[n].SetActive(false);
                }
                panel[i].SetActive(true);
            }
        }
    }
}
