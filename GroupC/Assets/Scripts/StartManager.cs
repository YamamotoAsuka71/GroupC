using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public static bool flag = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        {
            GameManager.PlayCount = 1;
            GameManager.GameCount = 5;
            GameManager.SceneCount = 5;
        }
    }
}
