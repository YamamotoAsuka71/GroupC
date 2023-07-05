using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    public void OnClick1()
    {
        for (int i = 0; i < 9; i++)
        {
            GalleryManager.picture[i] = false;
        }
        GalleryManager.picture[0] = true;
    }
    public void OnClick2()
    {
        for (int i = 0; i < 9; i++)
        {
            GalleryManager.picture[i] = false;
        }
        GalleryManager.picture[1] = true;
    }
    public void OnClick3()
    {
        for (int i = 0; i < 9; i++)
        {
            GalleryManager.picture[i] = false;
        }
        GalleryManager.picture[2] = true;
    }
    public void OnClick4()
    {
        for (int i = 0; i < 9; i++)
        {
            GalleryManager.picture[i] = false;
        }
        GalleryManager.picture[3] = true;
    }
    public void OnClick5()
    {
        for (int i = 0; i < 9; i++)
        {
            GalleryManager.picture[i] = false;
        }
        GalleryManager.picture[4] = true;
    }
    public void OnClick6()
    {
        for (int i = 0; i < 9; i++)
        {
            GalleryManager.picture[i] = false;
        }
        GalleryManager.picture[5] = true;
    }
    public void OnClick7()
    {
        for (int i = 0; i < 9; i++)
        {
            GalleryManager.picture[i] = false;
        }
        GalleryManager.picture[6] = true;
    }
    public void OnClick8()
    {
        for (int i = 0; i < 9; i++)
        {
            GalleryManager.picture[i] = false;
        }
        GalleryManager.picture[7] = true;
    }
    public void OnClick9()
    {
        for (int i = 0; i < 9; i++)
        {
            GalleryManager.picture[i] = false;
        }
        GalleryManager.picture[8] = true;
    }
}
