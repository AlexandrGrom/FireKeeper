using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private ParticleSystem fire;

    private int maxFireHP = 100;

    private void Awake()
    {
        StartCoroutine(FireLife());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickableObject pickableObject))
        {
            pickableObject.Burn();
        }
    }


    private float ConertIntToPecent(int BaseFloat) => (float)BaseFloat / 100;
    private Vector3 Scale(int baseInt)
    {
        Vector3 returnVector = Vector3.one * ConertIntToPecent(baseInt);
        returnVector.y *= returnVector.y;
        return returnVector;
    }

    Vector3 reference;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            maxFireHP += 5;
        }
        fire.transform.localScale = Vector3.Lerp(fire.transform.localScale, Scale(maxFireHP), Time.deltaTime);

    }

    IEnumerator FireLife()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            maxFireHP--;
            print(maxFireHP);
        }
    }
}
