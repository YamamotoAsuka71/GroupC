using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saisyo2 : MonoBehaviour
{
    float timer = 0.0f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        animator = GetComponent<Animator>();
        animator.SetBool("SAISYO", true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            animator.SetBool("SAISYO", false);
        }
    }
}
