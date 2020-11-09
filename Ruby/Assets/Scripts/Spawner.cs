using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	    public GameObject gBadGuy;
		
		public SpawnManagerScriptableObject gSpawnManagerValues;
	
		int instanceNumber = 1;
	
    // Start is called before the first frame update
    void Start()
    {
		SpawnEnemies();
    }

	void SpawnEnemies()
	{
		int currentSpawnPointIndex = 0;
		
		for ( int i = 0; i < gSpawnManagerValues.numberOfPrefabsToCreate; i++ )
		{
			// Creates an instance of the prefab at the current spawn point.
			GameObject currentEntity = Instantiate( gBadGuy, gSpawnManagerValues.spawnPoints[ currentSpawnPointIndex ], Quaternion.identity );
			
			// Sets the name of the instantiated entity to be the string defined in the ScriptableObject and then appends it with a unique number. 
            currentEntity.name = gSpawnManagerValues.prefabName + instanceNumber;
			
			// Moves to the next spawn point index. If it goes out of range, it wraps back to the start.
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % gSpawnManagerValues.spawnPoints.Length;
			
			instanceNumber++;
		}
	}

    // Update is called once per frame ////
    void Update()
    {
        
    }
}
