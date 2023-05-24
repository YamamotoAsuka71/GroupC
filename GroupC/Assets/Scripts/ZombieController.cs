using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] Mapgeneration mapgeneration;
    public GameObject Front;
    public GameObject Beside;
    public GameObject Back;
    bool[] direction = new bool[4];
    bool flag = false;
    float timer;
    float timer2;
    // Start is called before the first frame update
    void Start()
    {
        Front.SetActive(false);
        Beside.SetActive(false);
        Back.SetActive(false);
        transform.position = new Vector3((2 * mapgeneration.Size) - (mapgeneration.Width * mapgeneration.Size) / 2, (10 * mapgeneration.Size) - (mapgeneration.Height * mapgeneration.Size) / 2, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer >= 3.0f || timer < 4.0f)
        {
            Front.SetActive(true);
        }
        if (timer >= 5.0f)
        {
            if (flag == false)
            {
                int Num = Random.Range(0, 4);
                direction[Num] = true;
                flag = true;
            }
            if (flag == true)
            {
                if (direction[0] == true)
                {
                    transform.Translate(new Vector3(0.0f, 1.0f * Time.deltaTime, 0.0f));
                }
                else if (direction[1] == true)
                {
                    transform.Translate(new Vector3(0.0f, -1.0f * Time.deltaTime, 0.0f));
                }
                else if (direction[2] == true)
                {
                    transform.Translate(new Vector3(-1.0f * Time.deltaTime, 0.0f, 0.0f));
                }
                else if (direction[3] == true)
                {
                    transform.Translate(new Vector3(1.0f * Time.deltaTime, 0.0f, 0.0f));
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        flag = false;
        for (int i = 0; i < 4; i++)
        {
            direction[i] = false;
        }
    }
}