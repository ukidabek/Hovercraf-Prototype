using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector2 m_rotation = Vector2.zero;
    [SerializeField] private Vector2 m_rotationSpeed = Vector2.zero;
    [SerializeField] private Vector2 m_input = Vector2.zero;
    public Vector2 Input
    {
        get => m_input;
        set => m_input = value;
    }

    private void Update()
    {
        m_rotation.x += m_rotationSpeed.x * -m_input.y * Time.deltaTime;
        m_rotation.y += m_rotationSpeed.y * m_input.x * Time.deltaTime;

        var rotation = Quaternion.Euler(m_rotation);
        transform.rotation = rotation;
    }
}