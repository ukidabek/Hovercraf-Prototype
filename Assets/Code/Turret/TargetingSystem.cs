using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    [SerializeField] private Transform m_sourceTransform = null;
    [SerializeField] private float m_distance = 0;
    [SerializeField] private PointTargeting[] m_pointTargets;
    
    private void Update()
    {
        var targetPoint = m_sourceTransform.position + (m_sourceTransform.forward * m_distance);
        foreach (var pointTarget in m_pointTargets) 
            pointTarget.TargetPoint = targetPoint;
    }
}
