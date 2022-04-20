using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePosition : MonoBehaviour
{
    private Vector3 PosicionRelativa;
    struct GraspedObject
    {
        //Variable declaration
        //Note: I'm explicitly declaring them as public, but they are public by default. You can use private if you choose.
        public string Name;
        public Vector3[] contacts;
        //public Vector3 RobotWrist;

        //Constructor (not necessary, but helpful)
        public GraspedObject( string Name, Vector3 [] contacts) //Vector3 RobotWrist)
        {
            this.Name = Name;
            this.contacts = contacts;
            //this.RobotWrist = RobotWrist;
        }
    }
    GraspedObject[] a1;
    private void Start()
    {
       
    }
    
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
