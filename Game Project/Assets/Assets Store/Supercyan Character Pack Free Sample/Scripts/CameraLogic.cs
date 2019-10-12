using UnityEngine;
using System.Collections.Generic;

public class CameraLogic : MonoBehaviour {

    private Transform m_currentTarget;
    private float m_distance = 5f;
    private float m_height = 2;
    private float m_lookAtAroundAngle = 0;

    [SerializeField] private Transform target;
    private int m_currentIndex;

	private void Start () {
        m_currentTarget = target;
	}

    private void Update () {
    }

    private void LateUpdate()
    {
        if(m_currentTarget == null) { return; }

        float targetHeight = m_currentTarget.position.y + m_height;
        float currentRotationAngle = m_lookAtAroundAngle;

        Quaternion currentRotation = Quaternion.Euler(currentRotationAngle, currentRotationAngle, 0);

        Vector3 position = m_currentTarget.position;
        position -= currentRotation * Vector3.forward * m_distance;
        position.y = targetHeight;

        transform.position = position;
        transform.LookAt(m_currentTarget.position + new Vector3(0, m_height, 0));
    }
}
