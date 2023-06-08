using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saigo : MonoBehaviour
{
    public GameObject stamina;
    public bool flag = false;
    float timer = 0.0f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        flag = false;
        timer = 0.0f;
        animator.SetBool("SAIGO", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        {
            stamina.SetActive(false);
            animator.SetBool("SAIGO", true);
            timer += Time.deltaTime;
            if (timer > 1.0f)
            {
                switch (GameManager.SceneCount)
                {
                    case 1:
                        SceneManager.LoadScene("Description1");
                        break;
                    case 2:
                        SceneManager.LoadScene("Description2");
                        break;
                    case 3:
                        SceneManager.LoadScene("Description3");
                        break;
                    case 4:
                        SceneManager.LoadScene("Description4");
                        break;
                    case 5:
                        SceneManager.LoadScene("Description5");
                        break;
                    case 6:
                        SceneManager.LoadScene("Description6");
                        break;
                    case 7:
                        SceneManager.LoadScene("Description7");
                        break;
                    case 8:
                        SceneManager.LoadScene("Description8");
                        break;
                    case 9:
                        SceneManager.LoadScene("Description9");
                        break;
                }
            }
        }
    }
}
