using UnityEngine;
using System.Collections;

public class UpdateProbe : MonoBehaviour 
{
	ReflectionProbe probe;

	void Start()
	{
		probe = GetComponent<ReflectionProbe>();
		InvokeRepeating("UpdateReflection", 0, 0.2f);
	}

	void UpdateReflection()
	{
		probe.timeSlicingMode = UnityEngine.Rendering.ReflectionProbeTimeSlicingMode.NoTimeSlicing;
		probe.RenderProbe();
	}
}
