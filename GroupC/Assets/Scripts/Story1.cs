using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story1 : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text textbox;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        textbox.text = "アンパンマン";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return null;

        textbox.text = "カレーパンマン";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return null;

        textbox.text = "食パンマン";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
