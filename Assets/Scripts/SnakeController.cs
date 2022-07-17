using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    bool ate = false;
    Vector2 dir = Vector2.zero;
    List<Transform> tailTilesList = new List<Transform>();
    float timePassed;
    UIManager uIManager;

    [HideInInspector]
    public static int scoreCount;
    [Range(.08f,.3f)]
    public float stepTime;
    public GameObject tailTilePrefab;
    public AudioClip collectAudio;
    public AudioClip deathAudio;

    Vector2 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        StartCoroutine(Move(stepTime));

    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.Instance.ForceMusicPlay();
        MoveOnMenuDisabled();
        //if (!uIManager.menuEnabled)
        //    KeyMapping();
        timePassed += Time.deltaTime;
    }
    void MoveOnMenuDisabled()
    {
        if (!uIManager.menuEnabled && dir == Vector2.zero)
        {
            dir = Vector2.up;
        }
        else if(uIManager.menuEnabled)
        {
            dir = Vector2.zero;
        }
        else
        {
            KeyMapping();
        }
    }
    IEnumerator Move(float secondsToMove)
    {
        lastPosition = transform.position;
        transform.Translate(dir);
        InsertTailTile(lastPosition);
        yield return new WaitForSeconds(secondsToMove);
        if (dir != Vector2.zero && secondsToMove >.08f)
        {
            if (timePassed >= 15)
            {
                timePassed = 0;
                secondsToMove -= .01f;
            }
        }
        StartCoroutine(Move(secondsToMove));
    }

    void KeyMapping()
    {
        if(transform.position.y != lastPosition.y) 
        { 
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                    dir = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                    dir = -Vector2.right;
            }     
        }
        else if (transform.position.x != lastPosition.x)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                    dir = -Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                    dir = Vector2.up;
            }  
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            AudioManager.Instance.PlaySound(collectAudio);
            scoreCount++;
            ate = true;
            Destroy(collision.gameObject);
            SnakeBodyColorChanger();
        }
        else
        {
            KillSnake();
            uIManager.GameOverScreen();
        }
    }

    void InsertTailTile(Vector2 position)
    {    
        if (ate)
        {
            GameObject g = (GameObject)Instantiate(tailTilePrefab, position, Quaternion.identity);
            tailTilesList.Insert(0, g.transform);
            ate = false;
            
        }
        else if(tailTilesList.Count > 0)
        {
            tailTilesList.Last().position = position;
            tailTilesList.Insert(0, tailTilesList.Last());
            tailTilesList.RemoveAt(tailTilesList.Count - 1);
        }
    }

    void KillSnake()
    {  
        AudioManager.Instance.PlaySound(deathAudio);
        AudioManager.Instance.PlayOnDeath();
        ResetSnake(); 
    }


    void ResetSnake()
    {
        uIManager.menuEnabled = true;
        transform.position = new Vector2(0, 0);
        scoreCount = 0;
        timePassed = 0;
        foreach (var item in tailTilesList)
        {
            Destroy(item.gameObject);
        }
        tailTilesList.Clear();
        dir = Vector2.zero;
    }
    void SnakeBodyColorChanger()
    {
        if (tailTilesList.Count==1)
        {
            tailTilesList.First().gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }


}
