using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
	// Dialog
	public DialogDataScriptableObject gDialogOptions;
	string gOutputText;
	
	public GameObject pDialogBox;
	public GameObject pDialogIcon;
	
	public float pDisplayTime = 4.0f;
	float gTimerDisplay;
	
	public string gCharacter;				// Defined in MainDialogIcon.cs //
	string gOutputIcon;						// For now, these should be the same
	
    // Start is called before the first frame update //
    void Start()
    {
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
    }
	
	public void DisplayDialog()
	{
		// Has to be down here or the array will not have been created yet I think
		int tText = 0;
		gOutputText = gDialogOptions.GetDialogText( gCharacter, tText );
		gOutputIcon = gCharacter;
		
		gTimerDisplay = pDisplayTime;
		SetDialogActive( true );
		SendDialog();
	}
	
	// Call this to update what to send to the dialog box when it's ready
	void SetOutputText( string iText )
	{
		gOutputText = iText;
	}

	// Once dialog box is ready to be called, set the dialog box text to gOutputText
	void SendDialog()
	{
		MainDialogText.instance.SetText( gOutputText );
		MainDialogIcon.instance.SetIcon( gOutputIcon );
	}
	
	void SetDialogActive( bool iState )
	{
		pDialogBox.SetActive( iState );
		pDialogIcon.SetActive( iState );
	}
}
