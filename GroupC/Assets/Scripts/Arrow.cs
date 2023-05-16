using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Transform arrow;
    private GameObject player;
    private GameObject goal;
    void Start()
    {

    }
    void Update()
    {
        goal = GameObject.Find("Goal(Clone)");
        Vector3 toDirection = goal.transform.position - transform.position;
        // ëŒè€ï®Ç÷âÒì]Ç∑ÇÈ
        transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
        player = GameObject.Find("Player");
        transform.position = player.transform.position;
    }
}
