using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PickableObject : MonoBehaviour
{
    [SerializeField] protected ParticleSystem sparkles;
    protected Rigidbody rigidbody;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public virtual void Relise() 
    {
        rigidbody.isKinematic = false;
        transform.SetParent(null, true);
    }
    public abstract void Pick(Transform hands);

    public virtual void Burn()
    {
        Instantiate(sparkles, transform.position, Quaternion.identity);
        transform.localScale = Vector3.zero;
    }
}
