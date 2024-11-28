using UnityEngine.UI;
using UnityEngine;

public class ButtonPlaceBuild : MonoBehaviour
{
    public GameObject building;
    public Interface bricksSystem;
    public void PlaceBuild()
    {
        if (bricksSystem.bricks >= 10f)
        {
            Instantiate(building, Vector3.zero, Quaternion.identity);
            bricksSystem.bricks -= 10f;
        }
        else
        {
            Debug.Log("There are not enough bricks...");
        }
    }
}
