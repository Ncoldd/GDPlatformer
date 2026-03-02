using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float patrolDistance = 1f;

    private Vector3 startPosition;
    private int direction = 1; // 1 = right, -1 = left

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move in current direction        
        transform.position += new Vector3(moveSpeed * direction * Time.deltaTime, 0f, 0f);

        // Check if moved too far from start
        float distanceFromStart = Vector3.Distance(startPosition, transform.position);

        if (distanceFromStart > patrolDistance)
        {
            direction *= -1; // Reverse direction
        }
    }
}
