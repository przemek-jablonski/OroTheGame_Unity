using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (CellularAutomataScript))]
public class CellularAutomataEditor : Editor {

	private CellularAutomataScript cellularAutomata;

	public override void OnInspectorGUI() {
		
		base.DrawDefaultInspector();
		cellularAutomata = (CellularAutomataScript) target;
		
		if (GUILayout.Button("new cycle (test)"))
			cellularAutomata.Cycle();
		
        if (GUILayout.Button("Create Map (Ground)")) { 
			cellularAutomata.GenerateEnumRepresentationArray();
            cellularAutomata.PrintEnumRep();
            cellularAutomata.InstantiateEnumRepresentation();
        }
            
		if (GUILayout.Button("Generate Boxes")) {
			cellularAutomata.GenerateBoxes();
            cellularAutomata.PrintEnumRep();
            cellularAutomata.InstantiateEnumRepresentation();
        }
			
		if (GUILayout.Button("Reset Boxes")) {
            cellularAutomata.ClearBoxes();
            cellularAutomata.GenerateBoxes();
            cellularAutomata.ClearBoxes();
            cellularAutomata.InstantiateEnumRepresentation();
        }
			
		if (GUILayout.Button("Automata Iteration")) {
            // !
        }
		
		if (GUILayout.Button("Delete Map")) {
            cellularAutomata.DeleteMap();
        }
			
		if (GUILayout.Button("Delete Boxes")) {
            cellularAutomata.ClearBoxes();
        }
			
        
        /*
		if (GUILayout.Button("Create Map"))
			cellularAutomata.InstantiateMap();
			
		if (GUILayout.Button("Generate Boxes"))
			cellularAutomata.CellularAutomataInitialStep();
			
		if (GUILayout.Button("Reset Boxes"))
			cellularAutomata.ResetCellularAutomata();
			
		if (GUILayout.Button("Automata Iteration"))
			cellularAutomata.CellularAutomataIteration();
		
		if (GUILayout.Button("Delete Map"))
			cellularAutomata.DeleteMap();
			
		if (GUILayout.Button("Delete Boxes"))
			cellularAutomata.DeleteBoxesLayer();
		*/
	}

}
