using UnityEngine;

public class Branch : PickableObject , IBurnable
{
    [SerializeField] private ParticleSystem sparkles;

    public void Burn()
    {
        Instantiate(sparkles, transform.position, Quaternion.identity);
        transform.localScale = Vector3.zero;
    }

    public override PickableObject Pick(Transform hands)
    {
        rigidbody.isKinematic = true;
        transform.position = hands.position;
        transform.SetParent(hands, true);
        return this;
    }

    public override void Relise()
    {
        base.Relise();
    }


}
