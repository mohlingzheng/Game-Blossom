using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerPlayer : MonoBehaviour
{
    public SphereCollider character;
    public SphereCollider blocker;
    
    void Start()
    {
        Physics.IgnoreCollision(character, blocker);
    }
}
