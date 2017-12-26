using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DayNightCycle : MonoBehaviour
{

   // public Camera mainCamera;
   // private float fogEndDistance;
    // Define colors for day and night
    [Header("Day Night Colors")]
    public Gradient dayNightColor;
    public Gradient dayNightFogColor;

    [Header("Light Intensity")]
    public float maxIntensity = 3f;
    public float minIntensity = 0f;
    public float minPoint = -0.2f;


    [Header("Ambient Intensity")]
    public float maxAmbient = 1f;
    public float minAmbient = 0f;
    public float minAmbientPoint = -0.2f;

    [Space(20)]

    private float fogDistance;
    public float maxFogDistance;
    public float minFogDistance;
    public AnimationCurve fogDensityCurve;
    public float fogScale = 1f;

    // Vectors for Day Night Cycle Speed
    private Vector3 dayTimeSpeed = new Vector3(-3, 0, 0);
    private Vector3 nightTimeSpeed = new Vector3(-18,0, 0);

    private float dot;
    private float dotFog;
    private float tRange;
    private float i;
    private bool isNight = false;

    [Space(20)]
    // Default value for Sky Speed Rotation
    [Range(0, 9)]
    public float skySpeed = 4;

    Light sun; // Sun gameobject in the scene
    Skybox sky; // Adding sky, not used atm. But maybe?

  //  public GameObject stars;
    // public Light monoLight;
    public GameObject nightSetup;


    void Start()
    {

        sun = GetComponent<Light>(); // Retrieve the light component from Sun
        nightSetup.SetActive(false);
    }

    void Update()
    {

        if(dot < 0.3)
        {
            nightSetup.SetActive(true);

        }else
        {
            nightSetup.SetActive(false);

        }

        //ChangeLightProperties();
        ChangeLightIntensity();
        ChangeAmbientProperties();
        UpdateRenderSettings();
        FogDistance();

        if (dot > 0)
        {
            transform.Rotate(dayTimeSpeed * Time.deltaTime * skySpeed);
            isNight = false;
        }
        else
        {
            transform.Rotate(nightTimeSpeed * Time.deltaTime * skySpeed);
            isNight = true;
        }

        if (isNight)
        {
          //  stars.gameObject.SetActive(true);
           // monoLight.enabled = true;
            RotateStars();
            //RenderSettings.skybox = skyBoxMaterial[0];

        }
        else
        {
           // stars.gameObject.SetActive(false);
           //e nightSetup.SetActive(false);
            // monoLight.enabled = false;
           // RenderSettings.skybox = skyBoxMaterial[1];

        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            skySpeed += 1f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            skySpeed -= 1f;
        }
    }

    public void ChangeLightIntensity()
    {
        // Local variables for changing the properties of light
        tRange = 1 - minPoint; // Set the range
        Vector3 localSun = sun.transform.forward; // local up vector of sun
        dot = Mathf.Clamp01((Vector3.Dot(localSun, Vector3.down) - minPoint) / tRange); // 
        i = ((maxIntensity - minIntensity) * dot) + minIntensity;

        sun.intensity = i;
    }


    public void ChangeLightProperties()
    {
        // Local variables for changing the properties of light
        tRange = 1 - minPoint; // Set the range
        Vector3 localSun = sun.transform.forward; // local up vector of sun
        dot = Mathf.Clamp01((Vector3.Dot(localSun, Vector3.down) - minPoint) / tRange); // 
        i = ((maxIntensity - minIntensity) * dot) + minIntensity;

        sun.intensity = i;
    }

    public void FogDistance()
    {
        //fogDistance = StylisticFog.defaultFogValue;

        tRange = 1 - minPoint; // Set the range
        Vector3 localSun = sun.transform.forward; // local up vector of sun
        dotFog = Mathf.Clamp01((Vector3.Dot(localSun, Vector3.down) - minPoint) / tRange);

        //float lerpFactor = ((maxFogDistance - minFogDistance) * dotFog) + minFogDistance; ;

        /*
        float interval = Time.time / 15;
        float lerpFactor = interval - Mathf.Floor(interval);

        fogDistance = (Mathf.Lerp(maxFogDistance, minFogDistance, Mathf.PingPong( lerpFactor, maxFogDistance)));
        */

        //fogEndDistance = Mathf.Clamp(((maxFogDistance - minFogDistance) * dotFog) + minIntensity, minFogDistance, maxFogDistance);
       // RenderSettings.fogEndDistance = Mathf.Clamp(((maxFogDistance - minFogDistance) * dotFog) + minIntensity, minFogDistance, maxFogDistance);

        //Debug.Log(fogEndDistance);
    }

    public void ChangeAmbientProperties()
    {
        tRange = 1 - minAmbientPoint;
        dot = Mathf.Clamp01((Vector3.Dot(sun.transform.forward, Vector3.down) - minAmbientPoint) / tRange);
        i = ((maxAmbient - minAmbient) * dot) + minAmbient;
        RenderSettings.ambientIntensity = i;

        sun.color = dayNightColor.Evaluate(dot); // Update sun color
    }

    public void UpdateRenderSettings()
    {
        // Update Ambient Light, Fog Color and Fog Density based on the location of sun
        RenderSettings.ambientLight = sun.color;
        RenderSettings.fogColor = dayNightFogColor.Evaluate(dot);
        RenderSettings.fogDensity = fogDensityCurve.Evaluate(dot) * fogScale;

    }

    void RotateStars()
    {
       // stars.transform.rotation = transform.rotation;
    }
}

