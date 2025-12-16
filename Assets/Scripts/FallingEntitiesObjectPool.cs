using System.Collections.Generic;
using UnityEngine;

public class FallingEntitiesObjectPool : MonoBehaviour
{
    public int fallingJewelsNum;
    public int fallingBoomsNum;

    public float initBoundLeftX;
    public float initBoundRightX;

    public float jewelSpeedFloor;
    public float jewelSpeedCeiling;
    public float boomSpeedFloor;
    public float boomSpeedCeiling;

    [SerializeField]
    private GameObject fallingJewelPrefab;
    [SerializeField]
    private GameObject fallingBoomPrefab;

    private List<GameObject> fallingJewels;
    private List<GameObject> fallingBooms;

    private void Awake()
    {
        fallingJewels = new List<GameObject>();
        fallingBooms = new List<GameObject>();

        for (int fallingJewelIndex = 0; fallingJewelIndex < fallingJewelsNum; fallingJewelIndex++)
        {
            Vector3 newPosition = GenerateEntityStartPosition(transform.position);
            GameObject newFallingJewel = Instantiate(fallingJewelPrefab, newPosition, transform.rotation);
            newFallingJewel.GetComponent<FallingJewel>().SetFallingSpeed(Random.Range(jewelSpeedFloor, jewelSpeedCeiling));
            fallingJewels.Add(newFallingJewel);
        }

        for (int fallingBoomIndex = 0; fallingBoomIndex < fallingBoomsNum; fallingBoomIndex++)
        {
            Vector3 newPosition = GenerateEntityStartPosition(transform.position);
            GameObject newFallingBoom = Instantiate(fallingBoomPrefab, newPosition, transform.rotation);
            newFallingBoom.GetComponent<FallingBoom>().SetFallingSpeed(Random.Range(boomSpeedFloor, boomSpeedCeiling));
            fallingBooms.Add(newFallingBoom);
        }
    }

    private Vector3 GenerateEntityStartPosition(Vector3 basePosition)
    {
        Vector3 generatedPosition = basePosition;
        generatedPosition.x = Random.Range(initBoundLeftX, initBoundRightX);
        return generatedPosition;
    }

    private void ActivateUnusedJewel()
    {
        for (int fallingJewelIndex = 0; fallingJewelIndex < fallingJewelsNum; fallingJewelIndex++)
        {
            if (fallingJewels[fallingJewelIndex].GetComponent<FallingJewel>().GetInUse() == true)
            {
                break;
            }
        }

        for (int fallingJewelIndex = 0; fallingJewelIndex < fallingJewelsNum; fallingJewelIndex++)
        {
            if (fallingJewels[fallingJewelIndex].GetComponent<FallingJewel>().GetInUse() == false)
            {
                fallingJewels[fallingJewelIndex].GetComponent<FallingJewel>().SetInUse(true);
                break;
            }
        }
    }

    private void Update()
    {
        ActivateUnusedJewel();
    }
}
