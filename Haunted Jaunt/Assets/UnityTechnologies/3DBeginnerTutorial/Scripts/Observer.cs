using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Observer: MonoBehaviour
{
    public Transform player; //This script will check for the player character’s Transform instead of its GameObject. It will make it easier to access JohnLemon’s position and determine whether there is a clear line of sight to him. 
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            //This code creates a new Vector3 called direction.  From vector math, we know that a vector from A to B is B - A.This means that the direction from the PointOfView GameObject to JohnLemon is JohnLemon’s position minus the PointOfView GameObject’s position. 
            //You may remember that JohnLemon’s position is on the ground, between his feet.To make sure the Observer can see JohnLemon’s centre of mass, you’re pointing the direction up one unit by adding Vector3.up.Vector3.up is a shortcut for (0, 1, 0).
            
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player) //When Gargoyle's light detects JohnLemon
                {
                    gameEnding.CaughtPlayer(); //The Observer script will call the CaughtPlayer method in the GameEnding script.
                }
            }
        }
    }

}
