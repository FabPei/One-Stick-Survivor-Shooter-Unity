using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.U2D; old ppc
using UnityEngine.Experimental.Rendering.Universal;
public class TestPPCamera : MonoBehaviour
{
    public PixelPerfectCamera ppc;
    public int width;
    public int height;
    // Start is called before the first frame update
    void Start()
    {
        ppc = this.GetComponent<PixelPerfectCamera>();

        width = Screen.width;
        height = Screen.height;

        ppc.refResolutionX = width;

        ppc.refResolutionY = height;
        //height = 2f * MainCamera.orthographicSize;
        //width = height * MainCamera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
