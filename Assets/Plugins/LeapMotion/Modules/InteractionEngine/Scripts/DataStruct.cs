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

    public bool GraspStay;
    public ObjGR[] dataGR;
    public ObjPath[] dataPath;
    public bool mirrormode;
    public bool FirstGrasp;
    public Vector3 targetPos;
    public Quaternion targetRot;
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
    
        }

        //if(dataGR[i].ObjectPos.x > dataGR[i].RobotWristPos.x)
        //{
          //  GameObject.Find("Target").transform.position = GameObject.Find("RightAproach").transform.position
        //}
        
            defineTarget(dataGR[i].RobotWristPos, dataGR[i].RobotWristRot);

  
            GraspStay = true;

    }

    public void defineTarget(Vector3 RobotWristPos, Quaternion RobotWristRot)
    {
        GameObject Target = GameObject.Find("Target");


        if (mirrormode)
        {
             Target.transform.localPosition = new Vector3(-RobotWristPos.x, RobotWristPos.y, RobotWristPos.z);
             Target.transform.localRotation = new Quaternion(-RobotWristRot.x, RobotWristRot.y, -RobotWristRot.z, RobotWristRot.w);
        }
        else
        {
            Target.transform.localPosition = new Vector3(RobotWristPos.x, RobotWristPos.y, RobotWristPos.z);
            Target.transform.localRotation = new Quaternion(RobotWristRot.x, RobotWristRot.y, RobotWristRot.z, RobotWristRot.w);
        }
    }

    public int lookfor_name_Data(string name)
    {
        int i=-1;
        bool find = false;
        while (!find)
        {   
            i++;
            if (dataGR[i].Name == name)
            {
                find = true;
            }
           
        }
        return i;
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
        mirrormode = false;
        GraspStay = false;
        FirstGrasp = false;
    }
    private void Update()
    {
        

        if (FirstGrasp && GraspStay && GameObject.Find("Cylinderobot").transform.parent != GameObject.Find("Agarre").transform)
        {
            GameObject.Find("Cylinderobot").transform.SetParent(GameObject.Find("Agarre").transform);
        }

        if (!GraspStay && GameObject.Find("Cylinderobot").transform.parent==GameObject.Find("Agarre").transform) //------------------------------------esto hay que cambiarlo para mas objetos
        { 
            GameObject.Find("Agarre").transform.DetachChildren();
            FirstGrasp=false;

        }


    }

}
