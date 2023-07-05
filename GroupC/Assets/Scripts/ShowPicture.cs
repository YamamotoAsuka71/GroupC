using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPicture : MonoBehaviour
{
    public GameObject[] picture=new GameObject[9];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            picture[i].SetActive(false);
        }
        for (int i = 0; i < 9; i++)
        {
            if (GalleryManager.picture[i] == true)
            {
                picture[i].SetActive(true);
            }
        }
    }
}
