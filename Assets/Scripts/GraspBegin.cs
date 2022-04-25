using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraspBegin : MonoBehaviour
{
    public GameObject[] ObjectsGrasped;
    private void Start()
    {
       ObjectsGrasped = GameObject.FindGameObjectsWithTag("RHand");
        foreach(GameObject ObjectGrasped in ObjectsGrasped)
        {
            Debug.Log("Posicion de " + gameObject.name + ", " + ObjectGrasped.transform.position);
            Debug.DrawLine(ObjectGrasped.transform.position, ObjectGrasped.transform.position, Color.red);
            //----------------------------------------------------PUNTOS RESPECTO AL SISTEMA----------------------
            Vector3 Relativepos = ObjectGrasped.transform.position - gameObject.transform.position;
            Debug.Log("Posicion de " + gameObject.name + ", " + Relativepos);
        }   
    }
}
