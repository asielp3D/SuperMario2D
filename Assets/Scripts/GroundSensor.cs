using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
   private PlayerControler controller;
   public bool isGrounded;
   void Awake ()
   {
    controller = GetComponentInParent<PlayerControler>();
   }
     void OnTriggerEnter2D(Collider2D other)
   {
    isGrounded = true;
   }
    void OnTriggerStay2D(Collider2D other)
   {
    isGrounded = true;
   }

    void OnTriggerExit2D(Collider2D other)
   {
    isGrounded = false;
   }
}
