using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor (typeof (OutdoorMapGeneration))]
public class OutdoorMapGenerationEditor : Editor {
    
    public override void OnInspectorGUI() {
        OutdoorMapGeneration generator = (OutdoorMapGeneration) target;
        
        if(DrawDefaultInspector()) {
            if(generator.autoUpdate)
                generator.Generate();
            
        }
        
        
        if(GUILayout.Button("Generate now")) {
            generator.Generate();
        }
        
    }

}
