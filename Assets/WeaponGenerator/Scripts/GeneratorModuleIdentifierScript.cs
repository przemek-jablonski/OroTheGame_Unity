using UnityEngine;
using System.Collections;

public class GeneratorModuleIdentifierScript : MonoBehaviour {

	public enum ModuleIdentifier {
		receiver, 
		stock, 
		grip,
		trigger,
		mag, 
		handguard,
		handguardAttachment,
		barrel,
		muzzle,
		sights,
		none
	};
	
	public ModuleIdentifier moduleIdentifier = ModuleIdentifier.none;
	
	public ModuleIdentifier getModuleIdentifier() {
		return this.moduleIdentifier;
	}
	
	
}
