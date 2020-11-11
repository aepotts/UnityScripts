using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu( fileName = "Data", menuName = "ScriptableObjects/DialogDataScriptableObject", order = 1)]

public class DialogDataScriptableObject : ScriptableObject
{
	
	int gNumberOfCharacters = 4;

	// Think of a better way to pass in dialog option later //
	public string GetDialogText( string iCharacter, int iDialogOption )
	{
		string[] NameArray = new string[] { "JAMBI", "EVILJAMBI", "OLIVER", "CROW" };
	
		string[][] JaggedQuoteArray = new string[gNumberOfCharacters][];
	
		string[] JambiQuoteArray = new string[] { 
			"Oh dear, the robots are on the fritz again.",
			"Thank you!" 
		};
	
		string[] EvilJambiQuoteArray = new string[] {
			"Hello there, I'm Evil Jambi.",
			"Good bye."
		};
		
		string[] OliverQuoteArray = new string[] {
			"Pleased to meet you. I'm Oliver.",
			"Uh, I mean meow..."
		};
		
		string[] CrowQuoteArray = new string[] {
			"*This crow doesn't seem to be able to talk yet.*",
			"..."
		};
		
		// Build jagged array with different character quote arrays //
		JaggedQuoteArray[0] = JambiQuoteArray;
		JaggedQuoteArray[1] = EvilJambiQuoteArray;
		JaggedQuoteArray[2] = OliverQuoteArray;
		JaggedQuoteArray[3] = CrowQuoteArray;
		
		// Find which array to use from iCharacter
		int tIndex = Array.IndexOf( NameArray, iCharacter );

		//return JambiQuoteArray[iDialogOption];
		string oText = JaggedQuoteArray[tIndex][iDialogOption];
		return oText;
	}

}
