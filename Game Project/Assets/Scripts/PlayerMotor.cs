using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* This component moves our player.
		- If we have a focus move towards that.
		- If we don't move to the desired point.
*/



[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayerController))]
public class PlayerMotor : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;     // Reference to our NavMeshAgent

    // Joystick control of Charecter Movement
    public Joystick joystick;
    private float m_currentV = 0;
    private float m_currentH = 0;
    private readonly float m_interpolation = 10;
    private Vector3 m_currentDirection = Vector3.zero;
    [SerializeField] private float m_moveSpeed = 2;
    public Transform cam;

    // ChracterAnimator
    const float locomationAnimationSmoothTime = .1f;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<PlayerController>().onFocusChangedCallback += OnFocusChanged;

        // ChracterAnimator
        animator = GetComponentInChildren<Animator>();
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    void OnFocusChanged(Interactable newFocus)
    {
        if (newFocus != null)
        {
            agent.stoppingDistance = newFocus.radius * .8f;
            agent.updateRotation = false;

            target = newFocus.interactionTransform;
        }
        else
        {
            agent.stoppingDistance = 0f;
            agent.updateRotation = true;
            target = null;
        }
    }

    void Update()
    {
        // Joystick control of Charecter Movement
        float v = joystick.Vertical;
        float h = joystick.Horizontal;

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        Vector3 direction = cam.forward * m_currentV + cam.right * m_currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

            transform.rotation = Quaternion.LookRotation(m_currentDirection);
            transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;
        }

        // Set target to interactable objects
        if (target != null)
        {
            MoveToPoint(target.position);
            FaceTarget();
        }

        // ChracterAnimator
        animator.SetFloat("speedPercent", m_currentV);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


}