using UnityEngine;

public class Hands : MonoBehaviour
{
    [SerializeField] private float handsRadius;
    //[SerializeField] private LayerMask mask; // to selec pickble ojects
    //or better use interface ipickable
    //alsov can be bug if object no hawe rb

    private PickableObject objectInHand;


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
            for (int i = 0; i < inGrabTrigger.Length; i++)
            {
                if (inGrabTrigger[i].TryGetComponent(out objectInHand) )
                {
                    objectInHand = objectInHand.Pick(transform);
                    break;
                }
            }
        }
    }

    private void Relise()
    {
        objectInHand.Relise();
        objectInHand = null;
    }


    private void Update()
    {
        print(objectInHand?.name);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, handsRadius);
    }
}
