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
			
		if (GUILayout.Button("Generate: Stock"))
			weaponGenerator.GenerateStock();
			
		if (GUILayout.Button("Access The List"))
			weaponGenerator.accessModuleList();
			
		if (GUILayout.Button("Glue Stock to Receiver"))
			weaponGenerator.GlueStockReceiver();
		
	}
	
}
