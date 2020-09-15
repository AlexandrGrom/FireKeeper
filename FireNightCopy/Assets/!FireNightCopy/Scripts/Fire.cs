using System.Collections;
using TMPro;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private ParticleSystem fire;
    [SerializeField] private TextMeshProUGUI loseText;

    private int maxFireHP = 100;

    private void Awake()
    {
        StartCoroutine(FireLife());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IBurnable burnableObject))
        {
            burnableObject.Burn();
            maxFireHP += 5;
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
        fire.transform.localScale = Vector3.Lerp(fire.transform.localScale, Scale(maxFireHP), Time.deltaTime);
    }

    private IEnumerator FireLife()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            maxFireHP--;
            if (maxFireHP <0)
            {
                loseText.gameObject.SetActive(true);
            }
        }
    }
}
