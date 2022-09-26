using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerEnemy : MonoBehaviour
{
    public BoxCollider character;
    public BoxCollider blocker;

    void Start()
    {
        Physics.IgnoreCollision(character, blocker);
    }
}
