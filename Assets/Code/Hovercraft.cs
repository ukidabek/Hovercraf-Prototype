using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hovercraft : MonoBehaviour
{
    [SerializeField] private float m_gravity = 9.81f;
    [SerializeField] private Emitter[] m_emitters = null;
    [SerializeField] private Rigidbody m_rigidbody = null;
    [SerializeField] private Transform m_groundDetector = null;
    private Ray m_ray = new Ray();
    
    private void Awake()
    {
        foreach (var emitter in m_emitters) 
            emitter.Gravity = m_gravity;
    }
    
    private void FixedUpdate()
    {
        var rigidbody = m_rigidbody;
        var transform = this.transform;
        var mass = m_rigidbody.mass;
        var groundDetector = m_groundDetector;

        m_ray.origin = groundDetector.position;
        m_ray.direction = -groundDetector.up;
        if (Physics.Raycast(m_ray, out var hit))
        {
            Debug.DrawLine(m_ray.origin, hit.point, Color.red);
        }
        
        foreach (var emitter in m_emitters)
        {
            var position = emitter.transform.localPosition;
            position = transform.TransformPoint(position);
            rigidbody.AddForceAtPosition(emitter.Force * mass, position);
        }    
    }

    private void Reset()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
}
