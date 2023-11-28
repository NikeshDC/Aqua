using UnityEngine;

public class SpawnObjectPlaceholder : MonoBehaviour
{
    public string SpawnRegionTag = "SpawnRegion";

    public Material spawnableMaterial;
    public Material notSpawnableMaterial;

    bool canSpawn;
    bool isInSpawnableRegion;
    bool isTouchingOtherObject;

    bool prevFrameSpawnValue; //to reduce call to material change procedure

    MeshRenderer[] meshRenderers;

    private void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        canSpawn = false;
        prevFrameSpawnValue = false;
        SetMaterials();
    }

    private void Update()
    {
        CheckIfSpawnable();

        //only if previous frame was different try to change material
        if(canSpawn != prevFrameSpawnValue)
            SetMaterials();
        prevFrameSpawnValue = canSpawn;
    }

    void SetMaterials()
    {
        if (canSpawn)
            foreach (MeshRenderer mr in meshRenderers)
                mr.material = spawnableMaterial;
        else
            foreach (MeshRenderer mr in meshRenderers)
                mr.material = notSpawnableMaterial;
    }

    public bool CanSpawn()
    {
        return canSpawn;
    }
    void CheckIfSpawnable()
    {
        if(isInSpawnableRegion && !isTouchingOtherObject)
            canSpawn = true;
        else
            canSpawn = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == SpawnRegionTag)
            isInSpawnableRegion = true;
        else
            isTouchingOtherObject = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == SpawnRegionTag)
            isInSpawnableRegion = false;
        else 
            isTouchingOtherObject = false;
    }

}
