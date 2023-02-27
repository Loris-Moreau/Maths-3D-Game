using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Detection detection;
    private ThirdPersonController TPC;

    public static Player Instance;

    public GameObject loseText;

    public bool canBackStab = false;

    void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }

    private void Start()
    {
        loseText.SetActive(false);
    }

    void Update()
    {
        if (detection.playerDetected)
        {
            detection.enemySpeed = 0f;
            TPC.MoveSpeed = 0f;
            loseText.SetActive(true);
        }
    }
}
