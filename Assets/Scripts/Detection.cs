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

    [Space]

    [SerializeField] private float smoothenedRotation = 0.05f;
    private Vector3 rotationalVelocity;

    [Space]

    /*[SerializeField]*/ private float detectionDistance = 4f;
    //[SerializeField] private float detectionStopDistance = 7f;

    [Space]
    
    public Transform target;
    [SerializeField] public bool playerDetected = false;
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
                Player.Instance.OnDetection(this);
            }
        }

        /*if (playerDetected)
        {
            if (Vector3.Distance(transform.position, target.position) < detectionStopDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.fixedDeltaTime);

                dir.y = 0f;

                transform.forward = Vector3.SmoothDamp(transform.forward, dir, ref rotationalVelocity, smoothenedRotation);
            }
            else playerDetected = false;
        }*/
    }
}
