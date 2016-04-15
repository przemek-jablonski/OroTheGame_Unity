using UnityEditor;
using System.Collections;
using UnityEngine;

[CustomEditor(typeof (OutdoorMapController))]
public class OutdoorMapGeneratorView : Editor {
	
	public override void OnInspectorGUI() {
        OutdoorMapController outdoorMapController = (OutdoorMapController)target;

        if (DrawDefaultInspector()) {
			// if (outdoorMapGenerator.autoUpdate) {
			// 	...
			// }
		}
		
		
		if (GUILayout.Button("Generate Texture"))
            outdoorMapController.GenerateTexture();
       
		
		if (GUILayout.Button("Generate Mesh"))
            outdoorMapController.GenerateMesh();
        
	}
	
	
}
