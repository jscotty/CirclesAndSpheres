using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CircleGenerationSettings = CircleGenerator.CircleGenerationSettings; // import enum from circle generator

/*
* @author 01001010 01010011 01000010
*/

[ExecuteInEditMode] // We do not want to run our application everytime ;)
public class CircleExample : MonoBehaviour {

	// example preset
	/*private static readonly short[][] preset = new short[][] { // presetting the amount and index of objects per row from up to down.
		new short[] { 0 },
		new short[] { 0,0,0,0 },
		new short[] { 0,0,0,0,0 },
		new short[] { 0,0,0,0,0 },
		new short[] { 0,0,0,0,0,0,0,0,0,0,0 },
		new short[] { 0,0,0,0,0 },
		new short[] { 0,0,0,0,0 },
		new short[] { 0,0,0,0 },
		new short[] { 0 },
	};*/

	// world preset
	private static readonly short[][] preset = new short[][] {// presetting the amount and index of objects per row from up to down.
		new short[] { 4 },
		new short[] { 0,2,0, -1, -1, 3,1,0,3,5,0,6 },
		new short[] { 0,0,0, -1, 6,0,1,2 },
		new short[] { 4,0,5,0, -1, 6,3,3,2,4,0 },
		new short[] { 0,2,5,4,0,0,3,0 },
		new short[] { 0,2,0, -1, 0,5,4,4,0,2 },
		new short[] { 1,0,3,0,6,5,4,3,2,1,0,4,0 },
		new short[] { 0,0,1,-1,-1,0,3,0,5,0,6, -1, 0,0 },
		new short[] { 4,0, -1, 5,0,6,3,3,2,4,0 },
		new short[] { 0,2,5,4, -1, -1, -1, 0,5,4,3,0, -1, -1, 3,0 },
		new short[] { 0,2,0,0, -1},
		new short[] { 4 },
	};
	public CircleGenerationSettings settings = new CircleGenerationSettings() {
		amount = 20, radius = 50, angleCorrection = 45.0f
	};
	private CircleGenerator generator = new CircleGenerator();

	public void GenerateWorld2D () {
		RemoveAllChildren();
		generator.GenerateCircle2D(settings, this.transform);
	}

	public void GenerateWorld3D () {
		RemoveAllChildren();

		for (int i = 0 ; i < preset.Length ; i++) {
			generator.GenerateCircle3D(preset[i], i, preset.Length - 1, settings, this.transform);
		}
	}

	private void RemoveAllChildren () {
		for (int i = transform.childCount - 1 ; i >= 0 ; i--) {
			GameObject.DestroyImmediate(transform.GetChild(i).gameObject);
		}
	}
}
