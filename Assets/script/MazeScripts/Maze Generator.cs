using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;




//. Globalement ce code permet de creer une grosse case de block, l'algo va detecter les blocks autour de lui et va decider de le desaciver ou non en fontion de si ils ont deja ete visité, il explore chaque possibilité dont ils disposent (dans ce cas un labyrinthe)
// ce code est insipiré de l'algorithme recursive backtracker 

public class MazeGenerator : MonoBehaviour
{

    //. creation des variables utilsée tout le long du script 

    [SerializeField]

    private MazeCells mazeCellsPrefab;

    [SerializeField]
    private int mazeWidth;

    [SerializeField]
    private int mazeDepth;

    private MazeCells[,] mazeGrid;

    GameObject lab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //.mettre le curseur invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //.Afficher un message au debut du jeu

        //. la methode build est appellée au start
        build();
    }


    //. la methode build permet de lancer l'instantiation du labyrinthe
    public void build()
    {
        //.initialise une variable qui est egale a la taille donnée dans mazeWidth(largeur) et mazeDepth(longeur), et donc la taille max du labyrinth
        mazeGrid = new MazeCells[mazeWidth, mazeDepth];


        //.lance un destroy si lab n'est pas nul
        if (lab != null){

            Destroy(lab);
        }


        //.permet de regrouper les GO creer dans un empty gameObject
        lab = new GameObject();


        //. genere des cellules en fontion de Maxdepth et MaxWidth
        for (int x = 0; x < mazeWidth; x++)
        {
            for (int z = 0; z < mazeDepth; z++)
            {

                mazeGrid[x, z] = Instantiate(mazeCellsPrefab, new Vector3(x, 0, z), Quaternion.identity);

                //.creer un parent pour chaques blocs instancier precedement
                mazeGrid[x, z].transform.parent = lab.transform;
            }
        }

        GenerateMaze(null, mazeGrid[0, 0]);
    }


    //. Couroutine permettant de clear les walls en asynchrone
    public void GenerateMaze(MazeCells previousCell, MazeCells currentCell)
    {
        //. appelle la methode Visit qui dit que la cellule actuelle est deja vistée
        currentCell.Visit();

        //. appelle la methode ClearWalls
        ClearWalls(previousCell, currentCell);

        //. creer une variable nextCell
        MazeCells nextCell;


        //. verifier les autres cellules si celle d'a cote sont visitées ou non et appelle la methode
        //.GetUnvisitedCell si vrai, si faux appelle GenerateMaze tant que la cellule precedente n'est pas nulle
        do
        {
            nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);
        
    }

    //. methode qui verifie les cellules non visitées
    private MazeCells GetNextUnvisitedCell(MazeCells currentCell)
    {
        //. creer une variable pour les cellules non visitées
        var unvisitedCells = GetUnvisitedCell(currentCell);
        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    //. permet de verifier si les cellules autor sont Unvisited ou non a chaque fois qu'on se trouve sur une cellule dite actuelle
    private IEnumerable<MazeCells> GetUnvisitedCell(MazeCells currentCell)
    {
        //. creer des variables qui donnent la position x et z de la cellule actuelle
        int x = (int)currentCell.transform.position.x;
        int z = (int)currentCell.transform.position.z;


        //. verifier la cellule de droite la reverifier si besoin
        if (x +1 < mazeWidth)
        {
            var cellToRight = mazeGrid [x + 1, z];


            //. permettre de continuer a droite si elle est verifier
            if (cellToRight.IsVisited == false)
            {
                yield return cellToRight;

            }

        }

        //. verifie la cellule de gauche
        if (x -1 >= 0)
        {
            var cellToLeft = mazeGrid [x - 1, z];


            //. permettre de continuer a gauche si elle est verifier
            if (cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;

            }

        }
        //. verifie la cellule d'en face
        if (z +1 < mazeDepth)
        {
            var cellToFront= mazeGrid [x, z + 1];


            //. permettre de continuer en face si elle est verifier
            if (cellToFront.IsVisited == false)
            {
                yield return cellToFront;

            }

        }
        //. verifie la meme chose mais derriere 
        if (z - 1 >= 0)
        {
            var cellToback = mazeGrid [x, z - 1];

            
            //. permettre de continuer derriere si elle est verifier
            if (cellToback.IsVisited == false)
            {
                yield return cellToback;

            }

        }

    }


    //. methode permetant de clear les walls en fonction de la cellule actuelle et de la precedente

    private void ClearWalls(MazeCells previousCell, MazeCells currentCell)
    {
        //. si la cellule d'avant est null  = recommencer
        if (previousCell == null)
        {
            return;
        }


        //. si la posi.x de la cellule precedente est < a celle de l'actuelle cellule
        //. desactive le mur de droite de la prochaine cellule et le gauche de l'actuelle cellule
        if (previousCell.transform.position.x <currentCell.transform.position.x)
        {

            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;

        }

        //. ici le If fait l'inverse du precedent
        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {

            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }



        //. les deux If suivants font la memme choses pour l'axe Z et -Z
        if (previousCell.transform.position.z < currentCell.transform.position.z)
            {

            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
            }

        if (previousCell.transform.position.z >currentCell.transform.position.z)
        {

            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
