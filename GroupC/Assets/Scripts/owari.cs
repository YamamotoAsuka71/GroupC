using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class owari : MonoBehaviour
{
    
    [SerializeField] Description Description;
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
        if (Description.flag == true)
        {

            animator.SetBool("OWARI", true);
        }
    }
}
