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

    public bool mirrormode;
    public bool savedPathMode;
    public bool FirstGrasp;
    public bool start;

    public ObjGR[] dataGR;

    public GameObject ballPrefab;

    public int interactionObject;
    public int movementPos;

    public float period;


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

    public void PatientTrue()
    {
        if (savedPathMode)
        {
            savedPathMode = false;
        }
        else
        {
            savedPathMode = true;
        }
    }

    public void Rellena_struct(string Name, GameObject RobotWrist, Vector3 ObjectPos, ObjGR[] dataGR)
    {
        int i = -1;

        bool find = false;
        bool blank = false;
        while (!blank && !find && i < 10)
        {
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
                foreach (GameObject esfera in GameObject.FindGameObjectsWithTag("pathPoints"))
                {
                    Destroy(esfera);
                }

                if (!savedPathMode)
                {
                    defineTarget(dataGR[i].RobotWristPos, dataGR[i].RobotWristRot);
                }
                GraspStay = true;

            }
            if (string.IsNullOrEmpty(dataGR[i].Name))
            {

                blank = true;
                dataGR[i].Name = Name;
                if (mirrormode)
                {
                    dataGR[i].RobotWristPos = new Vector3(-RobotWrist.transform.position.x, RobotWrist.transform.position.y, RobotWrist.transform.position.z);
                    dataGR[i].RobotWristRot = RobotWrist.transform.rotation * Quaternion.Euler(0, 0, 180); ;

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
                if (!savedPathMode)
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
            if (!mirrormode)
            {
                Target.transform.localRotation = RobotWristRot;
                Target.transform.localPosition = RobotWristPos;
            }
            else
            {
                Target.transform.localPosition = new Vector3(-RobotWristRot.x, RobotWristRot.y, RobotWristRot.z);
                Target.transform.localRotation = RobotWristRot*Quaternion.Euler(180,90,0);
            }            
        

    }

    public int lookfor_name_Data(string name)
    {
        int i = -1;
        bool find = false;
        while (!find && i < 10)
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
            Debug.Log("Wrist position: " + data.RobotWristPos + " Wrist Rotation: " + data.RobotWristRot + " Object Position: " + data.ObjectPos);
        }

    }
    // Start is called before the first frame update
    
    
    public void slider(float newperiod)
    {
        period=newperiod;

    }
    
    
    
    void Start()
    {
        dataGR = new ObjGR[10];

        mirrormode = false;
        GraspStay = false;
        FirstGrasp = false;
        savedPathMode = false;
        start = false;
        movementPos = 0;
        period = 0.5f;
        interactionObject = 0;
        FK_Marker = GameObject.Find("FK Marker");
        Target = GameObject.Find("Target");

    }


    void savedPathPerformance()
    {
        //skip all the empty or not used slots
        while(GameObject.Find(dataGR[interactionObject].Name)==null && start)
        {
            interactionObject++;
            Debug.Log(interactionObject);
            if(string.IsNullOrEmpty(dataGR[interactionObject].Name) || interactionObject==10 || dataGR[interactionObject].pathPos.Count<=1)
            {
                interactionObject = 0;
                start = false;
 
            }
        }

        //------------------------------------------------------movement----------------------------------------------
        if (movementPos == 1 && start && GameObject.Find(dataGR[interactionObject].Name) != null)
        {
            if (dataGR[interactionObject].Name != "LightSaber")
            {
                GameObject.Find(dataGR[interactionObject].Name + "Robot").GetComponent<Rigidbody>().isKinematic = true;
             
            }
            GameObject.Find(dataGR[interactionObject].Name + "Robot").transform.SetParent(GameObject.Find("Agarre").transform);
            defineTarget(dataGR[interactionObject].pathPos[movementPos], dataGR[interactionObject].pathRot[movementPos]);
            movementPos++;
        }
        else if (movementPos < dataGR[interactionObject].pathPos.Count && movementPos >= 0 && start && GameObject.Find(dataGR[interactionObject].Name) != null)
        {
            defineTarget(dataGR[interactionObject].pathPos[movementPos], dataGR[interactionObject].pathRot[movementPos]); //HAY QUE SABER CON QUE OBJETO ESTAMOS
            movementPos++;

        }
        //End of the path
        if (movementPos == dataGR[interactionObject].pathPos.Count && start)
        {            
            if (dataGR[interactionObject].Name != "LightSaber")
            {
                GameObject.Find(dataGR[interactionObject].Name + "Robot").GetComponent<Rigidbody>().isKinematic=false;
            }
            movementPos = 0;
            interactionObject++;

            GameObject.Find("Agarre").transform.DetachChildren();

            defineTarget(GameObject.Find("Target2").transform.localPosition, GameObject.Find("Target2").transform.localRotation);
            if (string.IsNullOrEmpty(dataGR[interactionObject].Name) || GameObject.Find(dataGR[interactionObject].Name) == null)
            {
                interactionObject = 0;
                start = false;
            }
        }

    }
    public void ButtonStart()
    {
        start = true;
    }
    public void ButtonStop()
    {
        start = false;
    }
    private void Update()
    {
        if (!savedPathMode)
        {
            if (!GraspStay && GameObject.Find("Agarre").transform.childCount != 0)
            {
                GameObject.Find("Agarre").transform.DetachChildren();
                FirstGrasp = false;

            }
            //PARA COMPLETAR EL PATH
        }
        else if (FK_Marker.transform.position == Target.transform.position && start)
        {
            savedPathPerformance();
            Debug.Log("se ha intentao");
        }
    }
}
