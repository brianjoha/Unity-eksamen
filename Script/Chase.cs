using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{

    public bool shouldChase = true;
    private NavMeshAgent agent;
    public GameObject target;
    public bool isInLateUpdate = false;
    public bool shouldUpdate = true;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    IEnumerator distUpdateCo = null;

    // Update is called once per frame
    void Update()
    {

        if (!shouldUpdate) return;
        {
            float distance = GetActualDistanceFromTarget();

            if (distance <= 20f)
            {
                if (distUpdateCo != null)
                {
                    StopCoroutine(distUpdateCo);
                }

                isInLateUpdate = false;
                agent.destination = target.transform.position;
            }

            else if (!isInLateUpdate)
            {
                if (distance <= 40f)
                {
                    distUpdateCo = LateDistanceUpdate(2f);
                    StartCoroutine(distUpdateCo);
                }
                else if (distance <= 60)
                {
                    distUpdateCo = LateDistanceUpdate(3f);
                    StartCoroutine(distUpdateCo);
                }
                else if (distance <= 80)
                {
                    distUpdateCo = LateDistanceUpdate(4f);
                    StartCoroutine(distUpdateCo);
                }
                else
                {
                    distUpdateCo = LateDistanceUpdate(5f);
                    StartCoroutine(distUpdateCo);
                }
            }
        }
    }

    IEnumerator LateDistanceUpdate(float duration)
    {
        isInLateUpdate = true;
        agent.destination = target.transform.position;
        yield return new WaitForSeconds(duration);

        isInLateUpdate = false;
        distUpdateCo = null;
        yield break;
    }

    float GetActualDistanceFromTarget()
    {
        return GetDistanceFrom(target.transform.position, this.transform.position);
       
    }
    float GetDistanceFrom(Vector3 src, Vector3 dist)
    {
        return Vector3.Distance(src, dist);
    }

}
