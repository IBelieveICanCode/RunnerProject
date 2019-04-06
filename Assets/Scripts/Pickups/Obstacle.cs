using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Pickups
{
    public override void PickupEffect()
    {
        GameController.Instance.GameOver?.Invoke();
    }
}
