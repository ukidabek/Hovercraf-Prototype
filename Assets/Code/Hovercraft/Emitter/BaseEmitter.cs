using UnityEngine;

public abstract class BaseEmitter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] protected float m_strength = 5;
    [SerializeField] protected Vector3 m_direction = Vector3.up;
    public Vector3 Direction
    {
        get => m_direction;
        set => m_direction = value;
    }
    
    [SerializeField] private Vector3 m_outputForce = Vector3.zero;
    public Vector3 OutputForce => m_outputForce = CalculateForce();

    protected virtual void Awake()
    {
    }

    protected abstract Vector3 CalculateForce();
}