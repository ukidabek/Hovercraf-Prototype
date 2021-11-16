using System;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public float Gravity { get; set; }
    
    [SerializeField] private Vector3 m_direction = Vector3.up;
    
    [SerializeField] private Vector3 m_force = Vector3.zero;
    public Vector3 Force => m_force = m_direction * Gravity * m_power;

    [SerializeField] private float m_maxOverload = 1f;
    public float MaxOverload => m_maxOverload;

    [SerializeField] private float m_power = 0.25f;
    public float Power
    {
        get => m_power;
        set => m_power = Mathf.Clamp(value, 0, m_maxOverload);
    }

    private void Awake()
    {
        m_direction = transform.TransformDirection(m_direction.normalized);
    }

    private void FixedUpdate()
    {
        var transform = this.transform;
        if (Physics.Raycast(transform.position, -transform.up, out var hit))
        {
            var tangentDirection = Vector3.Cross(hit.normal, transform.forward);
            transform.rotation = Quaternion.LookRotation(tangentDirection);
            
            
            
            Debug.DrawLine(transform.position, hit.point, Color.red);
            Debug.DrawRay(hit.point, tangentDirection, Color.blue);
        }
    }

    private void OnDrawGizmos()
    {
        var position = transform.position;
        var oppositeDirection = -m_direction;
        Gizmos.DrawRay(position, oppositeDirection);
    }
}
