using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator4 : MonoBehaviour
{
    Animator animator4;
    // Start is called before the first frame update
    void Start()
    {
        animator4 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator4.SetBool("flg4", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator4.SetBool("flg4", false);
        }
    }
}
