using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor (typeof (OutdoorMapGeneration))]
public class OutdoorMapGenerationEditor : Editor {
    OutdoorMapGeneration generator;
    
    public override void OnInspectorGUI() {
        generator = (OutdoorMapGeneration) target;
        
        if(DrawDefaultInspector()) {
            if(generator.isAutoUpdatable)
                generator.Generate();
            
        }
        
        
        if(GUILayout.Button("Generate now"))
            generator.Generate();
        
    }

}
