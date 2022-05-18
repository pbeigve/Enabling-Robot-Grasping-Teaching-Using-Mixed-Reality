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
    public GameObject LightSaber;
    public GameObject LightSaberRobot;

    public Vector3 tempPosition;
    public Vector3 tempPositionRobot;

    public Vector3 basePosition;
    public Vector3 basePositionRobot;

    public Quaternion baseOrientation;
    public Quaternion baseOrientationRobot;

    int i = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void rotate_object()
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

        }

        if (i == 3) //LASER SWORD
        {

            foreach (GameObject Mug in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(Mug);
            }
            foreach (GameObject MugRobot in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(MugRobot);
            }

            GameObject lightSaber = Instantiate(LightSaber, basePosition, baseOrientation);
            lightSaber.name = "LightSaber";
            GameObject lightSaberrobot = Instantiate(LightSaberRobot, basePositionRobot, baseOrientationRobot);
            lightSaberrobot.name = "LightSaberRobot";

        }

        i++;

        if (i==4)
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
            
        }
        if (i == 3) //TAZA
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
            
        }

        if (i == 0) //LASER SWORD
        {
            foreach (GameObject Lasersword in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(Lasersword);
            }
            foreach (GameObject LaserswordRobot in GameObject.FindGameObjectsWithTag("object"))
            {
                Destroy(LaserswordRobot);
            }

            GameObject lightSaber = Instantiate(LightSaber, basePosition, baseOrientation);
            lightSaber.name = "LightSaber";
            GameObject lightSaberrobot = Instantiate(LightSaberRobot, basePositionRobot, baseOrientationRobot);
            lightSaberrobot.name = "LightSaberRobot";

        }
        
    }
}
