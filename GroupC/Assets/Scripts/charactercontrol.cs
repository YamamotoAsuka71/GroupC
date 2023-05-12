using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontrol : MonoBehaviour
{
    public GameObject Front;
    public GameObject Leftf;
    public GameObject Right;
    public GameObject Back;

    // Start is called before the first frame update
    void Start()
    {
        Front.gameObject.SetActive(true);
        Leftf.gameObject.SetActive(false);
        Right.gameObject.SetActive(false);
        Back.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //主人公の移動
        //キーボードのAを押すと左に動く
        if (Input.GetKey(KeyCode.A))
        {
            Front.gameObject.SetActive(false);
            Leftf.gameObject.SetActive(true);
            Right.gameObject.SetActive(false);
            Back.gameObject.SetActive(false);
            transform.Translate(-5f * Time.deltaTime, 0.0f, 0.0f);
        }
        //キーボードのDを押すと右に動く
        else if (Input.GetKey(KeyCode.D))
        {
            Front.gameObject.SetActive(false);
            Leftf.gameObject.SetActive(false);
            Right.gameObject.SetActive(true);
            Back.gameObject.SetActive(false);
            transform.Translate(5f * Time.deltaTime, 0.0f, 0.0f);
        }
        //キーボードのWを押すと上に動く
        else if (Input.GetKey(KeyCode.W))
        {
            Front.gameObject.SetActive(false);
            Leftf.gameObject.SetActive(false);
            Right.gameObject.SetActive(false);
            Back.gameObject.SetActive(true);
            transform.Translate(0.0f, 5f * Time.deltaTime, 0.0f);
        }
        //キーボードのSを押すと下に動く
        else if (Input.GetKey(KeyCode.S))
        {
            Front.gameObject.SetActive(true);
            Leftf.gameObject.SetActive(false);
            Right.gameObject.SetActive(false);
            Back.gameObject.SetActive(false);
            transform.Translate(0.0f, -5f * Time.deltaTime, 0.0f);
        }
    }

}
