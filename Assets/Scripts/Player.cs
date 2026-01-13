using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;
    [SerializeField] private Rigidbody2D _rigidbody;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        _numSeedsLeft = _numSeeds;
        _numSeedsPlanted = 0;

        _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector2(
            Input.GetAxis("Horizontal") * _speed,
            Input.GetAxis("Vertical") * _speed
        );

        if (Input.GetKeyDown(KeyCode.Space)) {
           PlantSeed();
        }
   
   }

    public void PlantSeed ()
    {
        if (_numSeedsLeft > 0) {
            Instantiate(_plantPrefab, _playerTransform.position, Quaternion.identity); 
            _numSeedsPlanted += 1;
            _numSeedsLeft -= 1;
            _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
        }
    }
}
