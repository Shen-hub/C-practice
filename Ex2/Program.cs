namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("input.txt");
            char pattern = ' ';

            int n  = int.Parse(text[0]);
            int [,] arr = new int [n*n, n*n];
            int [,] arr_check = new int [n*n, n*n];

            for (int i = 0; i < n*n; i++)
            {
                string[] str = text[i+1].Split(pattern);
                for (int j = 0; j < n*n; j++)
                {
                    arr[i,j] = int.Parse(str[j]);
                }
            }
            
            //Проверка по строке
            for (int i = 0; i < n*n; i++)
            {
                for (int k = 1; k <= n*n; k++)
                {
                    for (int j = 0; j < n*n; j++)
                    {
                        if(arr[i,j] == k)
                        {
                            arr_check[i,j]++;
                            break;
                        }
                    }
                }
            }

            //Проверка по столбцу
            for (int j = 0; j < n*n; j++)
            {
                for (int k = 1; k <= n*n; k++)
                {
                    for (int i = 0; i < n*n; i++)
                    {
                        if(arr[i,j] == k)
                        {
                            arr_check[i,j]++;
                            break;
                        }
                    }
                }
            }


            //Проверка квадратов
            bool flag = false;
            for (int k = 0; k < n; k++)
            {
                for (int l = 0; l < n; l++)
                {
                    for (int m = 1; m <= n * n; m++)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                if(arr[n*k+i, n*l+j] == m && flag == false)
                                {
                                    arr_check[n*k+i,n*l+j]++;
                                    flag = true;
                                }
                            }
                        }
                        flag = false;
                    }
                }
            }
            
            flag = true;
            //Проверка значений
            for (int i = 0; i < n*n; i++)
            {
                for (int j = 0; j < n*n; j++)
                {
                   if (arr_check[i, j] != 3)
                        flag = false;
                   //Console.Write(arr_check[i,j] + " ");
                }
                //Console.Write("\n");
                if (flag == false)
                    break;
            }
            if (flag == false)
                Console.WriteLine("Incorrect");
            else
                Console.WriteLine("Correct");
        }
    }
}
