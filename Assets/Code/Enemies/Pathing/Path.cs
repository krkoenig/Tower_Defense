using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Path : MonoBehaviour
{

    /// <summary>
    /// The list of positions along this path. Uses GameObjects so
    /// they can be moved in editor.
    /// </summary>
    public Transform[] waypoints;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Used for visual help in the editor. Labels them with numbers
    /// to show the walker's order.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        uint counter = 1;
        foreach(Transform p in waypoints)
        {
            Gizmos.DrawSphere(p.position, 0.1f);
            UnityEditor.Handles.Label(p.position, counter.ToString());
            counter++;
        }
    }
}

[CustomEditor(typeof(Path))]
public class PathingEditor : Editor
{

    /// <summary>
    /// The path component used by this custom editor.
    /// </summary>
    Path m_path;

    void OnEnable()
    {
        m_path = (Path)target;
    }

    /// <summary>
    /// Adds a button to create a point for the level's pathing.
    /// </summary>
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Assign all child objects"))
        {
            m_path.waypoints = new Transform[m_path.transform.childCount];
            int n = 0;
            foreach (Transform child in m_path.transform)
            {
                m_path.waypoints[n++] = child;
            }
        }
    }
}
