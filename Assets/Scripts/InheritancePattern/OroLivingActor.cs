using UnityEngine;

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
	public void HitBehaviour(float damage, GameObject gameObject) {
		if(damage < 0) return;
		string text = "LivingActor is HIT (had: " + actualHealth +
						"hp, damage dealt: " + damage;
		actualHealth -= damage;
		text += "hp, now: " + actualHealth + "hp).";
		Debug.Log(text);
		
		if(actualHealth < 0) {
			Die(gameObject);
		}
		
	}
	
	private void Die(GameObject gameObject){
		isDead = true;
		Debug.Log("LivingActor DIED");
	}
	
}
