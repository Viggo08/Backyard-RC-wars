using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Rake")] 
    [SerializeField] int RakeAmount;
    [SerializeField] GameObject Rake;

    [Header("Broom")]
    [SerializeField] int BroomAmount;
    [SerializeField] GameObject Broom;

    [Header("BuildingBlock")]
    [SerializeField] int BuildingBlockAmount;
    [SerializeField] GameObject BuildingBlock;

    [Header("ActionFigure")]
    [SerializeField] int ActionFigureAmount;
    [SerializeField] GameObject ActionFigure;

    [SerializeField] int minMapSize;
    [SerializeField] int maxMapSize;

    [SerializeField] Transform parentobject;

    Vector3[] forbiddenPositions;
    void Start()
    {
        spawnAllObjects();
    }

    void Update()
    {
        
    }

    void spawnAllObjects()
    {
        SpawnRake();
        SpawnBroom();
    }
    void SpawnRake()
    {
        for (int i = 0; i < RakeAmount; i++)
        {
            Instantiate(Rake,  new Vector3(Random.Range(minMapSize, maxMapSize), 1, Random.Range(minMapSize, maxMapSize)), Quaternion.identity,parentobject);
        }
    }

    void SpawnBroom()
    {
        for (int i = 0; i < BroomAmount; i++)
        {
            Instantiate(Broom, new Vector3(Random.Range(minMapSize, maxMapSize), 1, Random.Range(minMapSize, maxMapSize)), Quaternion.identity,parentobject);
        }
    }
    void SpawnBuildingBlock()
    {
        for (int i = 0; i < BuildingBlockAmount; i++)
        {
            Instantiate(BuildingBlock, new Vector3(Random.Range(minMapSize, maxMapSize), 1, Random.Range(minMapSize, maxMapSize)), Quaternion.identity);
        }
    }

    void SpawnObjects1()
    {
        for (int i = 0; i < ActionFigureAmount; i++)
        {
            Instantiate(ActionFigure,new Vector3(Random.Range(minMapSize, maxMapSize), 1, Random.Range(minMapSize, maxMapSize)), Quaternion.identity);
        }
    }
}
