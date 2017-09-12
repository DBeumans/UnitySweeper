using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraStates : MonoBehaviour {
    
    public virtual void Enter()
    {

    }

    public virtual void Leave()
    {

    }

    public abstract void Act();

    public abstract void Reason();
}
