using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [SerializeField] CheckPoint[] checkPoints = null;
 
    public void SetBreadPos(int index)
    {
        Vector3 spawnPos = checkPoints[index].transform.position + new Vector3(0f, 1f, 0f);

        // FindObjectOfType<BreadPlayer>().transform.position = spawnPos; // 왜 이 라인만 실행이 안 되는가
    }

    public Vector3 GetBreadPos(int index)
    {
        Vector3 spawnPos = checkPoints[index].transform.position + new Vector3(0f, 1f, 0f);

        return spawnPos;
    }
}
