using UnityEngine;

public class AntiGravityEmitter : BaseEmitter
{
    [SerializeField] protected float m_dampingForce = 100f;
    [SerializeField] protected float m_length = 1f;
    public float Length
    {
        get => m_length;
        set => m_length = value;
    }

    [Header("Work values")]
    [SerializeField] private float m_lastDistance = 1f;
    [SerializeField] private float m_dampingForceAmount = 0;
    [SerializeField] private float m_strengthAmount;
    [SerializeField] private float m_forceAmount;
 

    protected override void Awake()
    {
        m_direction = transform.TransformDirection(m_direction.normalized);
    }

    protected override Vector3 CalculateForce()
    {
        var transform = this.transform;
        if (Physics.Raycast(transform.position, -m_direction, out var hit, m_length))
        {
            var tangentDirection = Vector3.Cross( transform.right, hit.normal).normalized;
            transform.rotation = Quaternion.LookRotation(tangentDirection);
            
            m_strengthAmount = m_length - hit.distance;
            m_dampingForceAmount = m_lastDistance - hit.distance;
            m_lastDistance = hit.distance;

            Debug.DrawLine(transform.position, hit.point, Color.red);
            Debug.DrawRay(hit.point, tangentDirection, Color.blue);
        }
        else
        {
            m_forceAmount = 0;
            m_lastDistance = m_length * 1.1f;
            m_strengthAmount = 0f;
        }
        
        m_forceAmount = m_strength * m_strengthAmount + m_dampingForce * m_dampingForceAmount;
        m_forceAmount = Mathf.Max(0f, m_forceAmount);
        return m_direction * m_forceAmount;
    }

    private void OnDrawGizmos()
    {
        var position = transform.position;
        var oppositeDirection = -m_direction;
        Gizmos.DrawRay(position, oppositeDirection);
    }
}
