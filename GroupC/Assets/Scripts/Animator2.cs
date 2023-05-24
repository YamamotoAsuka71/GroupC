using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator2 : MonoBehaviour
{
    Animator animator2;
    // Start is called before the first frame update
    void Start()
    {
        animator2 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            animator2.SetBool("flg2", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator2.SetBool("flg2", false);
        }
    }
}
