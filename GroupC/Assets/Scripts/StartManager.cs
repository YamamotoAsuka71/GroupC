using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public static bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.PlayCount = 1;
        GameManager.GameCount = 5;
        GameManager.SceneCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.SetInt("scene1", 0);
            PlayerPrefs.SetInt("scene2", 0);
            PlayerPrefs.SetInt("scene3", 0);
            PlayerPrefs.SetInt("scene4", 0);
            PlayerPrefs.SetInt("scene5", 0);
            PlayerPrefs.SetInt("scene6", 0);
            PlayerPrefs.SetInt("scene7", 0);
            PlayerPrefs.SetInt("scene8", 0);
            PlayerPrefs.SetInt("scene9", 0);
        }
    }
}
