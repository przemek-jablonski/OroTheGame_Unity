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
		Debug.Log("Instantiated (hopefully) Receiver for m16a2");
	}
	
	public void GenerateStock() {
		moduleList.Add(
						Instantiate(Resources.Load("WeaponGeneratorResources/Prefabs/Stocks/stock_nostock"),
						transform.position,
						Quaternion.identity) as GameObject);
		Debug.Log("Instantiated Stock (nostock)");
	}
	
	public void accessModuleList() {
		Debug.Log("ModuleListPrint: ");
		Debug.Log("module0: " + moduleList[0].name);
		Debug.Log("module1: " + moduleList[1].name);
	}
	
	public void GlueStockReceiver() {
		Debug.Log("module[0]Pos: " + moduleList[0].GetComponentInChildren<wgentest>().transform.position);
		Debug.Log("module[1]Pos: " + moduleList[1].GetComponentInChildren<wgentest>().transform.position);
		Vector3 vulcrumsDeltaPosition = moduleList[0].GetComponentInChildren<wgentest>().transform.position;
		vulcrumsDeltaPosition -= moduleList[1].GetComponentInChildren<wgentest>().transform.position;
		Debug.Log("deltaPos: " + vulcrumsDeltaPosition);
		
		moduleList[1].transform.position += Vector3.up * 1.5f;
		
	}
}
