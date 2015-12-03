using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(WeaponGenerationScript))]
public class WeaponGenerEditor : Editor {
	
	public override void OnInspectorGUI() {
		
		DrawDefaultInspector();
		
		WeaponGenerationScript weaponGenerator = (WeaponGenerationScript)target;
		
		if (GUILayout.Button("Write to Console"))
			weaponGenerator.ButtonClick();
			
		if (GUILayout.Button("Generate: Receiver"))
			weaponGenerator.GenerateReceiver();
		
	}
	
}
