using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int Count = 4;
    public GameObject LIFE;
    public GameObject life4;
    public GameObject life3;
    public GameObject life2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(Count)
        {
            case 3:
                Destroy(life4);
                break;
            case 2:
                Destroy(life3);
                break;
            case 1:
                Destroy(life2);
                break;
        }
    }
}
