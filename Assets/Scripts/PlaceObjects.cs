using UnityEngine;
public class PlaceObjects : MonoBehaviour
{
    public LayerMask layer;
    public float rotateSpeed = 60f;

    private Collider _collider;
    private bool _isPlacing = false;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        PositionObject();
    }

    private void Update()
    {
        PositionObject();

        if (Input.GetMouseButtonDown(0))
        {
            PlaceObject();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _collider.enabled = true;
        }

        if (_isPlacing)
        {
            _collider.enabled = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }

    private void PositionObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f, layer))
            transform.position = hit.point;
        _isPlacing = true;
    }

    public void PlaceObject()
    {
        CarCreate CarCreateComponent = gameObject.GetComponent<CarCreate>();

        if (CarCreateComponent != null)
        {
            CarCreateComponent.enabled = true;
        }

            _isPlacing = false;

        _collider.enabled = true;

        Destroy(this);

        GameSystem gameSystem = FindObjectOfType<GameSystem>();
        if (gameSystem != null)
        {
            gameSystem.playerCount++;
        }
    }
}