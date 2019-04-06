using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCoin : Pickups
{
    private float _speedBoost = 2f;

    public override void PickupEffect()
    {
        GameController.Instance.Player.Speed += _speedBoost;
        Destroy(gameObject);
    }
}
