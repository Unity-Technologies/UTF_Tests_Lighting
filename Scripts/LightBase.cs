using UnityEngine;
using System.Collections;

public class LightBase : MonoBehaviour {

    [HideInInspector]
    public float timePassed;
    [HideInInspector]
    public float changeValue;
    [HideInInspector]
    public int randomVal;
    
    public float TimePassed
    {
        get { return timePassed; }
        set { timePassed = value; }
    }

    public float ChangeValue
    {
        get { return changeValue; }
        set { changeValue = value; }
    }

    public float minimumValue = 0.5f;
    public int flickerFrequency = 15;


    void Start()
    {
        if (minimumValue < 0)
        {
            minimumValue = 0;
        }
        else if (minimumValue > 1)
        {
            minimumValue = 1;
        }

        if (flickerFrequency < 0)
        {
            flickerFrequency = 0;
        }
        else if (flickerFrequency > 100)
        {
            flickerFrequency = 100;
        }
    }

    public int RandomValue()
    {
        randomVal = Random.Range(0, 100);

        return randomVal;
    }
}
