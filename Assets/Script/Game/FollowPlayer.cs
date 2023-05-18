using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public static FollowPlayer instance;

    public Transform SnakeTailPrefab;
    public float size;

    public List<Transform> snackTail = new List<Transform>();
    public List<Vector2> positions = new List<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        
        positions.Add(transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = ((Vector2)transform.position - positions[0]).magnitude;

        if (distance > size)
        {
            Vector2 direction = ((Vector2)transform.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * size);
            positions.RemoveAt(positions.Count - 1);

            distance -= size;
        }

        for (int i = 0; i < snackTail.Count; i++)
        {
            snackTail[i].position = Vector2.Lerp(positions[i + 1], positions[i], distance / size);
        }
    }

    public void AddTail()
    {
        

            Transform tail = Instantiate(SnakeTailPrefab, positions[positions.Count - 1], Quaternion.identity, transform);
            snackTail.Add(tail);
            positions.Add(tail.position);
        

    }

    public void Delete()
    {

        

        snackTail.RemoveAt(snackTail.Count-1);
        positions.RemoveAt(positions.Count-1);
      

    }


}
