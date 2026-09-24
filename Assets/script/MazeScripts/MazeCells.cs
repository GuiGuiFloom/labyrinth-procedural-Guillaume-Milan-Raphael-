using UnityEngine;

public class MazeCells : MonoBehaviour
{

    //.initialiser les GO wall
    [SerializeField]
    private GameObject leftWall;
    [SerializeField]
    private GameObject rightWall;
    [SerializeField]
    private GameObject frontWall;
    [SerializeField]
    private GameObject backWall;
    [SerializeField]
    private GameObject unvisitedBlock;

    private MazeGenerator MazeInstance;

    public MazeGenerator MazePrefab;

    //. bool de visietd
    public bool IsVisited;


    //. bunch of methode qui sont appellée durant Maze Generator script


    //. si cette fontion est appellée son etat devient true (visité)
    public void Visit()
    {
        IsVisited = true;
        unvisitedBlock.SetActive(false);

    }

    //. methodes appellées durant le Maze Generator script qui desactive les murs
    public void ClearLeftWall()
    {
        leftWall.SetActive(false);
    }
    public void ClearRightWall()
    {
        rightWall.SetActive(false);
    }
    public void ClearFrontWall()
    {
        frontWall.SetActive(false);
    }
    public void ClearBackWall()
    {
        backWall.SetActive(false);
    }

}


