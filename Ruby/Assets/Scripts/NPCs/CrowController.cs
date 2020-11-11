using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowController : NonPlayerCharacter
{
	public float gSpeed;
	public bool gVertical;
	public float cChangeTime = 3.0f;
	
	float gDirectionTimer;
	int gDirection = 1;
	
	Animator gAnimator;
	Rigidbody2D gRigidbody2D;
	
    // Start is called before the first frame update
    void Start()
    {
		gRigidbody2D = GetComponent<Rigidbody2D>();
		gDirectionTimer = cChangeTime;
		gAnimator = GetComponent<Animator>();
		
		SetDialogActive( false );
		gTimerDisplay = -1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( gTimerDisplay >= 0 )
		{
			gTimerDisplay -= Time.deltaTime; 
			
			if ( gTimerDisplay < 0 )
			{
				// I feel like this will be troublesome in the future
				SetDialogActive( false );
			}
		}
		
		gDirectionTimer -= Time.deltaTime;
		
		// Change direction when timer runs out //
		if ( gDirectionTimer < 0 )
		{
			gDirection = -gDirection;
			gDirectionTimer = cChangeTime;
		}
    }
	
	void FixedUpdate()
	{
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
}
