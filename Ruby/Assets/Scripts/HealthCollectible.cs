using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{	

	public AudioClip gCollectedClip;

	void OnTriggerEnter2D( Collider2D iOther )
	{
		RubyController gController = iOther.GetComponent<RubyController>();
		
		if ( gController != null )
		{
			if ( gController.gHealth < gController.cMaxHealth )
			{
				gController.ChangeHealth(1);
				Destroy(gameObject);
				gController.PlaySound( gCollectedClip );
			}

		}
		
	}
}
