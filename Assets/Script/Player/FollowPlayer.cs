using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;

    public float minSpeed = 1;
    public float averageSpeed = 15;
    public float maxSpeed = 20;

    private float initialHeight;

    // Start is called before the first frame update
    void Start()
    {
        initialHeight = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Mathf.Abs(target.position.x - transform.position.x);
        float newSpeed;

        float percent = (distance / 2);

        newSpeed = (averageSpeed * percent) + (minSpeed * percent);

        if (distance > 2)
        {
            newSpeed = maxSpeed;
        }

        Vector2 newPos = new Vector2(target.position.x, transform.position.y + percent);

        transform.position = Vector2.MoveTowards(transform.position, newPos, newSpeed * Time.deltaTime);

        transform.localPosition = new Vector2(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y,initialHeight,initialHeight + percent));
    }
}
