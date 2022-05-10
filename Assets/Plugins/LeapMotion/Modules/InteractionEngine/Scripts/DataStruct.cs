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


    public void MirrorTrue()
    {
        if (mirrormode)
        {
            mirrormode = false;
        }
        else
        {
            mirrormode = true;
        }
    }
   
    public void Rellena_struct(string Name, GameObject RobotWrist, Vector3 ObjectPos, ObjGR[] dataGR, bool mirrormode)
    {
        int i = -1;

        bool find = false;
        bool blank = false;
        while (!blank && !find && i<5)
        {
            Debug.Log("Buscando");
            i++;
            if (dataGR[i].Name == Name)//--------------------------------falta una condicion-------------------------
            {
                find = true;
                if (mirrormode)
                {
                    dataGR[i].RobotWristPos = new Vector3(-RobotWrist.transform.position.x, RobotWrist.transform.position.y, RobotWrist.transform.position.z);
                    dataGR[i].RobotWristRot = RobotWrist.transform.rotation * Quaternion.Euler(0, 90, 90); ;

                }
                else
                {
                    dataGR[i].RobotWristPos = RobotWrist.transform.position;
                    dataGR[i].RobotWristRot = RobotWrist.transform.rotation;
                }

                dataGR[i].ObjectPos = ObjectPos;
                dataGR[i].pathPos.Clear();
                dataGR[i].pathPos.Add(dataGR[i].RobotWristPos);
                dataGR[i].pathRot.Clear();
                dataGR[i].pathRot.Add(dataGR[i].RobotWristRot);
                movementPos = 0;
                if (!patientmode)
                {
                    defineTarget(dataGR[i].RobotWristPos, dataGR[i].RobotWristRot);
                }
                GraspStay = true;

            }
            if (string.IsNullOrEmpty(dataGR[i].Name))
            {
                Debug.Log("encontrado");
                blank = true;
                dataGR[i].Name = Name;
                if (mirrormode)
                {
                    dataGR[i].RobotWristPos = new Vector3(-RobotWrist.transform.position.x, RobotWrist.transform.position.y, RobotWrist.transform.position.z);
                    dataGR[i].RobotWristRot = RobotWrist.transform.rotation* Quaternion.Euler(0,0,180);;
                     
                }
                else
                {
                    dataGR[i].RobotWristPos = RobotWrist.transform.position;
                    dataGR[i].RobotWristRot = RobotWrist.transform.rotation;
                }

                dataGR[i].ObjectPos = ObjectPos;

                //iniciamos las listas
                dataGR[i].pathPos = new List<Vector3>();
                dataGR[i].pathPos.Add(dataGR[i].RobotWristPos);

                dataGR[i].pathRot = new List<Quaternion>();
                dataGR[i].pathRot.Add(dataGR[i].RobotWristRot);
                if (!patientmode)
                {
                     defineTarget(dataGR[i].RobotWristPos, dataGR[i].RobotWristRot);
                }
                 GraspStay = true;

            }

        }



    }

    public void Rellena_path(int i, GameObject RobotWrist, ObjGR[] dataGR)
    {
        dataGR[i].pathPos.Add(RobotWrist.transform.position);
        dataGR[i].pathRot.Add(RobotWrist.transform.rotation);
        Instantiate(ballPrefab, RobotWrist.transform.position, Quaternion.identity);
    }

    public void defineTarget(Vector3 RobotWristPos, Quaternion RobotWristRot)
    {
                
                Target.transform.localRotation = RobotWristRot;
                Target.transform.localPosition = RobotWristPos;
            
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
        else if (start && FK_Marker.transform.position == Target.transform.position)
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
