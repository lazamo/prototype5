using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    public GameManager gameManager;
    public ParticleSystem explotionParticle;
    private float minSpeed = 12.0f;
    private float maxSpeed = 18.0f;
    private float maxTorque = 4.0f;
    private float xRange = 4.0f;
    private float ySpawnPos = 6;
    public int pointValue;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetRb.AddForce(Randomforce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());
        transform.position = RandomSpawnPos();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explotionParticle, transform.position, explotionParticle.transform.rotation);
            gameManager.UpdatedScore(pointValue);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad")) 
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }
        
    }

    Vector3 Randomforce() 
    { 
    return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque() 
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos() 
    { 
    return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos);
    }
}
