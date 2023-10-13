namespace KółkoKrzyżyk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new TicTacToe();
            game.StartGame();
        }
    }

    public class TicTacToe
    {
        static string[] plansza = new string[9];
        public int nrRuchu { get; set; }
        public int Xwins { get; set; }
        public int Ywins { get; set; }
        public int Draws { get; set; }

        public void StartGame()
        {
            int wybórUżytkownika;
            var czyKoniec = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Wybierz jedną z opcji: \n(1) - Graj, \n(2) - O Autorze, \n(3) - Koniec");
                Console.WriteLine("======================");
                Console.WriteLine($"Tablica wyników:\nX: {Xwins} | Y: {Ywins} | R: {Draws}");
                Console.WriteLine("======================");

                while (!int.TryParse(Console.ReadLine(), out wybórUżytkownika) || wybórUżytkownika < 1 || wybórUżytkownika > 3)
                    Console.WriteLine("Błedny wybór, wybierz 1-3");

                switch (wybórUżytkownika)
                {
                    case 1:
                        NewGame();
                        break;

                    case 2:
                        OAutorze();
                        break;

                    case 3:
                        Console.WriteLine("Czy napewno chcesz napewno zakończyć działanie programu? Wpisz tak/nie");
                        czyKoniec = Console.ReadLine();
                        break;
                }
            }
            while (czyKoniec != "tak");

            Console.ReadKey();
        }

        private void NewGame()
        {
            nrRuchu = 1;

            Console.WriteLine("Uruchamiam grę... ");
            for (int i = 0; i < plansza.Length; i++)
            {
                plansza[i] = $"{i}";
            }
            ShowGameView();

            string[] gracze = { "X", "O" };

            Random losowanie = new Random();

            int ktoPierwszy = losowanie.Next(0, 2);//losowanie pomiedzy 0,1
            int ktoDrugi;

            if (ktoPierwszy == 1)
                ktoDrugi = 0;
            else
                ktoDrugi = 1;

            do
            {
                MakeMove(gracze[ktoPierwszy], nrRuchu);
                if (CheckWinner())
                {
                    Console.WriteLine("Brawo! Wygrywa X");
                    Xwins += 1;
                    break;
                }

                if (nrRuchu > 9)
                {
                    Console.WriteLine("Koniec gry, nikt nie wygrał");
                    Draws += 1;
                    break;
                }

                MakeMove(gracze[ktoDrugi], nrRuchu);
                if (CheckWinner())
                {
                    Console.WriteLine("Brawo! Wygrywa O");
                    Ywins += 1;
                    break;
                }

            } while (true);

            StopGame();
        }

        //W przypadku lepszego pomysłu na checker zmienic
        private bool CheckWinner()
        {
            if (plansza[0] == plansza[1] && plansza[1] == plansza[2])
                return true;

            if (plansza[3] == plansza[4] && plansza[4] == plansza[5])
                return true;

            if (plansza[6] == plansza[7] && plansza[7] == plansza[8])
                return true;

            if (plansza[0] == plansza[3] && plansza[3] == plansza[6])
                return true;

            if (plansza[1] == plansza[4] && plansza[4] == plansza[7])
                return true;

            if (plansza[2] == plansza[5] && plansza[5] == plansza[8])
                return true;

            if (plansza[0] == plansza[4] && plansza[4] == plansza[8])
                return true;

            if (plansza[2] == plansza[4] && plansza[4] == plansza[6])
                return true;

            return false;
        }

        private void MakeMove(string gracz, int nrRuchu)
        {
            Console.WriteLine($"nr ruchu {nrRuchu}");
            int pozycja;
            Console.WriteLine($"Gracz {gracz} - podaj wolną pozycje z planszy:");

            while (!int.TryParse(Console.ReadLine(), out pozycja) || pozycja < 0 || pozycja > 8 || plansza[pozycja] == "X" || plansza[pozycja] == "O")
                Console.WriteLine("Bład! Podaj wolnę pozycje z zakresu 0-8");

            plansza[pozycja] = gracz;

            ShowGameView();
            nrRuchu++;
        }

        private void ShowGameView()
        {
            for (int i = 0; i < plansza.Length; i += 3)
            {
                Console.WriteLine($" {plansza[i]} | {plansza[i + 1]} | {plansza[i + 2]}");

                if (i == 0 || i == 3)
                    Console.WriteLine("---+---+---");
            }
        }

        private void StopGame()
        {
            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować");
            Console.ReadKey();
        }

        private void OAutorze()
        {
            Console.WriteLine("Program wziety z semestru 1, delikatnie poprawiony");
            StopGame();
        }
    }
}