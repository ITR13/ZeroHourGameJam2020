using UnityEngine;

public class CannonBallScript : MonoBehaviour
{
    [SerializeField] private Renderer renderer;
    public void Update()
    {
        if (renderer.isVisible) return;

        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x > 0.9f * Screen.width)
        {
            ScoreCounter.Increase(ScoreCounter.Direction.Right);
        }
        else if (screenPos.x < 0.1f * Screen.width)
        {
            ScoreCounter.Increase(ScoreCounter.Direction.Left);
        }
        else if (screenPos.y > 0.9f * Screen.height)
        {
            ScoreCounter.Increase(ScoreCounter.Direction.Top);
        }
        else if (screenPos.y < 0.1f * Screen.height)
        {
            ScoreCounter.Increase(ScoreCounter.Direction.Bottom);
        }

        Destroy(gameObject);
    }
}
