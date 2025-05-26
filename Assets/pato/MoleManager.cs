using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class MoleManager : MonoBehaviour
{
    public GameObject[] moles;
    public float minDelay = 3f;
    public float maxDelay = 7f;

    private Vector3[] originalPositions;

    private void Start()
    {
        originalPositions = new Vector3[moles.Length];

        for (int i = 0; i < moles.Length; i++)
        {
            originalPositions[i] = moles[i].transform.position;
            StartCoroutine(MoveMole(moles[i], originalPositions[i]));
        }
    }

    IEnumerator MoveMole(GameObject mole, Vector3 originalPos)
    {
        while (mole != null)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            if (mole == null) yield break;

            mole.transform.position = new Vector3(originalPos.x, 2.16f, originalPos.z);
            yield return new WaitForSeconds(5f);

            if (mole != null)
                mole.transform.position = originalPos;
        }
    }

    public void MoleHit(GameObject mole)
    {
        for (int i = 0; i < moles.Length; i++)
        {
            if (moles[i] == mole)
            {
                Destroy(moles[i]);
                moles[i] = null;
                break;
            }
        }

        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        foreach (var mole in moles)
        {
            if (mole != null)
                return;
        }
        Debug.Log("Ganaste");
    }
}