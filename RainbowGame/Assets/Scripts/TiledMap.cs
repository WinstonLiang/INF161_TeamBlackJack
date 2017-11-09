using UnityEngine;

public class TiledMap : MonoBehaviour
{
    public PhysicMaterial platforms;

    void Awake()
    {
        addBoxCollidersToTiles();
    }

    private void addBoxCollidersToTiles()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform tiles in child.transform)
            {
                if (tiles.name == "Tiles")
                {
                    var collider = tiles.gameObject.AddComponent<BoxCollider>();
                    collider.material = platforms;
                    collider.center = new Vector3(collider.center.x, collider.center.y, collider.center.z - 0.5f);
                    collider.size = new Vector3(collider.size.x, collider.size.y, 1f);
                }
            }
        }
    }
}
