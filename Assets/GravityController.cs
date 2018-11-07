using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] float m_accelarationOfGravity = 9.81f;
    [SerializeField] Transform m_centerOfGravity;
    Transform m_player;

    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 100f))
            {
                GameObject go = hit.collider.gameObject;
                if (go.tag == "GravitySource")
                {
                    m_centerOfGravity = go.transform;
                }
            }
        }

        Vector3 dir = m_centerOfGravity.position - m_player.position;
        Physics.gravity = dir.normalized * m_accelarationOfGravity;
        m_player.up = -1 * dir;
    }
}
