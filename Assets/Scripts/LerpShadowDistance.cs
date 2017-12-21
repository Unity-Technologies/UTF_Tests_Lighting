using UnityEngine;
using System.Collections;

public class LerpShadowDistance : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		int interval = 5;

		QualitySettings.shadowDistance = (Mathf.PingPong(Time.time*interval, 22));

    }
}
