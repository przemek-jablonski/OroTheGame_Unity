using UnityEngine;

public interface IDamageable {
	
	void Hit (float damageValue);
	
	void Die (GameObject gameObject);
}
