using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapObject : MonoBehaviour
{

    public GameObject Cylinder;
    public GameObject CylinderRobot;
    public GameObject Cube;
    public GameObject CubeRobot;
    public GameObject Mug;
    public GameObject MugRobot;
    public GameObject Box;
    public GameObject BoxRobot;

    public Vector3 tempPosition;
    public Vector3 tempPositionRobot;

    public Vector3 basePosition;
    public Vector3 basePositionRobot;
    public Vector3 basePositionWait1;
    public Vector3 basePositionRobotWait1;
    public Vector3 basePositionWait2;
    public Vector3 basePositionRobotWait2;

    public Quaternion baseOrientation;
    public Quaternion baseOrientationRobot;

    int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    
        // Update is called once per frame
        void Update()
    {
        
    }

    public void Swap()
    {
        
        if (i == 0) //CILINDRO
        {
            

            foreach (GameObject Mug in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(Mug);
            }
            foreach (GameObject MugRobot in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(MugRobot);
            }

            GameObject cylinder = Instantiate(Cylinder, basePosition, baseOrientation);
            cylinder.name = "Cylinder";
            GameObject cylinderrobot = Instantiate(CylinderRobot, basePositionRobot, baseOrientationRobot);
            cylinderrobot.name = "CylinderRobot";
            Instantiate(Box, basePosition, baseOrientation);
            Instantiate(BoxRobot, basePositionRobot, baseOrientationRobot);
            /*
            //OBJETO NORMAL

        tempPosition = Cylinder.transform.position;

        Cylinder.transform.position = Cube.transform.position;

        Cube.transform.position = tempPosition;
        //ROBOT OBJETO
        tempPositionRobot = CylinderRobot.transform.position;

        CylinderRobot.transform.position = CubeRobot.transform.position;

        CubeRobot.transform.position = tempPositionRobot;
            
            */

        }

        if (i == 1) //CUBOS
        {
            
            foreach (GameObject Cylinder in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(Cylinder);
            }
            foreach (GameObject CylinderRobot in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(CylinderRobot);
            }

            GameObject cube = Instantiate(Cube, basePosition, baseOrientation);
            cube.name = "Cube";
            GameObject cuberobot = Instantiate(CubeRobot, basePositionRobot, baseOrientationRobot);
            cuberobot.name = "CubeRobot";

            /*
            //OBJETO NORMAL
            tempPosition = Cube.transform.position;

            Cube.transform.position = Mug.transform.position;

            Mug.transform.position = tempPosition;
            //ROBOT OBJETO
            tempPositionRobot = CubeRobot.transform.position;

            CubeRobot.transform.position = MugRobot.transform.position;

            MugRobot.transform.position = tempPositionRobot;
            
            */
        }
        if (i == 2) //TAZA
        {
            
            foreach (GameObject Cube in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(Cube);
            }
            foreach (GameObject CubeRobot in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(CubeRobot);
            }

            GameObject mug = Instantiate(Mug, basePosition, baseOrientation);
            mug.name = "Mug";
            GameObject mugrobot = Instantiate(MugRobot, basePositionRobot, baseOrientationRobot);
            mugrobot.name = "MugRobot";

            /*
            //OBJETO NORMAL
            tempPosition = Mug.transform.position;

            Mug.transform.position = Cylinder.transform.position;

            Cylinder.transform.position = tempPosition;
            //ROBOT OBJETO
            tempPositionRobot = MugRobot.transform.position;

            MugRobot.transform.position = CylinderRobot.transform.position;

            CylinderRobot.transform.position = tempPositionRobot;
           */

        }
        i++;
        if (i==3)
        {
            i = 0;
        }
    }

    public void ResetPos()
    {
        if (i==1) //CILINDRO
        {
            foreach (GameObject Cylinder in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(Cylinder);
            }
            foreach (GameObject CylinderRobot in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(CylinderRobot);
            }
            GameObject cylinder = Instantiate(Cylinder, basePosition, baseOrientation);
            cylinder.name = "Cylinder";
            GameObject cylinderrobot = Instantiate(CylinderRobot, basePositionRobot, baseOrientationRobot);
            cylinderrobot.name = "CylinderRobot";
            Instantiate(Box, basePosition, baseOrientation);
            Instantiate(BoxRobot, basePositionRobot, baseOrientationRobot);
            /*
        Cylinder.transform.position = basePosition;
        CylinderRobot.transform.position = basePositionRobot;
        Cube.transform.position = basePositionWait1;
        CubeRobot.transform.position = basePositionRobotWait1;
        Mug.transform.position = basePositionWait2;
        MugRobot.transform.position = basePositionRobotWait2;
            */
        }

        if (i == 2) //CUBOS
        {
            foreach (GameObject Cube in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(Cube);
            }
            foreach (GameObject CubeRobot in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(CubeRobot);
            }
            GameObject cube = Instantiate(Cube, basePosition, baseOrientation);
            cube.name = "Cube";
            GameObject cuberobot = Instantiate(CubeRobot, basePositionRobot, baseOrientationRobot);
            cuberobot.name = "CubeRobot";
            /*
            Cylinder.transform.position = basePositionWait1;
            CylinderRobot.transform.position = basePositionRobotWait1;
            Cube.transform.position = basePosition;
            CubeRobot.transform.position = basePositionRobot;
            Mug.transform.position = basePositionWait2;
            MugRobot.transform.position = basePositionRobotWait2;
            */
        }
        if (i == 0) //TAZA
        {
            foreach (GameObject Mug in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(Mug);
            }
            foreach (GameObject MugRobot in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(MugRobot);
            }

            GameObject mug = Instantiate(Mug, basePosition, baseOrientation);
            mug.name = "Mug";
            GameObject mugrobot = Instantiate(MugRobot, basePositionRobot, baseOrientationRobot);
            mugrobot.name = "MugRobot";
            /*
            Cylinder.transform.position = basePositionWait2;
            CylinderRobot.transform.position = basePositionRobotWait2;
            Cube.transform.position = basePositionWait1;
            CubeRobot.transform.position = basePositionRobotWait1;
            Mug.transform.position = basePosition;
            MugRobot.transform.position = basePositionRobot;
            */
        }


    }
}
