using UnityEngine;
using System.Collections.Generic;


public class WeaponGenerationScript : MonoBehaviour {

	//TODO: FIX: instead of GameObject, list should contain WeaponModule type!
	private List<GameObject> moduleList = new List<GameObject>();
	
	public void ResetList() {
		moduleList = new List<GameObject>();
	}	
	
	private void GenerateReceiver() {
		moduleList.Add(
						Instantiate(Resources.Load("WeaponGeneratorResources/Prefabs/Receivers/receiver_m16a2"), 
						transform.position, 
						Quaternion.identity) as GameObject);
	}
	
	private void GenerateStock() {
		moduleList.Add(
						Instantiate(Resources.Load("WeaponGeneratorResources/Prefabs/Stocks/stock_nostock"),
						transform.position + new Vector3(1,3,2),
						new Quaternion(10, 60, -45, 1)) as GameObject);
	}
	
	private void GenerateGrip() {
		moduleList.Add(
						Instantiate(Resources.Load("WeaponGeneratorResources/Prefabs/Grips/grip_marksman"),
						transform.position + new Vector3(-1,-2,-1),
						new Quaternion(Random.Range(-360, 360), Random.Range(-360,360), Random.Range(-360, 360), Random.Range(1,2))) as GameObject);
	}
	
	
	
	public void GenerateAll() {
		GenerateReceiver();
		GenerateStock();
		GenerateGrip();
	}
	
	public void accessModuleList() {
		Debug.Log("ModuleListPrint: ");
		Debug.Log("module0: " + moduleList[0].name);
		Debug.Log("module1: " + moduleList[1].name);
		Debug.Log("module1: " + moduleList[2].name);
	}
	
	public void checkIdentifiersInList() {
		Debug.Log("Checking Identifier scripts:");
		for (int i = 0 ; i < moduleList.Count; ++i) {
			WGIdentifier id = moduleList[i].GetComponent<WGIdentifier>();
			if (id != null) 
				Debug.Log("list[" + i + "], identifier found.(" + id.objectType);
			else
				Debug.Log("list[" + i + "], ERROR: ID NOT FOUND");
		}
	}
	
	
	public void GlueStockReceiver() {
		
		Vector3 targetModulePosition = new Vector3(-10,-10,-10);
		Quaternion targetRotation = Quaternion.identity;
		
		Vector3 deltaModelVulcrum = Vector3.zero;
		
		WGIdentifier [] components = moduleList[0].GetComponentsInChildren<WGIdentifier>();
		
		foreach (WGIdentifier identifier in moduleList[1].GetComponentsInChildren<WGIdentifier>()) {
			if (identifier.objectType == WGIdentifierEnum.moduleVulcrum
					&& identifier.module == WGModuleEnum.stock) {
					deltaModelVulcrum = identifier.transform.position - moduleList[1].transform.position; 
					Debug.Log(moduleList[1].transform.position + " / " + identifier.transform.position);
					}
		}
		
		Debug.Log("delta position: " + deltaModelVulcrum);
		
		foreach (WGIdentifier component in components) {
			if (component.objectType == WGIdentifierEnum.moduleVulcrum
						&& component.module == WGModuleEnum.stock) {
						
				Debug.Log("FOUND APPROPRIATE VULCRUM!");
				targetModulePosition = component.transform.position;
				targetRotation = component.transform.rotation;	
			}
		}
	
		if(moduleList[1].GetComponent<WGIdentifier>() 
				&& moduleList[1].GetComponent<WGIdentifier>().objectType == WGIdentifierEnum.moduleGroup) {
					
			Debug.Log("modulelist[1] is indeed ModuleGroup, moving...");
			moduleList[1].transform.position = targetModulePosition + deltaModelVulcrum;
			moduleList[1].transform.rotation = targetRotation;
		}
		
	}
	
	public void GlueGripReceiver() {
		WGIdentifier targetVulcrum = new WGIdentifier();
		Quaternion targetVulcrumRotation = Quaternion.identity;
		Vector3 targetVulcrumCentre = Vector3.zero;
		
		WGIdentifier gluedGroup = new WGIdentifier();
		WGIdentifier gluedVulcrum = new WGIdentifier();
		Vector3		 gluedVulcrumCentre = Vector3.zero;
		Vector3		 gluedModuleDelta = Vector3.zero;
		Quaternion   gluedModuleRotationDelta = Quaternion.identity;
		
		
		foreach (WGIdentifier id in moduleList[0].GetComponentsInChildren<WGIdentifier>()) {
			if (id.objectType == WGIdentifierEnum.moduleVulcrum
					&& id.module == WGModuleEnum.grip) {
						Debug.Log("Found appropriate vulcrum");
						targetVulcrum = id;
						targetVulcrumRotation = targetVulcrum.transform.rotation;
						targetVulcrumCentre = targetVulcrum.GetComponent<Renderer>().bounds.center;
						//targetVulcrumCentre = targetVulcrum.transform.position;
					}
			
		}
		
		foreach (WGIdentifier id in moduleList[2].GetComponentsInChildren<WGIdentifier>()) {
			if (id.objectType == WGIdentifierEnum.moduleGroup
					&& id.module == WGModuleEnum.grip) 
						gluedGroup = id;
					
			
			if (id.objectType == WGIdentifierEnum.moduleVulcrum
					&& id.module == WGModuleEnum.grip) {
						gluedVulcrum = id;
						gluedVulcrumCentre = gluedVulcrum.GetComponent<Renderer>().bounds.center;
						
					}
		}
		
		gluedGroup.transform.rotation = targetVulcrum.transform.rotation;
		gluedGroup.transform.forward = -gluedGroup.transform.forward;
		
		gluedModuleDelta = gluedGroup.transform.position - gluedVulcrum.transform.position;
		gluedGroup.transform.position = targetVulcrum.transform.position + gluedModuleDelta;
		//Quaternion q = new Quaternion
	
		

		
	}
}
