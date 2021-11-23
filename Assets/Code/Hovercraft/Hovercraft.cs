using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hovercraft : MonoBehaviour
{
    [SerializeField] private float m_levitationDistance = 1.5f;
    [SerializeField] private PropulsionEmbitter[] m_leftPropulsionEmitter = null;
    [SerializeField] private PropulsionEmbitter[] m_rightPropulsionEmitter = null;
    [SerializeField] private PropulsionEmbitter[] m_propulsionEmitter = null;
    [SerializeField] private AntiGravityEmitter[] m_antAntiGravityEmitters = null;
    [SerializeField] private Rigidbody m_rigidbody = null;
    
    [SerializeField] private Vector3 m_input = Vector3.zero;
    public Vector3 Input
    {
        get => m_input;
        set => m_input = value;
    }

    private List<BaseEmitter> m_embitters = new List<BaseEmitter>();
    
    private void Awake()
    {
        m_embitters.AddRange(m_leftPropulsionEmitter);
        m_embitters.AddRange(m_rightPropulsionEmitter);
        m_embitters.AddRange(m_propulsionEmitter);
        m_embitters.AddRange(m_antAntiGravityEmitters);
    }

    private void Update()
    {
        UpdateEmitters(m_leftPropulsionEmitter, Mathf.Clamp(m_input.x,0, 1), transform.right);
        UpdateEmitters(m_rightPropulsionEmitter, Mathf.Clamp(m_input.x,-1, 0), transform.right);
        UpdateEmitters(m_propulsionEmitter, m_input.z, transform.forward);
        UpdateAntiGravityEmitters();
    }

    private void UpdateEmitters(IEnumerable<PropulsionEmbitter> embitters, float input, Vector3 direction)
    {
        foreach (var VARIABLE in embitters)
        {
            VARIABLE.Output = input;
            VARIABLE.Direction = direction;
        }
    }

    private void UpdateAntiGravityEmitters()
    {
        var gravityDirection = transform.up;
        var emitterLength = m_levitationDistance + 0.5f;
        foreach (var emitter in m_antAntiGravityEmitters)
        {
            emitter.Length = emitterLength;
            emitter.Direction = gravityDirection;
        }
    }

    private void FixedUpdate()
    {
        var rigidbody = m_rigidbody;
        var transform = this.transform;
        
        foreach (var emitter in m_embitters)
        {
            var position = emitter.transform.localPosition;
            position = transform.TransformPoint(position);
            rigidbody.AddForceAtPosition(emitter.OutputForce, position);
        }    
    }

    private void Reset()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
}
