using System.Net;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;
using UnityEngine.Windows;

public class Detection : MonoBehaviour
{
    #region Detection settings
    [Header("Detection Settings \n")]
    [Space]

    [SerializeField] private Rigidbody enemyRb;
    [SerializeField] public float enemySpeed = 1f;

    [SerializeField] private float smoothenedRotation = 0.05f;

    [SerializeField] private float detectionDistance = 3f;
    [SerializeField] private float detectionStopDistance = 5f;

    private Vector3 rotationalVelocity;

    public bool playerDetected = false;
    public Transform target;
    #endregion

    #region Wall Detection
    [Space]
    [Header("Collision Settings \n")]
    [Space]

    [SerializeField] private Transform enemyHeadPos;

    [Space]

    [SerializeField] private bool doCollisionTest = true;
    [SerializeField] private float collisionSphereSize = 0.1f;
    [SerializeField] private LayerMask collisionLayerMask = ~0;

    private RaycastHit hit;
    #endregion

    private void Start()
    {
        target = Player.Instance.transform;
    }

    private void FixedUpdate()
    {
        Vector3 dir = target.position - transform.position;
        dir.Normalize();

        float dot = Vector3.Dot(dir, transform.forward);

        if (!playerDetected)
        {
            if (dot > 0.8f && Vector3.Distance(transform.position, target.position) < detectionDistance)
            {
                playerDetected = true;
            }
        }

        if (playerDetected)
        {
            //CheckCollisions();

            if (Vector3.Distance(transform.position, target.position) < detectionStopDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.fixedDeltaTime);

                dir.y = 0f;

                transform.forward = Vector3.SmoothDamp(transform.forward, dir, ref rotationalVelocity, smoothenedRotation);
            }
            else playerDetected = false;
        }
    }

    private void CheckCollisions()
    {
        if (doCollisionTest)
        {
            Vector3 dir = target.position - enemyHeadPos.position;
            Physics.SphereCast(enemyHeadPos.position, collisionSphereSize, dir, out hit, detectionStopDistance, collisionLayerMask);

            if (hit.transform.gameObject.layer != LayerMask.NameToLayer("Player"))
            {
                playerDetected = false;
            }
        }
    }
}
