using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story1 : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text textbox;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        textbox.text = "�Ռ�";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "���ł̃Z�J���h�u���b�g";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "����";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
