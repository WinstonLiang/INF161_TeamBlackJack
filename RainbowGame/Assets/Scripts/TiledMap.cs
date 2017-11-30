using UnityEngine;

public class TiledMap : MonoBehaviour
{
    public PhysicMaterial platforms;
    public GameObject cam;
    public GameObject coin;

    void Awake()
    {
        addBoxCollidersToTiles();
    }

    private void addBoxCollidersToTiles()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform tiles in child.transform) //Looking for Tiles or Coins.
            {
                string name = tiles.name;

                if (tiles.name == "Tiles" || tiles.name == "Tiles2")
                {
                    var collider = tiles.gameObject.AddComponent<BoxCollider>();
                    collider.material = platforms;
                    collider.center = new Vector3(collider.center.x, collider.center.y, collider.center.z + 3.5f);
                    collider.size = new Vector3(collider.size.x, collider.size.y, 7f);
                }
                if (tiles.name == "TileObject") //Indicating coins.
                {
                    Debug.Log("Creating Coin");
                    Vector3 pos = tiles.transform.position;
                    pos.x += 1f;
                    pos.y += 1f;
                    pos.z += 1f;
                    GameObject newCoin = Instantiate(coin, pos, new Quaternion(0, 0, 0, 0));
                    newCoin.GetComponent<CoinBehavior>().player_camera = cam;
                }
            }
        }
    }
}
