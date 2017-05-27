using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Prefabs;
    public float Delay = 2.0f;
    public bool Active = true;
    public Vector2 DelayRange = new Vector2(1,2);

	public void Start ()
	{
        ResetDelay();
	    StartCoroutine(EnemyGenerator());
	}

    private IEnumerator EnemyGenerator()
    {
        yield return new WaitForSeconds(Delay);

        if (Active)
        {
            var newTransform = transform;
            GameObjectUtility.Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], newTransform.position);
            ResetDelay();
        }

        StartCoroutine(EnemyGenerator());
    }

    public void ResetDelay()
    {
        Delay = Random.Range(DelayRange.x, DelayRange.y);
    }
}
