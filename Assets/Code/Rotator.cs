using System;
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
    [SerializeField] private Vector2 m_xRotationRange = new Vector2(-180, 180);

    private void Awake()
    {
        var eulerAngles = transform.rotation.eulerAngles;
        m_rotation.x = eulerAngles.x;
        m_rotation.y = eulerAngles.y;
    }

    private void Update()
    {
        m_rotation.x += m_rotationSpeed.x * -m_input.y * Time.deltaTime;
        m_rotation.x = Mathf.Clamp(m_rotation.x, m_xRotationRange.x, m_xRotationRange.y);
        m_rotation.y += m_rotationSpeed.y * m_input.x * Time.deltaTime;

        transform.rotation = Quaternion.Euler(m_rotation);
    }
}