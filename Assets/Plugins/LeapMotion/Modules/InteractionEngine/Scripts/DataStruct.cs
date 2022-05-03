using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStruct : MonoBehaviour
{
    
    //----------------------------------------------------------------BASE DE DATOS-------------------------
    [System.Serializable]

    public struct ObjGR
    {
        public string Name;
        public Vector3 RobotWristPos;
        public Quaternion RobotWristRot;
        /*public Vector3[] pathPos;
        public Quaternion[] pathRot;*/
        public Vector3 GraspPoint;
        public Vector3 ObjectPos;

    }

    
    public ObjGR[] dataGR;
    public Vector3 munien;
    public void Rellena_struct(string Name, GameObject RobotWrist, Vector3 GraspPoint, Vector3 ObjectPos, ObjGR[] dataGR)
    {
        int i = -1;
        bool find = false;
        bool blank = false;
        while (!blank && !find)
        {
            i++;
            if (dataGR[i].Name == Name) //--------------------------------falta una condicion-------------------------
            {
                dataGR[i].RobotWristPos = RobotWrist.transform.position;
                dataGR[i].RobotWristRot = RobotWrist.transform.rotation * Quaternion.Euler(0, 180, 90); ;
                dataGR[i].GraspPoint = GraspPoint;
                dataGR[i].ObjectPos = ObjectPos;
                find = true;
            }
            if (dataGR[i].Name == null)
            {
                blank = true;
                dataGR[i].Name = Name;
                dataGR[i].RobotWristPos = RobotWrist.transform.position;
                dataGR[i].RobotWristRot = RobotWrist.transform.rotation * Quaternion.Euler(0, 180, 90);
                dataGR[i].GraspPoint = GraspPoint;
                dataGR[i].ObjectPos = ObjectPos;
            }
            GameObject.Find("Target").transform.localPosition = dataGR[i].RobotWristPos;
            GameObject.Find("Target").transform.localRotation = dataGR[i].RobotWristRot;
            GameObject.Find("Cylinderobot").transform.SetParent(GameObject.Find("Agarre").transform);

        }
        //GameObject.Find("Agarre").transform.DetachChildren();
    }
    public void mostrar_data(ObjGR[] dataGR)
    {
        foreach (ObjGR data in dataGR)
        {
            Debug.Log(data.Name + ": ");
            Debug.Log("Wrist position: " + data.RobotWristPos + " Wrist Rotation: " + data.RobotWristRot + " Object Position: " + data.ObjectPos + " Grasping Point: " + data.GraspPoint);


        }

    }
    // Start is called before the first frame update
    void Start()
    {
        dataGR = new ObjGR[5];
    }
}
