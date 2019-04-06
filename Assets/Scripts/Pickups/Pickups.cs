using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickups : MonoBehaviour
{
    public virtual void OnTriggerEnter(Collider col)
    {
        if (GameController.Instance.Player.ReturnCollider() != null)
            PickupEffect();
    }

    public abstract void PickupEffect();
}
