using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (MapGeneratorScript))]
public class MapGeneratorEditor : Editor {
	
	public override void OnInspectorGUI() {
		
		DrawDefaultInspector();	
		MapGeneratorScript mapGeneratorScript = (MapGeneratorScript) target;
		
		if (GUILayout.Button("Debug.Log() test"))
			Debug.Log("asdasd");
		
		
		if (GUILayout.Button("Generate Map"))
			mapGeneratorScript.GenerateMap();
			
		if (GUILayout.Button("Generate Boxes"))
			mapGeneratorScript.LittleMoreComplexFillWithBoxes();
		
		if (GUILayout.Button("Delete tiles"))
			mapGeneratorScript.DeleteTiles();
		
		if(GUILayout.Button("Calculate Quad Side"))
			mapGeneratorScript.CalculateQuadSide();
	
	}

}
