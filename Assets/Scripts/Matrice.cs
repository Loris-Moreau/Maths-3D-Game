using System;
using UnityEngine;

public class Matrice : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void Update()
    {
        MultiplyMatrix();

        /*Vector3 MatrixVectorMultiply()
        {
            Vector3 vector1 = new Vector3(1, 2,3);
            int[,] matrice3 = new int[3, 3] { { 1, 2, 3 },
                                         { 3, 4, 5 },
                                         { 5, 6, 8 } }; 
            
            int[,] vectorResult = new int[3,3];

            //vectorResult = VectorMultiply(vector1, matrice3);
        }*/
    }
    static void MultiplyMatrix()
    {
        int[,] matrice1 = new int[3, 3] { { 1, 2, 3 },
                                         { 3, 4, 5 },
                                         { 5, 6, 8 } };

        int[,] matrice2 = new int[3, 3] { { 2, 5, 3 },
                                         { 4, 5, 1 },
                                         { 8, 7, 9 } };

        int[,] matriceMultplied = new int[3, 3];

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                for (int i = 0; i < 4; i++)
                {
                    matriceMultplied[row, col] = matriceMultplied[row, col] + matrice1[row, i] * matrice2[i, col];

                }
                Console.Write(matriceMultplied[row, col] + ", ");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}