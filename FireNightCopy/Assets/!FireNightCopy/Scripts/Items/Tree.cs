using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : PickableObject
{
    public override PickableObject Pick(Transform hands)
    {
        rigidbody.isKinematic = false;
        return null;
    }
}
