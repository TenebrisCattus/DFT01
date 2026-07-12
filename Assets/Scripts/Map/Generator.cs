using Unity.AI.Navigation;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject Enemy;

    private NavMeshPlus.Components.NavMeshSurface navMeshSurface;

    void Start()
    {
        navMeshSurface = GetComponent<NavMeshPlus.Components.NavMeshSurface>();
        navMeshSurface.BuildNavMesh();
        Instantiate(Enemy, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
