using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
	public float gSpeed = 3.0f;
	
	public int cMaxHealth = 5;
	
	public GameObject pProjectilePrefab;
	
	public int gHealth { get { return gCurrentHealth; } }
	int gCurrentHealth;
	
	public float cTimeInvincible = 2.0f;
	bool gIsInvincible;
	float gInvincibleTimer;
	
	public AudioClip pCogThrowClip;
	public AudioClip pPlayerHitClip;
	
	AudioSource gAudioSource;
	
	Rigidbody2D gRigidbody2d;
    float gHorizontal;
    float gVertical;
	
	Animator gAnimator;
	Vector2 gLookDirection = new Vector2( 1,0 );
	
	bool gActionBlockedState;
	
    void Start()
    {
		// Get componentets from game object
        gRigidbody2d = GetComponent<Rigidbody2D>();
		gAnimator = GetComponent<Animator>();
		gCurrentHealth = cMaxHealth;
		
		gAudioSource = GetComponent<AudioSource>();
		
		SetActionBlocked( false );
    }
	
	public void PlaySound( AudioClip iClip )
	{
		gAudioSource.PlayOneShot( iClip );
	}
	
	
	// These 2 are for blocking/unblocking character actions like move or attack
	public void SetActionBlocked( bool iActionState )
	{
		gActionBlockedState = iActionState;
	}
	
	public bool GetActionBlocked()
	{
		return gActionBlockedState;
	}

    // Update is called once per frame
    void Update()
    {
        // Get Input
        gHorizontal = Input.GetAxis( "Horizontal" );
        gVertical = Input.GetAxis( "Vertical" );
		
		Vector2 move = new Vector2( gHorizontal, gVertical );
		
		// Talk action
		if ( Input.GetKeyDown( KeyCode.X ) )
		{
			RaycastHit2D tHit = Physics2D.Raycast( gRigidbody2d.position + Vector2.up * 0.2f, gLookDirection, 1.5f, LayerMask.GetMask( "NPC" ) );
			if ( tHit.collider != null )
			{
				Debug.Log( "Raycast has hit the object " + tHit.collider.gameObject );
				if ( tHit.collider != null )
				{
					NonPlayerCharacter tCharacter = tHit.collider.GetComponent<NonPlayerCharacter>();
					if ( tCharacter != null )
					{
						tCharacter.DisplayDialog();
					}
				}
			}
		}
		
		if ( !Mathf.Approximately( move.x, 0.0f ) || !Mathf.Approximately( move.y, 0.0f ) )
		{
			gLookDirection.Set(move.x, move.y);
			gLookDirection.Normalize();
			
		}
		
		gAnimator.SetFloat("Look X", gLookDirection.x);
		gAnimator.SetFloat("Look Y", gLookDirection.y);
		gAnimator.SetFloat("Speed", move.magnitude);
		
		if ( gIsInvincible )
		{
			gInvincibleTimer -= Time.deltaTime;
			if ( gInvincibleTimer < 0 )
				gIsInvincible = false;
		}
		
		if ( Input.GetKeyDown( KeyCode.C ) )
		{
			Launch();
			PlaySound( pCogThrowClip );
		}
    }

    void FixedUpdate()
    {
        Vector2 tPosition = gRigidbody2d.position;

		if( gActionBlockedState )
		{
			// If action is blocked, don't move
		}
		else
		{
			tPosition.x = tPosition.x + ( gSpeed * gHorizontal * Time.deltaTime );
			tPosition.y = tPosition.y + ( gSpeed * gVertical* Time.deltaTime );
		}
		
		// Keep this here for idle animation to happen if action is blocked
        gRigidbody2d.MovePosition(tPosition);
    }
	
	public void ChangeHealth( int iAmount )
	{
		if ( iAmount < 0 )
		{

			gAnimator.SetTrigger("Hit");
			if ( gIsInvincible )
				return;
			else
				PlaySound( pPlayerHitClip );
			
			gIsInvincible = true;
			gInvincibleTimer = cTimeInvincible;
		}
		
		gCurrentHealth = Mathf.Clamp( gCurrentHealth + iAmount, 0, cMaxHealth );
		UIHealthBar.instance.SetValue( gCurrentHealth / ( float ) cMaxHealth ); 
	}
	
	void Launch()
	{
		GameObject tProjectileObject = Instantiate( pProjectilePrefab, gRigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity );
		
		Projectile tProjectile = tProjectileObject.GetComponent<Projectile>();
		tProjectile.Launch( gLookDirection, 300 );
		
		gAnimator.SetTrigger( "Launch" ); 
	}
}
