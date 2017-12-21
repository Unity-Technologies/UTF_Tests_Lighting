using UnityEngine;
using System.Collections;

public class Flicker : LightBase
{
    
    private Light thisLight;
    private Color originalColor;

    [HideInInspector]
    public int randomFlickerVal;

    public Light ThisLight
    {
        get { return thisLight; }
    }


    public Color OriginalColor
    {
        get { return originalColor; }
    }


    //Initialization of general values
    void Awake()
    {
        thisLight = this.GetComponent<Light>();
        if (thisLight != null)
        {
            originalColor = thisLight.color;
        }

        timePassed = Time.time;
        changeValue = 1;
    }


    void Update()
    {
        ThisLight.color = OriginalColor * UpdateLightSource();
    }

    private float UpdateLightSource()
    {
        randomFlickerVal = RandomValue();

        if (randomVal <= flickerFrequency)
        {

            ChangeValue = 1;
        }
        else
        {

            ChangeValue = minimumValue;
        }

        return ChangeValue;
    }
}
