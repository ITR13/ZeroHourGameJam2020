using UnityEngine;

public class ShootBall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ballPrefab;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float minForce, maxForce;

    private float ballTimer, ballTimerMax;
    private int pauseCounter, pauseCounter2, pauseCounterMax;

    private void Start()
    {
        ballTimer = 0;
        ballTimerMax = 5;
        pauseCounter = 0;
        pauseCounter2 = 0;
        pauseCounterMax = 3;
    }

    private void Update()
    {
        ballTimer += Time.deltaTime;
        if (ballTimer < ballTimerMax) return;
        ballTimer -= ballTimerMax;
        ballTimerMax *= 0.98f;
        Shoot();

        if (ballTimerMax > 1.5f) return;
        if (ballTimerMax < 0.6f) ballTimerMax = 0.6f;

        pauseCounter++;
        if (pauseCounter <= pauseCounterMax) return;
        pauseCounter -= pauseCounterMax;
        pauseCounter2++;
        ballTimer -= 2.5f;

        if (pauseCounter2 <= pauseCounterMax) return;
        pauseCounter2 -= pauseCounterMax;
        pauseCounterMax++;
    }


    private void Shoot()
    {
        var ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
        ball.AddRelativeForce(new Vector2(Random.Range(minForce, maxForce), 0), ForceMode2D.Impulse);
    }
}
