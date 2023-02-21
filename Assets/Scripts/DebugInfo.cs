using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class DebugInfo : MonoBehaviour
{
    public Transform player, enemy;
    public TextMeshProUGUI debugText;

    /*void Update()
    {
        float distance = Vector3.Distance(player.position, enemy.position);

        if (distance < 2)
        {
            debugText.text = $"Player {player.transform.forward}\n" +
                $"Enemy {enemy.transform.forward}\n";

            //direction 
            Vector3 direction = enemy.transform.position - player.transform.position;
            direction.Normalize();
            debugText.text += $"Direction -> {direction}\n";

            //to see if the player and enemy are looking in the same direction
            float dot = Vector3.Dot(direction, player.transform.forward);
            debugText.text += $"Dot Product -> {dot}\n";

             //to see if the player is behind the enemy
            float dotback = Vector3.Dot(enemy.transform.forward, direction);
            debugText.text += $"Second Dot Product -> {dotback}";

            Vector3 cross = Vector3.Cross(player.transform.forward, direction);
            debugText.text += $"Cross Product -> {cross}";

            if (dot > 0 && dotback > 0)
            {
                Debug.Log("Stab");
            }
            else
            {
                Debug.Log("Nope");
            }
        }
    }*/
}
