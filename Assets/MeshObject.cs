/////////////////////////////////////////////////
//                  CREATE                      
//Author:       Piotr Arent
//Date:         2017-11-11
//Description:  Ladowanie obiektu 3D
/////////////////////////////////////////////////
//                  CHANGE                      
//Author:       Dawid Sklorz
//Date:         2017-11-18
//Description:  Wczytanie obiektu po podaniu jego ścieżki
/////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeshObject : MonoBehaviour
{

    public Text objectPath;

    void Start() { }

    void Update()
    {
        //sprawdzenie czy podano ścieżkę do obiektu
        if (this.objectPath.text.Length > 0)
        {
            //objekt do importowanie plikow w formacie .obj
            var objImporter = new ObjImporter();

            //właściwe załadowanie pliku do pamięci
            Mesh loadedMesh = objImporter.ImportFile(this.objectPath.text);

            //pobranie referencji do objektu w unity
            MeshFilter unityMesh = GetComponent<MeshFilter>();
            Mesh myMesh = unityMesh.mesh;

            //przekopiowanie objektu pobranego z pliku do unity
            myMesh.Clear();
            myMesh.vertices = loadedMesh.vertices;
            myMesh.triangles = loadedMesh.triangles;
            myMesh.uv = loadedMesh.uv;
            myMesh.RecalculateNormals();
        }
    }
}