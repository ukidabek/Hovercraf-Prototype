using UnityEngine;

public class PointTargeting : MonoBehaviour
{
    [SerializeField] private Vector3 m_targetPoint = Vector3.zero;
    public Vector3 TargetPoint
    {
        get => m_targetPoint;
        set => m_targetPoint = value;
    }

    private void Update()
    {
        transform.LookAt(m_targetPoint);
    }
}
