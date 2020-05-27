using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Machine : MonoBehaviour
{
    public bool isActive;
    public bool isBroken;
    public abstract void Action(ActionButtons btn);
    public virtual void JoystickRotation(ActionButtons btn, int index) { }

    public virtual void Break()
    {
        isBroken = true;
    }
}
