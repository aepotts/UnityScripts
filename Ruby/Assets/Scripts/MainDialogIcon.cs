using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* To add a new character:
1. Add the public GameObject <Character>
2. Add your character name in 1 word, all-caps to the list in Awake();
*/

public class MainDialogIcon : MonoBehaviour
{
	
	public static MainDialogIcon instance { get; private set; }
	
	// Add Character GameObjects here
	public GameObject JambiIcon;
	public GameObject EvilJambiIcon;

	Canvas gDialogIcon;
	
	int gCharacterToOutput;

	List<string> gCharacters;
	
    // Start is called before the first frame update
	void Awake()
	{
		instance = this;
		gDialogIcon = GetComponent<Canvas>();
		
		// Add characters here
		gCharacters = new List<string>();
		gCharacters.Add( "JAMBI" );
		gCharacters.Add( "EVILJAMBI" );
	}
	
	void Update()
	{
		
	}
	
	public void SetIcon( string iCharacterName )
	{
		gCharacterToOutput = gCharacters.IndexOf( iCharacterName );
	}
}
