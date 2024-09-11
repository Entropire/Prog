using UnityEngine;

public class Opdracht1 : MonoBehaviour
{
    public GameObject preFab;

    private float elapsedTime = 0f;
    public void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > 1f)
        {
            CreateBall(RandomColor());
            elapsedTime = 0f;
        }
    }

    private void CreateBall(Color c)    
    {
        GameObject ball = Instantiate(preFab);
        Material material = ball.GetComponent<MeshRenderer>().material;
        material.SetColor("_Color", c);
        Destroy(ball, 5);
    }

    private Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        Color randColor = new Color(r, g, b, 1f);

        return randColor;
    }
}
