using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataStruct : MonoBehaviour
{
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
            if (dataGR[i].Name == Name)//--------------------------------overwritte the object-------------------------
            {
                find = true;
                dataGR[i].RobotWristPos = RobotWrist.transform.position;
                dataGR[i].RobotWristRot = RobotWrist.transform.rotation;
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
            if (string.IsNullOrEmpty(dataGR[i].Name)) //--------------create the new object-----------------------------
            {

                blank = true;
                dataGR[i].Name = Name;
                dataGR[i].RobotWristPos = RobotWrist.transform.position;
                dataGR[i].RobotWristRot = RobotWrist.transform.rotation;
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

    public void Rellena_path(int i, GameObject RobotWrist, ObjGR[] dataGR) //fills new data in data list path
    {
        dataGR[i].pathPos.Add(RobotWrist.transform.position);
        dataGR[i].pathRot.Add(RobotWrist.transform.rotation);
        Instantiate(ballPrefab, RobotWrist.transform.position, Quaternion.identity);
    }

    public void defineTarget(Vector3 RobotWristPos, Quaternion RobotWristRot) //modify the Target position
    {
        if (!mirrormode)
        {
            Target.transform.localRotation = RobotWristRot;
            Target.transform.localPosition = RobotWristPos;
        }
        else
        {


            Target.transform.localRotation = new Quaternion(RobotWristRot.x, -RobotWristRot.y, -RobotWristRot.z, RobotWristRot.w) * Quaternion.Euler(0, 0, -40);
            Target.transform.localPosition = new Vector3(-RobotWristPos.x, RobotWristPos.y, RobotWristPos.z);

        }


    }

    public int lookfor_name_Data(string name) //Finds the position of an object in DataGR
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
    public void slider(float newperiod)
    {
        period = newperiod;

    }

    void savedPathPerformance() //Makes the movement of the robot in savedpath mode
    {
        //skip all the empty or not used slots
        while (GameObject.Find(dataGR[interactionObject].Name) == null && start)
        {
            interactionObject++;

            if (string.IsNullOrEmpty(dataGR[interactionObject].Name) || interactionObject == 10)
            {
                interactionObject = 0;
                start = false;
            }
        }
        //------------------------------------------------------movement----------------------------------------------
        if (movementPos == 1 && start) //the robot reach the first position and grasp
        {
            if (dataGR[interactionObject].Name != "LightSaber")
            {
                GameObject.Find(dataGR[interactionObject].Name + "Robot").GetComponent<Rigidbody>().isKinematic = true;

            }
            GameObject.Find(dataGR[interactionObject].Name + "Robot").transform.SetParent(GameObject.Find("Agarre").transform);
            defineTarget(dataGR[interactionObject].pathPos[movementPos], dataGR[interactionObject].pathRot[movementPos]);
            movementPos++;
        }
        else if (movementPos < dataGR[interactionObject].pathPos.Count && start) //the robot reach a position and gets the new one
        {
            defineTarget(dataGR[interactionObject].pathPos[movementPos], dataGR[interactionObject].pathRot[movementPos]);
            movementPos++;

        }
        //End of the path reset the parameters and goes to the next object
        if (movementPos >= dataGR[interactionObject].pathPos.Count && start)
        {
            GameObject.Find("Agarre").transform.DetachChildren();
            if (dataGR[interactionObject].Name != "LightSaber")
            {
                GameObject.Find(dataGR[interactionObject].Name + "Robot").GetComponent<Rigidbody>().isKinematic = false;
            }
            movementPos = 0;
            interactionObject++;
            defineTarget(GameObject.Find("Target2").transform.localPosition, GameObject.Find("Target2").transform.localRotation);
        }
        //----------------------------------------------------------------------------------------------------
    }
    public void ButtonStart()
    {
        start = true;
    }
    public void ButtonStop()
    {
        start = false;
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
    private void Update()
    {
        if (!savedPathMode) //standard mode
        {
            if (!GraspStay && GameObject.Find("Agarre").transform.childCount != 0)
            {
                GameObject.Find("Agarre").transform.DetachChildren();
                FirstGrasp = false;

            }
        }
        else if (FK_Marker.transform.position == Target.transform.position || Mathf.Approximately(1.0f / FK_Marker.transform.position.y, Target.transform.position.y) && start) //saved path mode
        {
            savedPathPerformance();
        }
    }
}
