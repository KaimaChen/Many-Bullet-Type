using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class Unit : MonoBehaviour
{
    public static List<Unit> m_units = new List<Unit>();

    private void Awake()
    {
        m_units.Add(this);
    }

    private void OnDestroy()
    {
        m_units.Remove(this);
    }
}