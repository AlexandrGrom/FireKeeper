using UnityEngine;

public class TestCube : PickableObject
{
    public override void Pick(Transform hands)
    {
        rigidbody.isKinematic = true;
        transform.position = hands.position;
        transform.SetParent(hands, true);
    }

    public override void Relise()
    {
        base.Relise();
    }
}
