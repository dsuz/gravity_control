using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_moveAccelaration = 1.0f;
    Rigidbody m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float v = CrossPlatformInputManager.GetAxisRaw("Vertical");
        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        if (v != 0)
        {
            m_rb.AddForce(v * transform.forward * m_moveAccelaration, ForceMode.Force);
        }
        if (h != 0)
        {
            m_rb.AddForce(h * transform.right * m_moveAccelaration, ForceMode.Force);
        }
    }
}
