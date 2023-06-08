using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieController : MonoBehaviour
{
    [SerializeField] saigo saigo;
    [SerializeField] charactercontrol charactercontrol;
    [SerializeField] Life life;
    public GameObject Front;
    public GameObject Left;
    public GameObject Right;
    public GameObject Back;
    public GameObject Player;
    float timer = 0.0f;
    float timer2 = 0.0f;
    float timer3 = 0.0f;
    bool flag = false;
    bool flag2 = false;
    float speed = 3;
    private Vector3 PlayerPosition;
    private Vector3 EnemyPosition;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPosition = Player.transform.position;
        EnemyPosition = transform.position;
        Front.SetActive(false);
        Left.SetActive(false);
        Right.SetActive(false);
        Back.SetActive(false);
        transform.position = new Vector3(-22.0f, 18.0f, -5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition = Player.transform.position;
        EnemyPosition = transform.position;
        speed = speed * Time.deltaTime;
        timer3 += Time.deltaTime;
        if (timer3 >= 2.0f)
        {
            timer2 += Time.deltaTime;
            if (timer2 >= 1.0f)
            {
                flag2 = true;
            }
            timer += Time.deltaTime;
        }
        //Debug.Log(life.Count);
        if (life.Count == 0)
        {
            GameManager.GameCount++;
            saigo.flag = true;
            Destroy(gameObject);
        }
        if (timer >= 3 && timer < 3.5f)
        {
            Front.SetActive(true);
            flag = true;
        }
        if (flag == true)
        {
            /*if (PlayerPosition.x > EnemyPosition.x && PlayerPosition.y > EnemyPosition.y)
            {
                EnemyPosition.x = EnemyPosition.x + 3.0f * Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y + 3.0f * Time.deltaTime;
            }
            else if (PlayerPosition.x < EnemyPosition.x && PlayerPosition.y > EnemyPosition.y)
            {
                EnemyPosition.x = EnemyPosition.x - 3.0f * Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y + 3.0f * Time.deltaTime;
            }

            else if (PlayerPosition.x > EnemyPosition.x && PlayerPosition.y < EnemyPosition.y)
            {
                EnemyPosition.x = EnemyPosition.x + 3.0f * Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y - 3.0f * Time.deltaTime;
            }
            else if (PlayerPosition.x < EnemyPosition.x && PlayerPosition.y < EnemyPosition.y)
            {
                EnemyPosition.x = EnemyPosition.x - 3.0f * Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y - 3.0f * Time.deltaTime;
            }
            */
            if (PlayerPosition.x - EnemyPosition.x < 0 && Mathf.Abs(PlayerPosition.x - EnemyPosition.x) > Mathf.Abs(PlayerPosition.y - EnemyPosition.y))
            {
                EnemyPosition.x = EnemyPosition.x - 4.75f * Time.deltaTime;
                Left.SetActive(true);
                Right.SetActive(false);
                Back.SetActive(false);
                Front.SetActive(false);
            }
            else if (PlayerPosition.x - EnemyPosition.x > 0 && Mathf.Abs(PlayerPosition.x - EnemyPosition.x) > Mathf.Abs(PlayerPosition.y - EnemyPosition.y))
            {
                EnemyPosition.x = EnemyPosition.x + 4.75f * Time.deltaTime;
                Left.SetActive(false);
                Right.SetActive(true);
                Back.SetActive(false);
                Front.SetActive(false);
            }
            else if (PlayerPosition.y - EnemyPosition.y < 0 && Mathf.Abs(PlayerPosition.x - EnemyPosition.x) < Mathf.Abs(PlayerPosition.y - EnemyPosition.y))
            {
                EnemyPosition.y = EnemyPosition.y - 4.75f * Time.deltaTime;
                Left.SetActive(false);
                Right.SetActive(false);
                Back.SetActive(false);
                Front.SetActive(true);
            }
            else if (PlayerPosition.y - EnemyPosition.y > 0 && Mathf.Abs(PlayerPosition.x - EnemyPosition.x) < Mathf.Abs(PlayerPosition.y - EnemyPosition.y))
            {
                EnemyPosition.y = EnemyPosition.y + 4.75f * Time.deltaTime;
                Left.SetActive(false);
                Right.SetActive(false);
                Back.SetActive(true);
                Front.SetActive(false);
            }
            transform.position = EnemyPosition;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (flag2 == true)
            {
                life.Count--;
                transform.position = new Vector3(-22.0f, 18.0f, -5.0f);
                timer2 = 0.0f;
                flag2 = false;
            }
        }
    }
}