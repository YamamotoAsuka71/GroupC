using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int GameCount = 5;
    public static int SceneCount = 5;
    public static int PlayCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartManager.flag = true;
        SceneCount = GameCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
