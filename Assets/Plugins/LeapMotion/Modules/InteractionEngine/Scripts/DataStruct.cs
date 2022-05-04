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
        public Vector3 GraspPoint;
        public Vector3 ObjectPos;

    }

    public struct ObjPath
    {

        public Vector3 pathPos;
        public Quaternion pathRot;
    }

    public bool FinishMovement;
    public ObjGR[] dataGR;
    public ObjPath[] dataPath;
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
    }
        public void Rellena_Path(GameObject RobotWrist, ObjPath[] dataPath)
        {
            int i = -1;
            bool blank = false;
            while (!blank)
            {
                i++;
                if (dataGR[i].Name == null)
                {
                    blank = true;
                    dataPath[i].pathPos = RobotWrist.transform.position;
                    dataPath[i].pathRot = RobotWrist.transform.rotation * Quaternion.Euler(0, 180, 90);
                }
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
        FinishMovement = false;
    }
    void Update()
    {
        if(GameObject.Find("Target").transform.position==GameObject.Find("FK Marker").transform.position)
        {
            FinishMovement = true;
        }
        else
        {
            FinishMovement = false;
        }
    }
}
