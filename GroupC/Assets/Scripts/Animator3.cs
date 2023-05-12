using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator3 : MonoBehaviour
{
    Animator animator3;
    // Start is called before the first frame update
    void Start()
    {
        animator3 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            animator3.SetBool("flg3", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator3.SetBool("flg3", false);
        }
    }
}
