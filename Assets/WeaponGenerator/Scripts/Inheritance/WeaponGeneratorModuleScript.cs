using UnityEngine;
using System.Collections;

public class WeaponGeneratorModuleScript : MonoBehaviour {

	public enum GeneratorObjectType {
		vulcrum,
		weaponModule
	}
	
	public enum ModuleObjectType {
		receiver,
		stock,
		grip,
		trigger,
		mag,
		handguard,
		handguardAttachment,
		sights,
		barrel,
		muzzle
	}
	
	public GeneratorObjectType generatorObjectType;
	public ModuleObjectType moduleObjectType;
	
	

	
}
