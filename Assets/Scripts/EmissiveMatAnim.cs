using UnityEngine;
using System.Collections;

public class EmissiveMatAnim : LightBase
{

    public Color MaterialColor;
    [HideInInspector]
    public int randomEmVal;

    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        float floor = 0.3f;
        float emission = floor + UpdateEmissiveSource();
        Color baseColor = MaterialColor;
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        renderer.material.SetColor("_EmissionColor", finalColor);
    }


    private float UpdateEmissiveSource()
    {
        randomEmVal = RandomValue();

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
