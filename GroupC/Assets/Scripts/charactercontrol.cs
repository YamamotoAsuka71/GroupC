using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charactercontrol : MonoBehaviour
{
    [SerializeField] saigo saigo;
    public GameObject Front;
    public GameObject Leftf;
    public GameObject Right;
    public GameObject Back;
    public GameObject Medicine;
    public GameObject arrow;
    public Slider stamina;
    float timer;
    float timer2;
    float MaxStamina = 6;
    float NowStamina;
    float timer3 = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Front.gameObject.SetActive(true);
        Leftf.gameObject.SetActive(false);
        Right.gameObject.SetActive(false);
        Back.gameObject.SetActive(false);
        stamina.value = 1;
        NowStamina = MaxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        timer3 += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer3 > 2.0f)
        {
            timer2 += Time.deltaTime;
        }
        if (timer >= 3.0f)
        {
            Instantiate(Medicine, new Vector3(transform.position.x, transform.position.y, -4.0f), Quaternion.identity);
            timer = 0;
        }
        if (timer2 <= 4)
        {
            arrow.gameObject.SetActive(true);
        }
        else if (timer2 <= 9)
        {
            arrow.gameObject.SetActive(false);
        }
        else
        {
            timer2 = 1;
        }
        if (stamina.value > 0)
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                Front.gameObject.SetActive(false);
                Leftf.gameObject.SetActive(true);
                Right.gameObject.SetActive(false);
                Back.gameObject.SetActive(false);
                transform.Translate(-5f * Time.deltaTime, 0.0f, 0.0f);
                NowStamina -= Time.deltaTime;
                stamina.value = NowStamina / MaxStamina;
            }
            //キーボードのDを押すと右に動く
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                Front.gameObject.SetActive(false);
                Leftf.gameObject.SetActive(false);
                Right.gameObject.SetActive(true);
                Back.gameObject.SetActive(false);
                transform.Translate(5f * Time.deltaTime, 0.0f, 0.0f);
                NowStamina -= Time.deltaTime;
            }
            //キーボードのWを押すと上に動く
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                Front.gameObject.SetActive(false);
                Leftf.gameObject.SetActive(false);
                Right.gameObject.SetActive(false);
                Back.gameObject.SetActive(true);
                transform.Translate(0.0f, 5f * Time.deltaTime, 0.0f);
                NowStamina -= Time.deltaTime;
                stamina.value = NowStamina / MaxStamina;
            }
            //キーボードのSを押すと下に動く
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
            {
                Front.gameObject.SetActive(true);
                Leftf.gameObject.SetActive(false);
                Right.gameObject.SetActive(false);
                Back.gameObject.SetActive(false);
                transform.Translate(0.0f, -5f * Time.deltaTime, 0.0f);
                NowStamina -= Time.deltaTime;
                stamina.value = NowStamina / MaxStamina;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            if (NowStamina / MaxStamina <= 1)
            {
                NowStamina += Time.deltaTime;
            }
            stamina.value = NowStamina / MaxStamina;
        }
        //主人公の移動
        //キーボードのAを押すと左に動く
        if (Input.GetKey(KeyCode.A))
        {
            Front.gameObject.SetActive(false);
            Leftf.gameObject.SetActive(true);
            Right.gameObject.SetActive(false);
            Back.gameObject.SetActive(false);
            transform.Translate(-2.5f * Time.deltaTime, 0.0f, 0.0f);
        }
        //キーボードのDを押すと右に動く
        else if (Input.GetKey(KeyCode.D))
        {
            Front.gameObject.SetActive(false);
            Leftf.gameObject.SetActive(false);
            Right.gameObject.SetActive(true);
            Back.gameObject.SetActive(false);
            transform.Translate(2.5f * Time.deltaTime, 0.0f, 0.0f);
        }
        //キーボードのWを押すと上に動く
        else if (Input.GetKey(KeyCode.W))
        {
            Front.gameObject.SetActive(false);
            Leftf.gameObject.SetActive(false);
            Right.gameObject.SetActive(false);
            Back.gameObject.SetActive(true);
            transform.Translate(0.0f, 2.5f * Time.deltaTime, 0.0f);
        }
        //キーボードのSを押すと下に動く
        else if (Input.GetKey(KeyCode.S))
        {
            Front.gameObject.SetActive(true);
            Leftf.gameObject.SetActive(false);
            Right.gameObject.SetActive(false);
            Back.gameObject.SetActive(false);
            transform.Translate(0.0f, -2.5f * Time.deltaTime, 0.0f);
        }
        if (saigo.flag == true)
        {
            Front.SetActive(false);
            Right.SetActive(false);
            Leftf.SetActive(false);
            Back.SetActive(false);
        }
    }

}
