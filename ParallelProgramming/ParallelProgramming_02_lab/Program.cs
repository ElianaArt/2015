using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelProgramming_02_lab
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        List<int> CreateVector(int N)
        {
            List<int> vector = new List<int>();
            for (int i = 2; i < N; i++)
            {
                vector.Add(i);
            }
            return vector;
        }

        void SuccessivelyMultiplyVector(List<int> vector)
        {
            for (int i = 0; i < vector.Count; i++ )
            {
                if (vector[i] != null)
                {
                    Random rand = new Random();
                    vector[i] = rand.Next(2, 10) * vector[i];
                }
            }
        }

        List<List<int>> PartitionArray(List<int> vector, int CountMiniArrays)
        {
            if (vector.Count % CountMiniArrays == 0)
            {
 
            }
            return null;
        }

        void ParallelSuccessivelyMultiplyVector(List<int> vector, int M)
        {
            List<Task> myTask;
            for (int i = 0; i < M; i++)
            {
                myTask.Add(new Task());
            }
            for (int i = 0; i < vector.Count; i++)
            {
                if (vector[i] != null)
                {
                    Random rand = new Random();
                    vector[i] = rand.Next(2, 10) * vector[i];
                }
            }
        }

    }
}
