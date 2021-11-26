namespace Ex3
{
    class Program
    {
        public static int Diahonal_LR (int[,] matrix, int determinant, int n) {
            int buf;
            //Диагональ с верхнего левого угла до правого нижнего
            for (int k = 0; k < n; k++)
            {
                buf = 1;
                for (int i = 0; i < n; i++)
                {
                    if (i + k < n)
                    {
                        buf = buf * matrix[i, i + k];
                        //Console.Write(matrix[i, i + k] + "|");
                    }
                        
                    else
                    {
                        buf = buf * matrix[i, (i + k)%n];
                        //Console.Write(matrix[i, (i + k)%n] + "|");
                    }
                }
                determinant = determinant + buf;
            }
            return determinant;
        }

        public static int Diahonal_RL (int[,] matrix, int determinant, int n)
        {
            int buf;
            //Диагональ с верхнего левого угла до правого нижнего
            for (int k = 0; k < n; k++)
            {
                buf = 1;
                for (int i = 0; i < n; i++)
                {
                    if (i + k < n)
                        buf = buf * matrix[i + k, n - 1 - i];
                        
                    else
                        buf = buf * matrix[(i + k)%n, n - 1 - i];
                }
                determinant = determinant - buf;
            }
            return determinant;
        }
        
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("input.txt");
            char pattern = ' ';

            int n = int.Parse(text[0]);
            int [,] matrix = new int [n, n+1];
            int determinant = 0;
            int [] x_matrix = new int [n];
            int [] buf_matrix = new int [n];
            

            for (int i = 0; i < n; i++)
            {
                string[] str = text[i+1].Split(pattern);
                for (int j = 0; j < n+1; j++)
                {
                    matrix[i,j] = int.Parse(str[j]);
                }
            }

            determinant = Diahonal_LR (matrix, determinant, n);
            determinant = Diahonal_RL (matrix, determinant, n);
            
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (k == j)
                        {
                            buf_matrix[i] = matrix[i,j];
                            matrix[i,j] = matrix[i,n];
                        }
                        Console.Write(" | " + matrix[i,j]);
                    }
                    
                }
                x_matrix[k] = Diahonal_LR (matrix, 0, n);
                x_matrix[k] = Diahonal_RL (matrix, x_matrix[k], n);
                Console.WriteLine("\nx1: " + x_matrix[k]);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (k == j)
                            matrix[i,j] = buf_matrix[i];
                    }
                    
                }

            }
            
            for (int i = 0; i < x_matrix.Length; i++)
            {
                Console.Write(x_matrix[i]/determinant + " ");
            }
            //Console.WriteLine("result: " + determinant);
        }
    }
}
