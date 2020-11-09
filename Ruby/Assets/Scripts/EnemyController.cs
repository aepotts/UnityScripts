using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public float gSpeed;
	public bool gVertical;
	public float cChangeTime = 3.0f;
	public ParticleSystem pSmokeEffect;
	
	Rigidbody2D gRigidbody2D;
	float gTimer;
	int gDirection = 1;
	bool gBroken = true;
	
	Animator gAnimator;
	
    // Start is called before the first frame update
    void Start()
    {
		gRigidbody2D = GetComponent<Rigidbody2D>();
		gTimer = cChangeTime;
		gAnimator = GetComponent<Animator>();
    }

	void Update()
	{
		if( !gBroken )
		{
			return;
		}
		
		gTimer -= Time.deltaTime;
		
		// Change direction when timer runs out //
		if ( gTimer < 0 )
		{
			gDirection = -gDirection;
			gTimer = cChangeTime;
		}
	}

    void FixedUpdate()
    {
		if( !gBroken )
		{
			return;
		}
		
		Vector2 tPosition = gRigidbody2D.position;
		
		if ( gVertical )
		{
			tPosition.y = tPosition.y + ( Time.deltaTime * gSpeed * gDirection );
			gAnimator.SetFloat("Move X", 0);
			gAnimator.SetFloat("Move Y", gDirection);
		}
		else
		{
			tPosition.x = tPosition.x + Time.deltaTime * gSpeed * gDirection;
			gAnimator.SetFloat( "Move X", gDirection );
			gAnimator.SetFloat( "Move Y", 0 );
		}
		
		gRigidbody2D.MovePosition(tPosition);
    }
	
	void OnCollisionEnter2D( Collision2D iOther )
	{
		RubyController tPlayer = iOther.gameObject.GetComponent<RubyController>();
		
		if ( tPlayer != null )
		{
			tPlayer.ChangeHealth(-1);
		}	
	}
	
	public void Fix()
	{
		gBroken = false;
		gRigidbody2D.simulated = false;
		
		gAnimator.SetTrigger( "Fixed" );
		pSmokeEffect.Stop();
	}
}
