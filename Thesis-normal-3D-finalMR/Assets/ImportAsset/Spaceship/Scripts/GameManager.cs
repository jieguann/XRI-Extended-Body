using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MRSpace;
    public float spaceshipMovementSpeed;
    public float spaceshipRotateSpeed;
    //[SerializeField] JoystickControll Joystick;
    // Start is called before the first frame update
    public GameObject spaceship;
    MeshRenderer[] renderers;
    Color[] col;
    public float transparentValue;

  
    public GameObject spaceshipInterior;
    Material[] materials;
    Color[] spaceshipInteriorColor;
    void Start()
    {
        //mr = spaceship.GetComponentsInChildren<MeshRenderer>().Length;
        renderers = new MeshRenderer[spaceship.GetComponentsInChildren<MeshRenderer>().Length];
        col = new Color[spaceship.GetComponentsInChildren<MeshRenderer>().Length];
        renderers = spaceship.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < renderers.Length; i++)
        {   

            renderers[i].material.SetFloat("_Mode", 3);
            renderers[i].material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            renderers[i].material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            renderers[i].material.SetInt("_ZWrite", 0);
            renderers[i].material.DisableKeyword("_ALPHATEST_ON");
            renderers[i].material.DisableKeyword("_ALPHABLEND_ON");
            renderers[i].material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
            renderers[i].material.renderQueue = 3000;
            renderers[i].material.SetInt("_SmoothnessTextureChannel", 0);
            


        }

        materials = new Material[4];
        spaceshipInteriorColor = new Color[4];



        materials = spaceshipInterior.GetComponent<MeshRenderer>().materials;

        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            //col[i] = mr[i].material.color;
            col[i].r = 1;
            col[i].g = 1;
            col[i].b = 1;
            col[i].a = transparentValue; // pass float value here
            renderers[i].material.color = col[i];
        }

        for (int i = 0; i < 4; i++)
        {
            spaceshipInteriorColor[i].r = 1;
            spaceshipInteriorColor[i].g = 1;
            spaceshipInteriorColor[i].b = 1;
            spaceshipInteriorColor[i].a = transparentValue;
            materials[i].color = spaceshipInteriorColor[i];

        }


    }
}
