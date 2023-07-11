using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float m_mainThrust = 100f;
    [SerializeField] float m_rotationThrust = 1f;
    Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            m_rigidbody.AddRelativeForce(Vector3.up * m_mainThrust * Time.deltaTime);
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(m_rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-m_rotationThrust);
        }
    }

    private void ApplyRotation(float i_rotation)
    {
        m_rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * i_rotation * Time.deltaTime);
        m_rigidbody.freezeRotation = false;
    }
}
