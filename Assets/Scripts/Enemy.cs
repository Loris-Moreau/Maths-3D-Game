using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Detection detection;

    private Transform player;

    private void Start()
    {
        player = Player.Instance.transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < 2)
        {
            //direction 
            Vector3 direction = transform.position - player.transform.position;
            direction.Normalize();

            //to see if the player and enemy are looking in the same direction
            float dotP = Vector3.Dot(direction, player.transform.forward);

            //to see if the player is behind the enemy
            float dotE = Vector3.Dot(transform.forward, direction);

            if (dotP > 0 && dotE > 0)
            {
                Player.Instance.canBackStab = true;
                Debug.Log("Stab");
            }
            else
            {
                Player.Instance.canBackStab = false;
                Debug.Log("Nope");
            }
        }
    }
}
