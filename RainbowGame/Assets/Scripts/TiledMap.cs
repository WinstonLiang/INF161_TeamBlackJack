using UnityEngine;

public class TiledMap : MonoBehaviour
{
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
                    collider.size = new Vector3(collider.size.x, collider.size.y, 20.0f);
                }
            }
        }
    }
}
