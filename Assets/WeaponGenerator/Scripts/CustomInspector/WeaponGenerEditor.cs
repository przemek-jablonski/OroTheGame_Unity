using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(WeaponGenerationScript))]
public class WeaponGenerEditor : Editor {
	
	public override void OnInspectorGUI() {
		
		DrawDefaultInspector();
		
		WeaponGenerationScript weaponGenerator = (WeaponGenerationScript)target;
		
		
		if(GUILayout.Button("Hard Reset"))
			weaponGenerator.ResetList();
		
			/*
		if (GUILayout.Button("Generate: Receiver"))
			weaponGenerator.GenerateReceiver();
			
		if (GUILayout.Button("Generate: Stock"))
			weaponGenerator.GenerateStock();
			
		if(GUILayout.Button("Generate: Grip"))
			weaponGenerator.GenerateGrip();
			*/
		
		if (GUILayout.Button("Generate Modules"))
			weaponGenerator.GenerateAll();
			
		if (GUILayout.Button("Access The List"))
			weaponGenerator.accessModuleList();
			
		if (GUILayout.Button("Test IDs in List")) 
			weaponGenerator.checkIdentifiersInList();
			
		if (GUILayout.Button("Glue Stock to Receiver"))
			weaponGenerator.GlueStockReceiver();
		
		if (GUILayout.Button("Glue Grip to Receiver"))
			weaponGenerator.GlueGripReceiver();
	}
	
}
