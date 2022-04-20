using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePosition : MonoBehaviour
{
    private Vector3 PosicionRelativa;
    //struct de datos de colisiones
    struct ObjGR
    {
       
        public string Name;
        public Vector3[] contacts;
        public Vector3 RobotWrist;
        public ObjGR( string Name, Vector3 [] contacts, Vector3 RobotWrist)
        {
            this.Name = Name;
            this.contacts = contacts;
            this.RobotWrist = RobotWrist;
        }
    }
    ObjGR[] a1;
    
    void OnCollisionStay(Collision collision)
    {
        GameObject.Find("R_Palm");
        a1.Add(ObjGR(collision.collider, collision.contacts,   ))
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
