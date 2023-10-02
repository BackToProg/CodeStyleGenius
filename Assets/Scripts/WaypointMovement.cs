using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;

    private Transform[] _movementPoints;
    private int _currentPoint;

    private void Start()
    {
        _movementPoints = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _movementPoints[i] = _path.GetChild(i).transform;
        }
    }
    
    private void Update()
    {
        Transform target = _movementPoints[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _movementPoints.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}