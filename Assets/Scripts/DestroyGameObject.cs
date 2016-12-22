using UnityEngine;
using System.Collections;

public class DestroyGameObject : MonoBehaviour {

	void OnLevelWasLoaded(int level){
		if (level > 0)
			Destroy (gameObject);
	}
	
}
