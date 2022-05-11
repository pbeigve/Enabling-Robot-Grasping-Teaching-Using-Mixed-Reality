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
    public string Object;

    public Vector3 tempPosition;
    public Vector3 tempPositionRobot;

    public Vector3 basePosition;
    public Vector3 basePositionRobot;
    public Vector3 basePositionWait1;
    public Vector3 basePositionRobotWait1;
    public Vector3 basePositionWait2;
    public Vector3 basePositionRobotWait2;
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
            //OBJETO NORMAL
            Object = "Cylinder";
        tempPosition = Cylinder.transform.position;

        Cylinder.transform.position = Cube.transform.position;

        Cube.transform.position = tempPosition;
        //ROBOT OBJETO
        tempPositionRobot = CylinderRobot.transform.position;

        CylinderRobot.transform.position = CubeRobot.transform.position;

        CubeRobot.transform.position = tempPositionRobot;
            i++;
        }

        if (i == 1) //CUBOS
        {
            //OBJETO NORMAL
            tempPosition = Cube.transform.position;

            Cube.transform.position = Mug.transform.position;

            Mug.transform.position = tempPosition;
            //ROBOT OBJETO
            tempPositionRobot = CubeRobot.transform.position;

            CubeRobot.transform.position = MugRobot.transform.position;

            MugRobot.transform.position = tempPositionRobot;
            i++;
        }
        if (i == 2) //TAZA
        {
            //OBJETO NORMAL
            tempPosition = Mug.transform.position;

            Mug.transform.position = Cylinder.transform.position;

            Cylinder.transform.position = tempPosition;
            //ROBOT OBJETO
            tempPositionRobot = MugRobot.transform.position;

            MugRobot.transform.position = CylinderRobot.transform.position;

            CylinderRobot.transform.position = tempPositionRobot;
            i = 0;
        }


    }

    public void ResetPos()
    {
        if (i==0) //CILINDRO
        {
        Cylinder.transform.position = basePosition;
        CylinderRobot.transform.position = basePositionRobot;
        Cube.transform.position = basePositionWait1;
        CubeRobot.transform.position = basePositionRobotWait1;
        }

        if (i == 1) //CUBOS
        {
            Cylinder.transform.position = basePositionWait1;
            CylinderRobot.transform.position = basePositionRobotWait1;
            Cube.transform.position = basePosition;
            CubeRobot.transform.position = basePositionRobot;
        }
        if (i == 2) //TAZA
        {
            Cylinder.transform.position = basePositionWait1;
            CylinderRobot.transform.position = basePositionRobotWait1;
            Cube.transform.position = basePositionWait2;
            CubeRobot.transform.position = basePositionRobotWait2;
            Cylinder.transform.position = basePosition;
            CylinderRobot.transform.position = basePositionRobot;
        }


    }
}
