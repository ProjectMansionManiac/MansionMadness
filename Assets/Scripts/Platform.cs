using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    BoxCollider2D col;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }
	void Update () {
		
	}
}
