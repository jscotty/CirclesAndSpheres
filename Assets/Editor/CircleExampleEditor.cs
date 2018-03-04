using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*
* @author 01001010 01010011 01000010
*/

[CustomEditor(typeof(CircleExample))]
[CanEditMultipleObjects]
public class CircleExampleEditor : Editor {
	private SerializedObject m_Object;
	private SerializedProperty m_Property;

	void OnEnable () {
	}

	public override void OnInspectorGUI () {
		CircleExample circle = (CircleExample) target;

		DrawDefaultInspector();



		if (GUILayout.Button("Generate world 2D (circle)")) {
			circle.GenerateWorld2D();
		}
		if (GUILayout.Button("Generate world 3D (sphere)")) {
			circle.GenerateWorld3D();
		}
	}
}
