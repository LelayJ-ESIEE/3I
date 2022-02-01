using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class DebugDrawTrajectory : MonoBehaviour
{
    enum DebugType { debug, gizmos }

    [SerializeField] DebugType m_DebugType;

    [SerializeField] int m_NMaxPositions;
    [SerializeField] float m_MinDistanceBetweenTwoPositions;
    List<Vector3> m_Positions = new List<Vector3>();

    [SerializeField] Color m_Color;
    [SerializeField] Vector3 m_PosOffset;

    void Awake()
    {
        //#if !UNITY_EDITOR
        //        Destroy(this);
        //#endif
        if (Application.platform == RuntimePlatform.Android)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currPos = transform.position;

        if (m_Positions.Count == 0)
        {
            m_Positions.Add(currPos);
            return;
        }

        Vector3 latestStoredPos = m_Positions[m_Positions.Count - 1];

        if (Vector3.Distance(currPos, latestStoredPos) > m_MinDistanceBetweenTwoPositions)
        {
            m_Positions.Add(currPos);
            if (m_Positions.Count > m_NMaxPositions)
                m_Positions.RemoveAt(0);
        }

        if (m_DebugType == DebugType.debug)
        {
            for (int i = 0; i < m_Positions.Count - 1; i++)
            {
                Debug.DrawLine(m_Positions[i] + m_PosOffset, m_Positions[i + 1] + m_PosOffset, m_Color);
            }
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (m_DebugType == DebugType.gizmos)
        {
            Gizmos.color = m_Color;
            for (int i = 0; i < m_Positions.Count - 1; i++)
            {
                Gizmos.DrawLine(m_Positions[i] + m_PosOffset, m_Positions[i + 1] + m_PosOffset);

                if (i % 10 == 0)
                {
                    Gizmos.DrawSphere(m_Positions[i] + m_PosOffset, .05f);
                    m_Positions[i] = Handles.PositionHandle(m_Positions[i], Quaternion.identity);
                }
            }

        }
    }
#endif
}
