using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraspBegin : MonoBehaviour
{
  
       private Vector3 PosicionRelativa;
    //struct de datos de colisiones
    public struct ObjGR
    {
        public string Name;
        public Vector3[] fingers;
        public Vector3 RobotWrist;

    }
    public ObjGR[] dataGR;
    public void Rellena_struct(string Name, GameObject[] fingers, Vector3 RobotWrist, ObjGR[] dataGR)
    {
        int i = 0;
        int h = 0;
        bool find = false;
        while (i <= dataGR.Length & find!)
        {
            if (dataGR[i].Name.Equals(Name))
            {
                foreach (GameObject finger in fingers)
                {
                    dataGR[i].fingers[h] = finger.transform.position;
                }
                dataGR[i].RobotWrist = RobotWrist;
                find = true;
            }
            i++;
        }
        if (find!)
        {
            dataGR[i].Name = Name;
            foreach (GameObject finger in fingers)
            {
                dataGR[i].fingers[h] = finger.transform.position;
            }
            dataGR[i].RobotWrist = RobotWrist;
        }
    }

    
     void Start()
    {
        GameObject[] fingerPos= GameObject.FindGameObjectsWithTag("RHand");
        Vector3 WristPos = GameObject.Find("R_Palm").transform.position;
        Rellena_struct(gameObject.name, fingerPos, WristPos, dataGR);

        foreach (GameObject finger in fingerPos)
        {
            Debug.Log("Posicion de " + finger.name + ", " + finger.transform.position);
            Debug.DrawLine(finger.transform.position, gameObject.transform.position, Color.red);
            //----------------------------------------------------PUNTOS RESPECTO AL SISTEMA----------------------
            Vector3 Relativepos = finger.transform.position - gameObject.transform.position;
            Debug.Log("Posicion de " + gameObject.name + ", " + Relativepos);
            Debug.Log("posiion de la muneca en el struct "+ dataGR[0].RobotWrist);
        }
        
    }
}