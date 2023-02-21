using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public bool canBackStab = false;

    void Start()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }

    void Update()
    {
        
    }
}
