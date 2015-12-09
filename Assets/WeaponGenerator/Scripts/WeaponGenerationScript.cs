using UnityEngine;
using System.Collections.Generic;


public class WeaponGenerationScript : MonoBehaviour {

	//TODO: FIX: instead of GameObject, list should contain WeaponModule type!
	List<GameObject> moduleList = new List<GameObject>();
	
	void Start () {
		
	}

	public void ResetList() {
		moduleList = new List<GameObject>();
	}	
	
	public void ButtonClick() {
		Debug.Log("WeaponGenerationScript Button pressed!");
	}
	
	public void GenerateReceiver() {
		moduleList.Add(
						Instantiate(Resources.Load("WeaponGeneratorResources/Prefabs/Receivers/receiver_m16a2"), 
						transform.position, 
						Quaternion.identity) as GameObject);
	}
	
	public void GenerateStock() {
		moduleList.Add(
						Instantiate(Resources.Load("WeaponGeneratorResources/Prefabs/Stocks/stock_nostock"),
						transform.position,
						Quaternion.identity) as GameObject);
	}
	
	public void accessModuleList() {
		Debug.Log("ModuleListPrint: ");
		Debug.Log("module0: " + moduleList[0].name);
		Debug.Log("module1: " + moduleList[1].name);
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
		//glueing stock to receiver:
		this.checkIdentifiersInList();
		/*
		Debug.Log("module[0]Pos: " + moduleList[0].GetComponentInChildren<wgentest>().transform.position);
		Debug.Log("module[1]Pos: " + moduleList[1].GetComponentInChildren<wgentest>().transform.position);
		Vector3 vulcrumsDeltaPosition = moduleList[0].GetComponentInChildren<wgentest>().transform.position;
		vulcrumsDeltaPosition -= moduleList[1].GetComponentInChildren<wgentest>().transform.position;
		Debug.Log("deltaPos: " + vulcrumsDeltaPosition);
		
		moduleList[1].transform.position += Vector3.up * 1.5f;
		
		*/
		
		Vector3 targetModulePosition = new Vector3(-10,-10,-10);
		Vector3 targetModuleForwardDirection = new Vector3(-10,-10,-10);
		
		WGIdentifier [] components = moduleList[0].GetComponentsInChildren<WGIdentifier>();
		
		foreach (WGIdentifier component in components) {
			if (component.objectType == WGIdentifierEnum.moduleVulcrum
						&& component.module == WGModuleEnum.stock) {
						
				Debug.Log("FOUND APPROPRIATE VULCRUM!");
				targetModulePosition = component.transform.position;
				targetModuleForwardDirection = component.transform.forward;	
			}
		}
		
		
		if(moduleList[1].GetComponent<WGIdentifier>() 
				&& moduleList[1].GetComponent<WGIdentifier>().objectType == WGIdentifierEnum.moduleGroup) {
					
			Debug.Log("modulelist[1] is indeed ModuleGroup, moving...");
			moduleList[1].transform.position = targetModulePosition;
			moduleList[1].transform.forward = moduleList[1].transform.forward;
		}
		
	}
}
