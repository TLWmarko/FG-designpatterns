using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
	public MeshRenderer blinkRenderer;

	public MineStateDetect detectState;
	public MineStateIdle idleState;
	public MineStateAttack attackState;
	
    // Start is called before the first frame update
    void Start()
    {
		detectState.blinkMat = blinkRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
