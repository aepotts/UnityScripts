using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
	void OnTriggerStay2D( Collider2D iOther )
	{
		RubyController gController = iOther.GetComponent<RubyController>();
		
		if ( gController != null )
		{
			gController.ChangeHealth(-1);
			Debug.Log( gController.gHealth );
		}
	}
}
