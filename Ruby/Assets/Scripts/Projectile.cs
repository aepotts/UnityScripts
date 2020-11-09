using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	Rigidbody2D gRigidbody2D;
	
    // Start is called before the first frame update
    void Awake()
    {
        gRigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	public void Launch( Vector2 iDirection, float iForce )
	{
		gRigidbody2D.AddForce( iDirection * iForce );
	}

	void OnCollisionEnter2D( Collision2D iOther )
	{
		EnemyController eControl = iOther.collider.GetComponent<EnemyController>();
		
		if( eControl != null )
		{
			eControl.Fix();
		}
		
		Destroy( gameObject );
	}

    // Update is called once per frame
    void Update()
    {
		if ( transform.position.magnitude > 1000.0f )
		{
			Destroy( gameObject );
		}
    }	
}
