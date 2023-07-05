using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Description : MonoBehaviour
{
    [SerializeField] Story1 story;
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

        switch (GameManager.SceneCount)
        {
            case 1:
                PlayerPrefs.SetInt("scene1", 1);
                PlayerPrefs.Save();
                break;
            case 2:
                PlayerPrefs.SetInt("scene2", 1);
                PlayerPrefs.Save();
                break;
            case 3:
                PlayerPrefs.SetInt("scene3", 1);
                PlayerPrefs.Save();
                break;
            case 4:
                PlayerPrefs.SetInt("scene4", 1);
                PlayerPrefs.Save();
                break;
            case 5:
                PlayerPrefs.SetInt("scene5", 1);
                PlayerPrefs.Save();
                break;
            case 6:
                PlayerPrefs.SetInt("scene6", 1);
                PlayerPrefs.Save();
                break;
            case 7:
                PlayerPrefs.SetInt("scene7", 1);
                PlayerPrefs.Save();
                break;
            case 8:
                PlayerPrefs.SetInt("scene8", 1);
                PlayerPrefs.Save();
                break;
            case 9:
                PlayerPrefs.SetInt("scene9", 1);
                PlayerPrefs.Save();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            animator.SetBool("SAISYO", false);
            if (story.scenarios.Length == story.currentLine && Input.GetKeyDown(KeyCode.Return))
            {
                flag = true;
            }
        }
        if (flag == true)
        {
            timer2 += Time.deltaTime;
            if (timer2 > 1.0f)
            {
                if (GameManager.PlayCount >= 6)
                {
                    SceneManager.LoadScene("Title");
                }
                else
                {
                    SceneManager.LoadScene("Main3d");
                }
                
            }
        }
    }
}
