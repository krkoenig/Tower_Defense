using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    /// <summary>
    /// The nodes of the walker's path. Built in Start().
    /// </summary>
    public Transform[] m_path;

    /// <summary>
    /// The walker's current node.
    /// </summary>
    int m_currentNode = 0;

    public float moveSpeed;
    public float rotateSpeed;

    /// <summary>
    /// Determines which path the walker uses based on tags.
    /// </summary>
    public string pathTag = "LandPath";

    // Use this for initialization
    void Start()
    {    
        // Build the walkers path.
        m_path = GameObject.FindGameObjectWithTag(pathTag).GetComponent<Path>().waypoints;

    }

    // Update is called once per frame
    void Update()
    {
        // If the walker has finished the path...
        if (m_currentNode >= m_path.Length)
        {
            // TODO: Do enemy killing player logic
            Destroy(gameObject);
        }
        else
        {
            RotateToFace();
            Move();
            HasReachedPoint();
        }

    }

    /// <summary>
    /// Checks when the walker has reached their destination.
    /// </summary>
    bool HasReachedPoint()
    {
        if (transform.position == m_path[m_currentNode].position)
        {
            m_currentNode++;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Causes the walker to step towards the next node.
    /// </summary>
    void Move()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, m_path[m_currentNode].position, step);
    }

    /// <summary>
    /// Rotates the walker to face the next node.
    /// </summary>
    void RotateToFace()
    {
        // Rotate to face point
        Vector3 vectorToTarget = m_path[m_currentNode].position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotateSpeed);
    }
}
