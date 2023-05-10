using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    private Vector3 follow;

    // Start is called before the first frame update
    void Start()
    {
        follow = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, player.position.y + follow.y, player.position.z + follow.z);
    }
}
