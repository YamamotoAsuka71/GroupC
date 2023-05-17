using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPoints : MonoBehaviour
{
    [SerializeField] Mapgeneration mapgeneration;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1.0f)
        {
            PositionMove();
            timer = 2.0f;
        }
    }
    void PositionMove()
    {
        transform.position = new Vector3((mapgeneration.GoalPositionX * 5) - (13 * 5) / 2, (mapgeneration.GoalPositionY * 5) - (13 * 5) / 2, 0.0f);   //  ÉSÅ[ÉãÇê∂ê¨
    }
}
