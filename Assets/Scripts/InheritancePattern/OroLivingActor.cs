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

	public void HitBehaviour(float damage) {
		actualHealth -= damage;
		
		if(actualHealth < 0 && !isDead) {
			Die();
		}
		
	}
	
	private void Die(){
		isDead = true;
		Debug.Log("LivingActor DIED");
	}
	
}
