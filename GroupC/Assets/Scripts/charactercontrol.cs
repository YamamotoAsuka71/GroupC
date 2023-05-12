using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontrol : MonoBehaviour
{
    private new SpriteRenderer renderer;
    public GameObject Front;
    public GameObject Leftf;
    public GameObject Right;
    public GameObject Back;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        Front.gameObject.SetActive(true);
        Leftf.gameObject.SetActive(false);
        Right.gameObject.SetActive(false);
        Back.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        //��l���̈ړ�
        //�L�[�{�[�h��A�������ƍ��ɓ���
        if (Input.GetKey(KeyCode.A))
        {
            Front.gameObject.SetActive(false);
            Leftf.gameObject.SetActive(true);
            Right.gameObject.SetActive(false);
            Back.gameObject.SetActive(false);
            transform.Translate(-0.03f, 0.0f, 0.0f);
            renderer.flipX = true;
        }
        //�L�[�{�[�h��D�������ƉE�ɓ���
        else if (Input.GetKey(KeyCode.D))
        {
            Front.gameObject.SetActive(false);
            Leftf.gameObject.SetActive(false);
            Right.gameObject.SetActive(true);
            Back.gameObject.SetActive(false);
            transform.Translate(0.03f, 0.0f, 0.0f);
            renderer.flipX = false;
        }
        //�L�[�{�[�h��W�������Ə�ɓ���
        else if (Input.GetKey(KeyCode.W))
        {
            Front.gameObject.SetActive(false);
            Leftf.gameObject.SetActive(false);
            Right.gameObject.SetActive(false);
            Back.gameObject.SetActive(true);
            transform.Translate(0.0f, 0.3f, 0.0f);
            renderer.flipY = true;
        }
        //�L�[�{�[�h��S�������Ɖ��ɓ���
        else if (Input.GetKey(KeyCode.S))
        {
            Front.gameObject.SetActive(true);
            Leftf.gameObject.SetActive(false);
            Right.gameObject.SetActive(false);
            Back.gameObject.SetActive(false);
            transform.Translate(0.0f, -0.3f, 0.0f);
            renderer.flipY = false;
        }
    }

}
