using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWorthSomeScore : MonoBehaviour,IScore
{
    [SerializeField] int m_Score;
    public int Score { get { return m_Score; } }
}
