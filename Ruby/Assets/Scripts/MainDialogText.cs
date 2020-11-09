using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainDialogText : MonoBehaviour
{
	
	public static MainDialogText instance { get; private set; }
	
	TextMeshProUGUI gTMP;
	
	string gText;

	// Global display time for all dialog
	// User can use different value if they really want to
	public float pDisplayTime = 4.0f; 

    void Awake()
    {
        instance = this;
		gText = "deadbeef";
		gTMP = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Start()
    {
        // No text to start
    }
	
	void Update()
	{

	}
	
	public void SetText( string iText )
	{
		gText = iText;
		ReplaceText();
	}
	
	void ReplaceText()
	{
		gTMP.SetText( gText );
	}
	
}
