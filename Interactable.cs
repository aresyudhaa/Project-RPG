using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;


    bool isFocus = false;
    Transform player;

    bool hasInteracterd = false;

    public virtual void Interact ()
    {
        //Will be Overwritten
        UnityEngine.Debug.Log ("Interacting with "+transform.name);

    }

    void Update ()
    {
        if (isFocus && !hasInteracterd)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracterd = true;
            }
        }
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracterd = false;
    }

    public void OnDefocused ()
    {
        isFocus = false;
        player = null;
        hasInteracterd = false;
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
