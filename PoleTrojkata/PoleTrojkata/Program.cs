namespace PoleTrojkata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hej, podaj wymiary trojkata to policze ci pole");
            var listOfSides = new List<int>();
        }

        private void InputSide(List<int> listOfSides)
        {
            try
            {
                for (int i = 1; i <= 3; i++)
                {
                    var input = int.Parse(Console.ReadLine());

                    if(input > 0)
                    {
                        listOfSides.Add(input);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception();
             }
        }
    }
}