using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* @author 01001010 01010011 01000010 
*/

public sealed class CircleGenerator {

	private const float CIRCLE_ANGLE = 360.0f;

	[System.Serializable]
	public struct CircleGenerationSettings {
		[Header("General")]
		public float radius;
		public GameObject[] prefab;
		public float angleCorrection;

		[Header("2D")]
		public int amount;

	}

	public void GenerateCircle2D (CircleGenerationSettings settings, Transform parent = null) {
		var anglePerSpot = CIRCLE_ANGLE / settings.amount;
		for (int i = 0 ; i < settings.amount ; i++) {
			//calculate position
			float a = anglePerSpot, angle, newX, newY;
			a = (i * anglePerSpot);
			angle = (a * Mathf.PI / (CIRCLE_ANGLE / 2));
			// no need to add center because we can use unity local position.
			newX = (float) (settings.radius * Mathf.Sin(angle));
			newY = (float) (settings.radius * Mathf.Cos(angle));

			var obj = GameObject.Instantiate(settings.prefab[0], parent);
			obj.transform.localPosition = new Vector3(newX, newY, 0);

			// rotate
			Vector3 rot = obj.transform.eulerAngles;
			rot.z = -(Mathf.Rad2Deg * angle) - settings.angleCorrection;
			obj.transform.eulerAngles = rot;
		}
	}

	public void GenerateCircle3D (short[] set, float index, float length, CircleGenerationSettings settings, Transform parent = null) {
		var anglePerSpot = CIRCLE_ANGLE / set.Length;
		for (int i = 0 ; i < set.Length ; i++) {
			if (set[i] < 0) {
				continue;
			}
			//calculate position
			float a = anglePerSpot, angle, newX, newY, newZ;
			a = (i * anglePerSpot);
			angle = (a * Mathf.PI / (CIRCLE_ANGLE / 2));
			

			// finding sphere cap radius
			var radius = settings.radius;
			float height = (float) (((index / length) - 0.5f)) * (settings.radius*2);
			radius = Mathf.Sqrt((radius * radius) - (height * height));

			newX = (float) (radius * Mathf.Sin(angle));
			newY = (float) (radius * Mathf.Cos(angle));
			newZ = height;

			var obj = GameObject.Instantiate(settings.prefab[set[i]], parent);
			obj.transform.localPosition = new Vector3(newX, newY, newZ);

			// rotate
			Vector3 objectDistance = (obj.transform.position - parent.transform.position).normalized;
			Vector3 targetUp = parent.transform.up;
			Quaternion targetRotation = Quaternion.FromToRotation(targetUp, objectDistance) * obj.transform.rotation;
			obj.transform.rotation = targetRotation;
			
		}
	}
}
