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
        //public Vector3[] fingers;
        public Vector3 RobotWrist;

    }
    public ObjGR[] dataGR;
    public void Rellena_struct(string Name, Vector3 RobotWrist, ObjGR[] dataGR)
    {
        int i = 0;
        int h = 0;
        bool find = false;
        while (i <= dataGR.Length & find!)
        {
            if (dataGR[i].Name.Equals(Name))
            {
                dataGR[i].RobotWrist = RobotWrist;
                find = true;
            }
            i++;
        }
        if (find!)
        {
            dataGR[i].Name = Name;
            dataGR[i].RobotWrist = RobotWrist;
        }
    }


    void Update()
    {
        Vector3 WristPos = GameObject.Find("R_Palm").transform.position;
        Rellena_struct(gameObject.name, WristPos, dataGR);

        Debug.Log("Posicion de la muneca, " + WristPos);
        Debug.DrawLine(WristPos, gameObject.transform.position, Color.red);
        //----------------------------------------------------PUNTOS RESPECTO AL SISTEMA----------------------
        Vector3 Relativepos = WristPos - gameObject.transform.position;
        Debug.Log("Posicion de " + gameObject.name + ", " + Relativepos);
        Debug.Log("posiion de la muneca en el struct " + dataGR[0].RobotWrist);

    }
}