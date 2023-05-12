using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator1 : MonoBehaviour
{
    Animator animator1;
    // Start is called before the first frame update
    void Start()
    {
        animator1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator1.SetBool("flg1", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator1.SetBool("flg1", false);
        }
    }
}
