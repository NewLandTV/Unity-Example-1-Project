using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBorder : MonoBehaviour
{
    public GameManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player p = other.GetComponent<Player>();

            p.transform.position = manager.playerStartTransform.position;

            p.RemoveHealth();
        }
    }
}
