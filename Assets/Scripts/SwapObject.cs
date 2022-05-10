using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapObject : MonoBehaviour
{

    public GameObject Cylinder;
    public GameObject Cube;

    public Vector3 tempPosition;
    public Vector3 basePosition;

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
        tempPosition = Cylinder.transform.position;

        Cylinder.transform.position = Cube.transform.position;

        Cube.transform.position = tempPosition;

    }

    public void ResetPos()
    {
        Cylinder.transform.position = basePosition;
    }
}
