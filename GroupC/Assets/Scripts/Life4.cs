using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life4 : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Player.transform.position;
        transform.position = new Vector3(pos.x - 5.0f, pos.y + 4.3f, 0.0f);
    }
}
