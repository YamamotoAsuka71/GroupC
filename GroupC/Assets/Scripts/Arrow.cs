using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Transform arrow;
    private GameObject player;
    public GameObject goal;
    public GameObject playerObjct;
    Transform playerTransform;
    void Start()
    {
        playerTransform = playerObjct.transform;
    }
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, 5.0f);
        Vector3 toDirection = goal.transform.position - transform.position;
        // ëŒè€ï®Ç÷âÒì]Ç∑ÇÈ
        transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
        player = GameObject.Find("Player");
        transform.position = player.transform.position;
    }
}
