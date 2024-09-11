using UnityEngine;

public class Opdracht1 : MonoBehaviour
{
    public GameObject preFab;

    private float elapsedTime = 0f;

    private void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            CreateBall(RandomColor(), RandomPosistion());
        }
    }

    public void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > 1f)
        {
            CreateBall(RandomColor(), RandomPosistion());
            elapsedTime = 0f;
        }
    }

        
    private Vector3 RandomPosistion()
    {
        Vector3 vec = new Vector3();
        vec.y = Random.Range(0, 100);
        vec.x = Random.Range(0, 100);
        vec.z = Random.Range(0, 100);

        return vec;
    }


    private void CreateBall(Color color, Vector3 posistion)    
    {
        GameObject ball = Instantiate(preFab);
        Material material = ball.GetComponent<MeshRenderer>().material;
        material.SetColor("_Color", color);
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
