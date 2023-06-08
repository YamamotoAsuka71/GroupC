using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Description : MonoBehaviour
{
    float timer = 0.0f;
    float timer2 = 0.0f;
    Animator animator;
    public bool flag = false;
    
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        timer = 0.0f;
        timer2 = 0.0f;
        GameManager.PlayCount++;
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
            if (Input.GetKeyDown(KeyCode.Return))
            {
                flag = true;
            }
        }
        if (flag == true)
        {
            timer2 += Time.deltaTime;
            if (timer2 > 1.0f)
            {
                SceneManager.LoadScene("Main3d");
            }
        }
    }
}
