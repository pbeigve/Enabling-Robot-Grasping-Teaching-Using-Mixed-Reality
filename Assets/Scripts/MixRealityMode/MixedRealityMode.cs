using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Varjo.XR;

public class MixedRealityMode : MonoBehaviour
{
    private int botton;
    void Start()
    {
        botton = 0;
    }
    

    
    void update()
        {
        if (botton == 0)
{
             VarjoMixedReality.StartRender();
             botton = 1;
}
        else
{ 
            VarjoMixedReality.StopRender();
            botton = 0;
}
}
}
