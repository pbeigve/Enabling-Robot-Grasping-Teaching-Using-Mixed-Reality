/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePosition : MonoBehaviour
{
   
    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        { 
            //printea la posicion del objeto respecto a su referencia
             PosicionRelativa = contact.point - contact.otherCollider.transform.position;
             Debug.Log(contact.thisCollider.name + " hit " + contact.otherCollider.name + "in (" + PosicionRelativa + ")");
            // Visualize the contact point
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }
}
*/