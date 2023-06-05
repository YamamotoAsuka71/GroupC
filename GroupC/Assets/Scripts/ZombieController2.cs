using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieController2 : MonoBehaviour
{
    [SerializeField] Life life;
    [SerializeField] Mapgeneration mapgeneration;
    public GameObject Front;
    public GameObject Left;
    public GameObject Right;
    public GameObject Back;
    public GameObject Player;
    bool[] direction = new bool[4];
    float timer = 0.0f;
    float timer2 = 0.0f;
    bool flag = false;
    bool flag2 = false;
    // Start is called before the first frame update
    void Start()
    {
        Front.SetActive(false);
        Left.SetActive(true);
        Right.SetActive(false);
        Back.SetActive(false);
        transform.position = new Vector3((10 * mapgeneration.Size) - (mapgeneration.Width * mapgeneration.Size) / 2, (2 * mapgeneration.Size) - (mapgeneration.Height * mapgeneration.Size) / 2, -4.0f);
        direction[2] = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer2 += Time.deltaTime;
        if (timer2 >= 3.0f)
        {
            flag2 = true;
        }
        Debug.Log(life.Count);
        if (life.Count == 0)
        {
            SceneManager.LoadScene("New Scene");
        }
        if (Mathf.Abs(Mathf.Sqrt((transform.position.x + 3.0f) - (transform.position.x) + (transform.position.y + 3.0f) - (transform.position.y))) >= Mathf.Abs(Mathf.Sqrt((Player.transform.position.x) - (transform.position.x) + (Player.transform.position.y) - (transform.position.y))))
        {
            if (flag2 == true)
            {
                flag = true;
                float Length = Mathf.Sqrt((Player.transform.position.x) - (transform.position.x) + (Player.transform.position.y) - (transform.position.y));
                float X = ((Player.transform.position.x) - (transform.position.x)) - Length;
                float Y = ((Player.transform.position.y) - (transform.position.y)) - Length;
                float Speed = Time.deltaTime;
                X *= Speed;
                Y *= Speed;
                Vector3 pos = transform.position;
                transform.position = new Vector3(pos.x += X, pos.y += Y, -4.0f);
                if(Mathf.Abs(Mathf.Sqrt((transform.position.x + 1.0f) - (transform.position.x) + (transform.position.y + 1.0f) - (transform.position.y))) >= Mathf.Abs(Mathf.Sqrt((Player.transform.position.x) - (transform.position.x) + (Player.transform.position.y) - (transform.position.y))))
                {
                    if (timer >= 1.0f)
                    {
                        life.Count--;
                    }
                }
                if (flag == true)
                {
                    timer = 0.0f;
                }
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (direction[0] == true)
            {
                Back.SetActive(true);
                if (transform.position.y < (10 * mapgeneration.Size) - (mapgeneration.Height * mapgeneration.Size) / 2)
                {
                    transform.Translate(0.0f, 4.0f * Time.deltaTime, -4.0f);
                }
                else
                {
                    direction[3] = true;
                    Back.SetActive(false);
                    direction[0] = false;
                }
            }
            else if (direction[2] == true)
            {
                Left.SetActive(true);
                if (transform.position.x > (2 * mapgeneration.Size) - (mapgeneration.Height * mapgeneration.Size) / 2)
                {
                    transform.Translate(-4.0f * Time.deltaTime, 0.0f, -4.0f);
                }
                else
                {
                    direction[1] = true;
                    Left.SetActive(false);
                    direction[2] = false;
                }
            }
            else if (direction[1] == true)
            {
                Front.SetActive(true);
                if (transform.position.y > (2 * mapgeneration.Size) - (mapgeneration.Height * mapgeneration.Size) / 2)
                {
                    transform.Translate(0.0f, -4.0f * Time.deltaTime, -4.0f);
                }
                else
                {
                    direction[3] = true;
                    Front.SetActive(false);
                    direction[1] = false;
                }
            }
            else if (direction[3] == true)
            {
                Right.SetActive(true);
                if (transform.position.x < (10 * mapgeneration.Size) - (mapgeneration.Height * mapgeneration.Size) / 2)
                {
                    transform.Translate(4.0f * Time.deltaTime, 0.0f, -4.0f);
                }
                else
                {
                    direction[2] = true;
                    Right.SetActive(false);
                    direction[3] = false;
                }
            }
        }
    }
}