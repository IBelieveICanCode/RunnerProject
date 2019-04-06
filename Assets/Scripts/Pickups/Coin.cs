using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin: Pickups
{
    [SerializeField]
    private float _score = 10f;

    public override void PickupEffect()
    {
        GameController.Instance.Player.Scores += _score;
        Destroy(gameObject);
    }
}
