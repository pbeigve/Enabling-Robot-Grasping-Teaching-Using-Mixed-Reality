using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Varjo.XR;

public class MixedRealityMode : MonoBehaviour
{
    private int botton;
    private void Start()
    {
        botton = 0;
    }
    

    
    public void buttonpressed()
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
