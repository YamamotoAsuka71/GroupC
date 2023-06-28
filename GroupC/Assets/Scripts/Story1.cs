using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story1 : MonoBehaviour
{
    

    public string[] scenarios=new string[4];
    public Text uiText;

    public int currentLine = 0;



    // Start is called before the first frame update
    void Start()
    {
        TextUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLine < scenarios.Length && Input.GetKeyDown(KeyCode.Return))
        {
            TextUpdate();
        }
    }

    void TextUpdate()
    {
        uiText.text = scenarios[currentLine];
     
        currentLine++;
    }
}
