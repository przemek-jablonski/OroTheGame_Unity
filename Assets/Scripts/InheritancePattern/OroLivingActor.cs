using UnityEngine;
using System.Collections;

//LIVINGACTOR
//LivingActor is a type of actor that is 'living' in the world
//in sense that it must have its health and stuff that can make him die due to damage
public abstract class OroLivingActor : OroActor, IDamageable {
	
	public float		startHealth;
	protected float		actualHealth;
	protected bool		isDead;
	
	private Color		previousColor;
	private Color		previousEmissionColor;

	public virtual void Start () {
		Debug.Log("OroLivingActor Start() called.");
		isDead = false;
		actualHealth = startHealth;
	}

	//float damage is absolute value of damage that has been dealt to Actor
	//(that is no -10 hp of damage, but 10 hp, since health is -= damage)
	public void Hit(float damage) {
		Debug.Log("OroLivingActor HitBehaviour() called.");
		if(damage < 0) return;
		actualHealth -= damage;
		/*
		string text = "LivingActor is HIT (had: " + actualHealth +
						"hp, damage dealt: " + damage;
		text += "hp, now: " + actualHealth + "hp).";
		Debug.Log(text);
		*/
		HitBehaviour();
		StartCoroutine(redTintFlash());
		
		if(actualHealth < 0) {
			Die(this.gameObject);
		}
		
	}
	
	public abstract void HitBehaviour();
	
	public abstract void DeathBehaviour();
	
	public void Die(GameObject gameObject){
		DeathBehaviour();
		isDead = true;
		Destroy(this.gameObject);
	}
	
	IEnumerator redTintFlash() {
		previousColor = gameObject.GetComponent<Renderer>().material.GetColor("_Color");
		previousEmissionColor = gameObject.GetComponent<Renderer>().material.GetColor("_EmissionColor");
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
		gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.8f, 0.1f, 0.1f));
		yield return new WaitForSeconds(.07f);
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", previousColor);
		gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", previousEmissionColor);
	}
	
}
