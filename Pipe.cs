using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<BatControl>() != null)
        {
            GameControl.instance.BirdScored();
        }
    }
}
