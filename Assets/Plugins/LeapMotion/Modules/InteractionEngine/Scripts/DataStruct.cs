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
        public Vector3 ObjectPos;
        public List<Vector3> pathPos;
        public List<Quaternion> pathRot;

    }

    public bool GraspStay;
    public ObjGR[] dataGR;
    public bool mirrormode;
    public bool patientmode;
    public bool FirstGrasp;
    public bool start;
    public GameObject ballPrefab;
    public int movementPos;
    public bool resetMovementPos;
    GameObject FK_Marker;
    GameObject Target;

public void Rellena_struct(string Name, GameObject RobotWrist, Vector3 ObjectPos, ObjGR[] dataGR)
    {
        int i = -1;

        bool find = false;
        bool blank = false;
        while (!blank && !find)
        {
            i++;
            if (dataGR[i].Name == Name) //--------------------------------falta una condicion-------------------------
            {
                find = true;
                dataGR[i].RobotWristPos = RobotWrist.transform.position;
                dataGR[i].RobotWristRot = RobotWrist.transform.rotation;
                dataGR[i].ObjectPos = ObjectPos;
                dataGR[i].pathPos.Clear();
                dataGR[i].pathPos.Add(RobotWrist.transform.position);
                dataGR[i].pathRot.Clear();
                dataGR[i].pathRot.Add(RobotWrist.transform.rotation);
                movementPos = 0;

            }
            if (dataGR[i].Name == null)
            {
                blank = true;
                dataGR[i].Name = Name;
                dataGR[i].RobotWristPos = RobotWrist.transform.position;
                dataGR[i].RobotWristRot = RobotWrist.transform.rotation;
                dataGR[i].ObjectPos = ObjectPos;

                //iniciamos las listas
                dataGR[i].pathPos = new List<Vector3>();
                dataGR[i].pathPos.Add(RobotWrist.transform.position);

                dataGR[i].pathRot = new List<Quaternion>();
                dataGR[i].pathRot.Add(RobotWrist.transform.rotation);
            }
        }

        if (!patientmode)
        {
            defineTarget(dataGR[i].RobotWristPos, dataGR[i].RobotWristRot);
        }
        GraspStay = true;
    }

    public void Rellena_path(int i, GameObject RobotWrist, ObjGR[] dataGR)
    {
        dataGR[i].pathPos.Add(RobotWrist.transform.position);
        dataGR[i].pathRot.Add(RobotWrist.transform.rotation);
        Instantiate(ballPrefab, RobotWrist.transform.position, Quaternion.identity);
    }

    public void defineTarget(Vector3 RobotWristPos, Quaternion RobotWristRot)
    {
        Quaternion RobotWristRotMirror = GameObject.Find("TargetHandWristMirror").transform.rotation;
        if (mirrormode)
        {
            Target.transform.localPosition = new Vector3(RobotWristPos.x, RobotWristPos.y, RobotWristPos.z);
            Target.transform.localRotation = RobotWristRotMirror;
        }
        else
        {
            Target.transform.localPosition = new Vector3(RobotWristPos.x, RobotWristPos.y, RobotWristPos.z);
            Target.transform.localRotation = new Quaternion(RobotWristRot.x, RobotWristRot.y, RobotWristRot.z, RobotWristRot.w);
        }
    }

    public int lookfor_name_Data(string name)
    {
        int i = -1;
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
    public void mostrar_data(ObjGR[] dataGR)
    {
        foreach (ObjGR data in dataGR)
        {
            Debug.Log(data.Name + ": ");
            Debug.Log("Wrist position: " + data.RobotWristPos + " Wrist Rotation: " + data.RobotWristRot + " Object Position: " + data.ObjectPos );
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        dataGR = new ObjGR[5];

        mirrormode = false;
        GraspStay = false;
        FirstGrasp = false;
        patientmode = false;
        start = false;
        movementPos = 0;
        FK_Marker = GameObject.Find("FK Marker");
        Target = GameObject.Find("Target");
    }
    private void Update()
    {
        if(start)
        {

        }
        if (!patientmode)
        {
            //PARA EL PRIMER AGARRE
            if (FirstGrasp && GraspStay && GameObject.Find("Cylinderobot").transform.parent != GameObject.Find("Agarre").transform)
            {
                GameObject.Find("Cylinderobot").transform.SetParent(GameObject.Find("Agarre").transform);
            }
            if (!GraspStay && GameObject.Find("Cylinderobot").transform.parent == GameObject.Find("Agarre").transform) //------------------------------------esto hay que cambiarlo para mas objetos Hace falta un string que sea el objeto que hay selectionado
            {
                GameObject.Find("Agarre").transform.DetachChildren();
                FirstGrasp = false;

            }
            //PARA COMPLETAR EL PATH


        }
        else if(start && FK_Marker.transform.position == Target.transform.position)
        {
            if (movementPos == 1)
            {
                
                GameObject.Find("Cylinderobot").transform.SetParent(GameObject.Find("Agarre").transform);
                defineTarget(dataGR[0].pathPos[movementPos], dataGR[0].pathRot[movementPos]);
                movementPos++;
            }
            else
            {
                defineTarget(dataGR[0].pathPos[movementPos], dataGR[0].pathRot[movementPos]); //HAY QUE SABER CON QUE OBJETO ESTAMOS
                movementPos++;
            }

        }



    }

}
