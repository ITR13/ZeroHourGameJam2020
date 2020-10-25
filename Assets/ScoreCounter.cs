using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public enum Direction
    {
        Left, Bottom, Right, Top,
    }
    [SerializeField] private Text[] texts;
    private int[] counts = new int[4];

    private static ScoreCounter instance;

    private void Awake()
    {
        instance = this;
    }

    public static void Increase(Direction dir)
    {
        instance.counts[(int)dir]++;
        instance.texts[(int)dir].text = $"{instance.counts[(int)dir]}";
    }

}
