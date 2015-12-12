using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (CellularAutomataScript))]
public class CellularAutomataEditor : Editor {

	private CellularAutomataScript cellularAutomata;

	public override void OnInspectorGUI() {
		
		base.DrawDefaultInspector();
		cellularAutomata = (CellularAutomataScript) target;
		
		if (GUILayout.Button("Create Map"))
			cellularAutomata.CreateMap();
		
		if (GUILayout.Button("Delete Map"))
			cellularAutomata.DeleteMap();
	}

}
