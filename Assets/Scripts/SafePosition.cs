using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePosition : MonoBehaviour
{
    private Vector3 PosicionRelativa;
    //struct de datos de colisiones
    public struct ObjGR
    {
        public string Name;
        public List<Vector3> fingers;
        public Vector3 RobotWrist;

    }
    public ObjGR[] dataGR;
    public ObjGR[] Rellena_struct(string Name, List<Vector3> fingers, Vector3 RobotWrist, List<ObjGR> dataGR)
    {
        bool find = false;
        int i = 0;

        while(find! or i<=dataGR.LastIndexOf)
            {
            if()
        }
        if (dataGR.Name.Contains(Name))
            a1.Name.Add(Name);
        foreach (Vector3 finger in fingers)
        {
            _
            }
        this.RobotWrist = RobotWrist;
        return dataGR;
    }
    void OnCollisionStay(Collision collision)
    {
        GameObject.Find("R_Palm");
        new a1(ObjGR(collision.collider, collision.contacts,   ))
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
