using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Detection detection;
    Enemy enemy;
    ThirdPersonController TPC;

    public static Player Instance;

    public GameObject loseText;
    public GameObject winText;

    public bool canBackStab = false;

    void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }

    private void Start()
    {
        TPC = GetComponent<ThirdPersonController>();

        /*loseText.SetActive(false);
        winText.SetActive(false);*/
    }

    void Update()
    {
        if (detection && detection.playerDetected)
        {
            detection.enemySpeed = 0f;
            TPC.MoveSpeed = 0f;
            loseText.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("winZone"))
        {
            TPC.MoveSpeed = 0f;
            winText.SetActive(true);
        }
    }

    public void OnDetection(Detection detector)
    {
        detection = detector;
    }

    public void attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (canBackStab)
            {
                enemy.die();
            }
        }
    }
}
