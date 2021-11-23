using UnityEngine;

public class PropulsionEmbitter : BaseEmitter
{
    [SerializeField, Range(-2f,2f)] private float m_output = 1f;
    public float Output
    {
        get => m_output;
        set => m_output = value;
    }

    protected override Vector3 CalculateForce()
    {
        return m_direction * m_strength * m_output;
    }
}