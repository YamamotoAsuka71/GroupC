using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryGo : MonoBehaviour
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
        SceneManager.LoadScene("Gallery");
    }
    public void OnClick2()
    {
        SceneManager.LoadScene("Title");
    }
}
