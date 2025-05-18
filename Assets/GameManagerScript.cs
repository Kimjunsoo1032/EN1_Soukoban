using UnityEditor.Timeline;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;  

public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject box1Prefab;
    public GameObject box2Prefab;
    public GameObject box3Prefab;
    public GameObject box4Prefab;
    public GameObject box5Prefab;
    public GameObject box6Prefab;
    public GameObject box7Prefab;
    public GameObject goal1Prefab;
    public GameObject goal2Prefab;
    public GameObject goal3Prefab;
    public GameObject goal4Prefab;
    public GameObject goal5Prefab;
    public GameObject goal6Prefab;
    public GameObject goal7Prefab;
    public GameObject wallPrefab;
    public GameObject clearText;
    public GameObject failText;
    public AudioClip moveSound; 
    public AudioClip goalMatchSound;
    private AudioSource audioSource;
    int[,] map;
    GameObject[,] objectsMap;

    Dictionary<string, bool> matchedGoals = new Dictionary<string, bool>();

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Screen.SetResolution(1280, 720, false);

        clearText.SetActive(false);
        failText.SetActive(false);
        map = new int[,]{ // 16=wall //
        {16,16,16,16,16,16,16,16,16,16,16,16,16},
        {16,0,0,0,0,0,0,0,0,0,0,0,16},
        {16,0,0,10,0,0,9,0,0,0,0,0,16},
        {16,0,0,15,0,0,0,0,0,0,0,0,16},
        {16,0,0,0,3,0,0,0,0,13,0,0,16},
        {16,0,0,8,0,0,1,0,0,6,0,0,16},
        {16,0,0,0,0,0,0,0,0,0,0,0,16},
        {16,0,0,0,5,0,0,0,0,11,0,0,16},
        {16,0,0,0,0,0,14,0,0,0,0,0,16},
        {16,0,0,0,2,0,0,0,0,4,0,0,16},
        {16,0,0,12,0,0,0,7,0,0,0,0,16},
        {16,0,0,0,0,0,0,0,0,0,0,0,16},
        {16,16,16,16,16,16,16,16,16,16,16,16,16},
    };
        objectsMap = new GameObject
        [
            map.GetLength(0),
            map.GetLength(1)
        ];
        //PrintArray();
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    /* GameObject instance =*/
                    objectsMap[y, x] = Instantiate(
                        playerPrefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                }
                if (map[y, x] == 2)
                {
                    objectsMap[y, x] = Instantiate(
                        box1Prefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );

                }
                if (map[y, x] == 3)
                {
                    Instantiate(
                        goal1Prefab, new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                }
                if (map[y, x] == 4)
                {
                    objectsMap[y, x] = Instantiate(
                        box2Prefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );

                }
                if (map[y, x] == 5)
                {
                    Instantiate(
                        goal2Prefab, new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                }
                if (map[y, x] == 6)
                {
                    objectsMap[y, x] = Instantiate(
                        box3Prefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );

                }
                if (map[y, x] == 7)
                {
                    Instantiate(
                        goal3Prefab, new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                }
                if (map[y, x] == 8)
                {
                    objectsMap[y, x] = Instantiate(
                        box4Prefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );

                }
                if (map[y, x] == 9)
                {
                    Instantiate(
                        goal4Prefab, new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                }
                if (map[y, x] == 10)
                {
                    objectsMap[y, x] = Instantiate(
                        box5Prefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );

                }
                if (map[y, x] == 11)
                {
                    Instantiate(
                        goal5Prefab, new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                }
                if (map[y, x] == 12)
                {
                    objectsMap[y, x] = Instantiate(
                        box6Prefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );

                }
                if (map[y, x] == 13)
                {
                    Instantiate(
                        goal6Prefab, new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                }
                if (map[y, x] == 14)
                {
                    objectsMap[y, x] = Instantiate(
                        box7Prefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );

                }
                if (map[y, x] == 15)
                {
                    Instantiate(
                        goal7Prefab, new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                }
                if (map[y, x] == 16)
                {
                    Instantiate(
                        wallPrefab, new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                }
            }
        }
        audioSource = GetComponent<AudioSource>();

        matchedGoals["Goal1"] = false;
        matchedGoals["Goal2"] = false;
        matchedGoals["Goal3"] = false;
        matchedGoals["Goal4"] = false;
        matchedGoals["Goal5"] = false;
        matchedGoals["Goal6"] = false;
        matchedGoals["Goal7"] = false;
    }


    //private void PrintArray()
    //{
    //    string debugText = "";
    //    for (int y = 0; y < map.GetLength(0); y++)
    //    {
    //        for (int x = 0; x < map.GetLength(1); x++)
    //        {
    //            debugText += map[y, x].ToString() + ",";
    //        }
    //        debugText += "\n";
    //    }
    //    Debug.Log(debugText);
    //}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayMoveSound();
            Vector2Int playerIndex = GetPlayerIndex();
            MoveObject(playerIndex, playerIndex + new Vector2Int(1, 0));
            CheckGameState();
            if (IsCleared())
            {
                Debug.Log("clear");
                clearText.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayMoveSound();
            Vector2Int playerIndex = GetPlayerIndex();
            MoveObject(
                playerIndex,
                playerIndex + new Vector2Int(-1, 0));
            CheckGameState();
            if (IsCleared())
            {
                Debug.Log("clear");
                clearText.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayMoveSound();
            Vector2Int playerIndex = GetPlayerIndex();
            MoveObject(
                playerIndex,
                playerIndex + new Vector2Int(0, -1));
            CheckGameState();
            if (IsCleared())
            {
                Debug.Log("clear");
                clearText.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayMoveSound();
            Vector2Int playerIndex = GetPlayerIndex();
            MoveObject(
                playerIndex,
                playerIndex + new Vector2Int(0, 1));
            CheckGameState();
            if (IsCleared())
            {
                Debug.Log("clear");
                clearText.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //PrintArray();
        //if (playerIndex < map.Length - 1)
        //{
        //    map[playerIndex + 1] = 1;
        //    map[playerIndex] = 0;
        //}
        //string debugText = "";
        //for (int i = 0; i < map.Length; i++)
        //{
        //    debugText += map[i].ToString() + ",";
        //}
        //Debug.Log(debugText);
    }
    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < objectsMap.GetLength(0); y++)
        {
            for (int x = 0; x < objectsMap.GetLength(1); x++)
            {

                if (objectsMap[y, x] == null) { continue; }

                if (objectsMap[y, x].CompareTag("Player"))
                {
                    return new Vector2Int(x, y);
                }
            }

        }
        return new Vector2Int(-1, -1);
    }
    bool MoveObject(Vector2Int moveFrom, Vector2Int moveTo)
    {
        if (moveTo.y < 0 || moveTo.y >= objectsMap.GetLength(0)) { return false; }
        if (moveTo.x < 0 || moveTo.x >= objectsMap.GetLength(1)) { return false; }

        if (map[moveTo.y, moveTo.x] == 16)
        {
            return false;
        }

        if (objectsMap[moveTo.y, moveTo.x] != null && objectsMap[moveTo.y, moveTo.x].CompareTag("Box"))
        {
            Vector2Int velocity = moveTo - moveFrom;
            bool success = MoveObject(moveTo, moveTo + velocity);
            if (!success)
            {
                return false;
            }
        }

        //if (objectMaps[moveTo] == 2)
        //{
        //    int velocity = moveTo - moveFrom;

        //    bool success = MoveNumber(2, moveTo, moveTo + velocity);

        //    if (!success) { return false; }
        //}
        //objectsMap[(int)moveFrom.y, (int)moveFrom.x].transform.position =
        //    new Vector3(moveTo.x, map.GetLength(0) - moveTo.y, 0);
        Vector3 moveToPosition = new Vector3(moveTo.x, map.GetLength(0) - moveTo.y, 0);
        objectsMap[moveFrom.y, moveFrom.x].GetComponent<Move>().MoveTo(moveToPosition);

        objectsMap[moveTo.y, moveTo.x] = objectsMap[(int)moveFrom.y, (int)moveFrom.x];
        objectsMap[(int)moveFrom.y, (int)moveFrom.x] = null;
        return true;
    }

    bool IsCleared()
    {
        for (int y = 0; y < map.GetLength(0); ++y)
        {
            for (int x = 0; x < map.GetLength(1); ++x)
            {
                GameObject obj = objectsMap[y, x];

                if (map[y, x] == 3) // goal1
                {
                    if (obj == null || !obj.name.Contains("Box1")) return false;
                    if (!matchedGoals["Goal1"])
                    {
                        audioSource.PlayOneShot(goalMatchSound);
                        matchedGoals["Goal1"] = true;
                    }
                }

                if (map[y, x] == 5) // goal2
                {
                    if (obj == null || !obj.name.Contains("Box2")) return false;
                    if (!matchedGoals["Goal2"])
                    {
                        audioSource.PlayOneShot(goalMatchSound);
                        matchedGoals["Goal2"] = true;
                    }
                }

                if (map[y, x] == 7) // goal3
                {
                    if (obj == null || !obj.name.Contains("Box3")) return false;
                    if (!matchedGoals["Goal3"])
                    {
                        audioSource.PlayOneShot(goalMatchSound);
                        matchedGoals["Goal3"] = true;
                    }
                }

                if (map[y, x] == 9) // goal4
                {
                    if (obj == null || !obj.name.Contains("Box4")) return false;
                    if (!matchedGoals["Goal4"])
                    {
                        audioSource.PlayOneShot(goalMatchSound);
                        matchedGoals["Goal4"] = true;
                    }
                }

                if (map[y, x] == 11) // goal5
                {
                    if (obj == null || !obj.name.Contains("Box5")) return false;
                    if (!matchedGoals["Goal5"])
                    {
                        audioSource.PlayOneShot(goalMatchSound);
                        matchedGoals["Goal5"] = true;
                    }
                }

                if (map[y, x] == 13) // goal6
                {
                    if (obj == null || !obj.name.Contains("Box6")) return false;
                    if (!matchedGoals["Goal6"])
                    {
                        audioSource.PlayOneShot(goalMatchSound);
                        matchedGoals["Goal6"] = true;
                    }
                }

                if (map[y, x] == 15) // goal7
                {
                    if (obj == null || !obj.name.Contains("Box7")) return false;
                    if (!matchedGoals["Goal7"])
                    {
                        audioSource.PlayOneShot(goalMatchSound);
                        matchedGoals["Goal7"] = true;
                    }
                }
            }
        }

        return true;
    }
    void CheckGameState()
    {
        if (IsFailed())
        {
            Debug.Log("fail");
            failText.SetActive(true);
        }
        else if (IsCleared())
        {
            Debug.Log("clear");
            clearText.SetActive(true);
        }
    }
    bool IsFailed()
    {
        for (int y = 0; y < map.GetLength(0); ++y)
        {
            for (int x = 0; x < map.GetLength(1); ++x)
            {
                GameObject obj = objectsMap[y, x]; 

                if (map[y, x] == 3) // goal1
                {
                    if (obj != null && !obj.name.Contains("Box1")) return true;
                }
                if (map[y, x] == 5) // goal2
                {
                    if (obj != null && !obj.name.Contains("Box2")) return true;
                }
                if (map[y, x] == 7) // goal3
                {
                    if (obj != null && !obj.name.Contains("Box3")) return true;
                }
                if (map[y, x] == 9) // goal4
                {
                    if (obj != null && !obj.name.Contains("Box4")) return true;
                }
                if (map[y, x] == 11) // goal5
                {
                    if (obj != null && !obj.name.Contains("Box5")) return true;
                }
                if (map[y, x] == 13) // goal6
                {
                    if (obj != null && !obj.name.Contains("Box6")) return true;
                }
                if (map[y, x] == 15) // goal7
                {
                    if (obj != null && !obj.name.Contains("Box7")) return true;
                }
            }
        }

        return false;
    }
    void PlayMoveSound()
    {
        if (moveSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(moveSound);
        }
    }
}