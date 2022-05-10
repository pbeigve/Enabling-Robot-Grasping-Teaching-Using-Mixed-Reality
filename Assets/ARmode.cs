using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Varjo.XR;
using UnityEngine.SceneManagement;
public class ARmode : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        VarjoMixedReality.StartRender();
         // Enable Depth Estimation.
        VarjoMixedReality.EnableDepthEstimation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
