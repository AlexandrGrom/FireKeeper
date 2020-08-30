using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PickableObject : MonoBehaviour
{
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
}
