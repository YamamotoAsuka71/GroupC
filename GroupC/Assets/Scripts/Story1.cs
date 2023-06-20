using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story1 : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text textbox;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        textbox.text = "衝撃";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "撃滅のセカンドブリット";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "撃滅";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
