using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class owari3 : MonoBehaviour
{
    bool flag = false;
    float timer = 0.0f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            flag = true;
            animator.SetBool("OWARI", true);
        }
        if (flag == true)
        {
            timer += Time.deltaTime;
        }
        if (timer > 1.0f)
        {
            SceneManager.LoadScene("Main3d");
        }
    }
}
