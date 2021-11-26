namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("input.txt");
            char pattern = ' ';

            string[] size  = text[0].Split(pattern);
            int column = int.Parse(size[0]);
            int row = int.Parse(size[1]);
            int count_rect = int.Parse(text[1]);
            int [,] arr = new int [column, row];

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    arr[i,j] = 0;
                }
            }
            
            for (int i = 0; i < count_rect; i ++)
            {
                string[] str = text[i+2].Split(pattern);
                
                for (int j = 0; j < column; j++)
                {
                    for (int k = 0; k < row; k++)
                    {
                        if (j >= int.Parse(str[0]) &&
                            j < int.Parse(str[2]) &&
                            k >= int.Parse(str[1]) &&
                            k < int.Parse(str[3]))
                         {
                            arr[j,k] = 1;
                         }
                    }
                }
            }

            int s = 0;

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                      s = s + arr[i,j];
                }
            }
            Console.WriteLine("result: "+ (column*row - s));
        }
    }
}
