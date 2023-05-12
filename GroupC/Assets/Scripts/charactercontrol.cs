using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontrol : MonoBehaviour
{
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        //��l���̈ړ�
        //�L�[�{�[�h��A�������ƍ��ɓ���
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.03f, 0.0f, 0.0f);
            renderer.flipX = true;
        }
        //�L�[�{�[�h��D�������ƉE�ɓ���
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.03f, 0.0f, 0.0f);
            renderer.flipX = false;
        }
        //�L�[�{�[�h��W�������Ə�ɓ���
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0.0f, 0.3f, 0.0f);
            renderer.flipY = true;
        }
        //�L�[�{�[�h��S�������Ɖ��ɓ���
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0.0f, -0.3f, 0.0f);
            renderer.flipY = false;
        }
    }

}
