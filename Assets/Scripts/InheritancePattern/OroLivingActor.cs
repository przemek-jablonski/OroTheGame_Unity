using UnityEngine;
using System.Collections;

//LIVINGACTOR
//LivingActor is a type of actor that is 'living' in the world
//in sense that it must have its health and stuff that can make him die due to damage
public class OroLivingActor : OroActor, IDamageable {
	
	public float		startHealth;
	protected float		actualHealth;
	protected bool		isDead;

	public virtual void Start () {
		isDead = false;
		actualHealth = startHealth;
	}

	//float damage is absolute value of damage that has been dealt to Actor
	//(that is no -10 hp of damage, but 10 hp, since health is -= damage)
	public void HitBehaviour(float damage) {
		if(damage < 0) return;
		string text = "LivingActor is HIT (had: " + actualHealth +
						"hp, damage dealt: " + damage;
		actualHealth -= damage;
		text += "hp, now: " + actualHealth + "hp).";
		Debug.Log(text);
		
		StartCoroutine(redTintFlash());
		
		if(actualHealth < 0) {
			Die(this.gameObject);
		}
		
	}
	
	private void Die(GameObject gameObject){
		isDead = true;
		Destroy(this.gameObject);
	}
	
	IEnumerator redTintFlash() {
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
		gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.8f, 0.1f, 0.1f));
		yield return new WaitForSeconds(.07f);
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.6f, 0, 1));
		gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.04f, 0.01f, 0.17f));
	}
	
}
