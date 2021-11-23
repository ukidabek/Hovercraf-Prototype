using System;
using UnityEngine;
using UnityEngine.Events;

public class MouseInput : MonoBehaviour
{
    [Serializable]
    public class OnMouseInput : UnityEvent<Vector2>
    {
    }
    
    public OnMouseInput OnMouseInputCallback = new OnMouseInput();
    
    [SerializeField] private Vector2 m_input = Vector2.zero;
    
    private void Update()
    {
        m_input.x = Input.GetAxis("Mouse X");
        m_input.y = Input.GetAxis("Mouse Y");
        
        OnMouseInputCallback.Invoke(m_input);
    }
}
