using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPoints : MonoBehaviour
{
    [SerializeField] Mapgeneration mapgeneration;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1.0f)
        {
            PositionMove();
            timer = 2.0f;
        }
    }
    void PositionMove()
    {
        transform.position = new Vector3((mapgeneration.GoalPositionX * 5) - (13 * 5) / 2, (mapgeneration.GoalPositionY * 5) - (13 * 5) / 2, 0.0f);   //  ゴールを生成
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Description4");
        }
    }
}
