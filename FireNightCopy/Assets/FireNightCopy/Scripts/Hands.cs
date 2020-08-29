using UnityEngine;

public class Hands : MonoBehaviour
{
    [SerializeField] private float handsRadius;
    //[SerializeField] private LayerMask mask; // to selec pickble ojects
    //or better use interface ipickable
    //alsov can be bug if object no hawe rb

    private Rigidbody objectInHand;


    public void UseHands()
    {
        if (objectInHand == null) Grab();
        else Relise();
    }

    private void Grab()
    {
        Collider[] inGrabTrigger = Physics.OverlapSphere(transform.position, handsRadius);
        if (inGrabTrigger.Length > 0)
        {
            Rigidbody target = inGrabTrigger[0].attachedRigidbody;
            print(target.name);
            objectInHand = target;
            objectInHand.isKinematic = true;
            objectInHand.transform.position = transform.position;
            objectInHand.transform.SetParent(transform,true);
        }
    }

    private void Relise()
    {
        objectInHand.transform.SetParent(null , true);
        objectInHand.isKinematic = false;
        objectInHand = null;
    }



    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, handsRadius);
    }
}
