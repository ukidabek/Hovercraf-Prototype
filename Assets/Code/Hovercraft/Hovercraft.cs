using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hovercraft : MonoBehaviour
{
    [SerializeField] private BaseHovercraftControlSchema m_controlSchema = null;
    public BaseHovercraftControlSchema ControlSchema
    {
        get => m_controlSchema;
        set => m_controlSchema = value;
    }

    [SerializeField] private float m_levitationDistance = 1.5f;
    public float LevitationDistance => m_levitationDistance;
    

    [SerializeField] private PropulsionEmbitter[] m_leftPropulsionEmitter = null;
    public PropulsionEmbitter[] LeftPropulsionEmitter => m_leftPropulsionEmitter;

    
    [SerializeField] private PropulsionEmbitter[] m_rightPropulsionEmitter = null;
    public PropulsionEmbitter[] RightPropulsionEmitter => m_rightPropulsionEmitter;


    [SerializeField] private PropulsionEmbitter[] m_propulsionEmitter = null;
    public PropulsionEmbitter[] PropulsionEmitter => m_propulsionEmitter;
    
    [SerializeField] private AntiGravityEmitter[] m_antAntiGravityEmitters = null;
    public AntiGravityEmitter[] AntAntiGravityEmitters => m_antAntiGravityEmitters;

    [SerializeField] private PropulsionEmbitter[] m_leftSidePropulsionEmitter = null;
    public PropulsionEmbitter[] LeftSidePropulsionEmitter => m_leftSidePropulsionEmitter;
    
    [SerializeField] private PropulsionEmbitter[] m_rightSidePropulsionEmitter = null;
    public PropulsionEmbitter[] RightSidePropulsionEmitter => m_rightSidePropulsionEmitter;


    [SerializeField] private Rigidbody m_rigidbody = null;


    [SerializeField] private Vector3 m_input = Vector3.zero;
    public Vector3 Input
    {
        get => m_input;
        set => m_input = value;
    }

    private readonly List<BaseEmitter> m_embitters = new List<BaseEmitter>();
    
    private void Awake()
    {
        m_embitters.AddRange(m_leftPropulsionEmitter);
        m_embitters.AddRange(m_rightPropulsionEmitter);
        m_embitters.AddRange(m_propulsionEmitter);
        m_embitters.AddRange(m_antAntiGravityEmitters);
        m_embitters.AddRange(m_leftSidePropulsionEmitter);
        m_embitters.AddRange(m_rightSidePropulsionEmitter);
    }

    private void Update() => m_controlSchema?.Control(this, m_input);

    private void ApplyForces()
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

    private void FixedUpdate() => ApplyForces();

    private void Reset()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
}
