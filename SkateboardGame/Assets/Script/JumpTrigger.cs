using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            player.JumpTrigger();
            gameObject.SetActive(false);
        }
    }
}
