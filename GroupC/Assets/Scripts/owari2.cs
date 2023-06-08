using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class owari2 : MonoBehaviour
{
    [SerializeField] Explain explain;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("OWARI", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (explain.flag == true)
        {
            animator.SetBool("OWARI", true);
        }
    }
}
