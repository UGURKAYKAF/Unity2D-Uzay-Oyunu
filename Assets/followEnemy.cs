using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class followEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private Transform target;

    private LineRenderer lineRenderer;
    private float lineSize;


    //public Transform[] enemyPrefap;

    [SerializeField] private Transform[] enemyTransform;
    float squaredClosestDistance = Mathf.Infinity;

    public static int sec;
    LineDrawer line;
    SpriteRenderer sprite;
    private void Start()
    {
        line = new LineDrawer();
        target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        //target = GameObject.Find("Enemy(Clone)).GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        //target = GetClosestEnemy(enemyPrefap);
       
    }

    private void Update()
    {

        findClosestEnemy();
        


        //Debug.Log(direction.x);

    }

    void findClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distancetoEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distancetoEnemy<distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distancetoEnemy;
                closestEnemy = currentEnemy;
            }
        }
        if (Vector2.Distance(this.transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, closestEnemy.transform.position, speed * Time.deltaTime);
        }
        Vector3 direction = target.position - transform.position;
        if (direction.x < 0)
        {

            sprite.flipX = false;

        }
        if (direction.x > 0)
        {
            sprite.flipX = true;
        }
        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
        line.DrawLineInGameView(this.transform.position,closestEnemy.transform.position,Color.red);
        
        line.Destroy();
    }

    public struct LineDrawer
    {
        private LineRenderer lineRenderer;
        private float lineSize;

        public LineDrawer(float lineSize = 0.2f)
        {
            GameObject lineObj = new GameObject("LineObj");
            lineRenderer = lineObj.AddComponent<LineRenderer>();
            //Particles/Additive
            lineRenderer.material = new Material(Shader.Find("Hidden/Internal-Colored"));

            this.lineSize = lineSize;
        }

        private void init(float lineSize = 0.2f)
        {
            if (lineRenderer == null)
            {
                GameObject lineObj = new GameObject("LineObj");
                lineRenderer = lineObj.AddComponent<LineRenderer>();
                //Particles/Additive
                lineRenderer.material = new Material(Shader.Find("Hidden/Internal-Colored"));

                this.lineSize = lineSize;
            }
        }

        //Draws lines through the provided vertices
        public void DrawLineInGameView(Vector3 start, Vector3 end, Color color)
        {
            if (lineRenderer == null)
            {
                init(0.2f);
            }

            //Set color
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;

            //Set width
            lineRenderer.startWidth = lineSize;
            lineRenderer.endWidth = lineSize;

            //Set line count which is 2
            lineRenderer.positionCount = 2;

            //Set the postion of both two lines
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);
        }

        public async void Destroy()
        {
            await Task.Delay(100);
            if (lineRenderer != null)
            {
                UnityEngine.Object.Destroy(lineRenderer.gameObject);
            }
        }
    }
}
