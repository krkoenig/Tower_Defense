using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{

    /// <summary>
    /// The cost of the placeable object.
    /// </summary>
    public uint cost = 0;

    /// <summary>
    /// Determines whether the tower has been placed or not.
    /// </summary>
    bool m_placed = false;

    // Use this for initialization
    void Start()
    {
        transform.position = MouseToWorldPoints();
    }

    // Update is called once per frame
    void Update()
    {
        // Have the object float on the mouse until it is placed.
        if (!m_placed)
        {
            transform.position = MouseToWorldPoints();

            if (Input.GetAxis("Selection") > 0.5f)
            {
                m_placed = true;
            }
        }
    }

    /// <summary>
    /// Covnerts the mouse's screen position into world coordinates.
    /// </summary>
    /// <returns>Mouse in World Coordinates</returns>
    Vector3 MouseToWorldPoints()
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        wp.z = 0;
        return wp;
    }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(gameObject);
        }
    }

    public bool IsPlaced()
    {
        return m_placed;
    }
}
