using System;

namespace TrainCoach
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int maxSeatInCoach = 64;
                int maxSeatInCompantment = 6;
                string isSide;
                int seatNum = 0;

                do
                {
                    Console.Write("Is side seats are present in compartment?(Y/N/y/n)");
                    isSide = Convert.ToString(Console.ReadLine());
                } while (!isSide.ToLower().Equals("y") && !isSide.ToLower().Equals("n"));

                Console.WriteLine("");

                if (!string.IsNullOrWhiteSpace(isSide) && isSide.ToLower().Equals("y"))
                {
                    maxSeatInCoach = 72;
                    maxSeatInCompantment = 8;
                }

                do
                {
                    Console.Write("Please enter your correct seat number: ");
                    int.TryParse(Console.ReadLine(), out seatNum);
                } while (maxSeatInCoach < 0 && seatNum > maxSeatInCoach);

                if (seatNum < maxSeatInCoach)
                {
                    //Console.WriteLine(string.Format("Remainder of seat is: {0}", reminder));
                    string seatCode = string.Empty;

                    string reminder = Convert.ToString(seatNum % maxSeatInCompantment);
                    if (maxSeatInCompantment == 8)
                    {
                        SeatCode8Compartment sc = new SeatCode8Compartment();
                        Enum.TryParse<SeatCode8Compartment>(reminder, out sc);

                        seatCode = Enum.GetName(typeof(SeatCode8Compartment), sc);
                    }
                    else
                    {
                        SeatCode6Compartment sc = new SeatCode6Compartment();
                        Enum.TryParse<SeatCode6Compartment>(reminder, out sc);

                        seatCode = Enum.GetName(typeof(SeatCode6Compartment), sc);
                    }
                    Console.WriteLine(string.Format("SeatCode based on inputed seat number: {0}", seatCode));
                }
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Some exception occured \n Message is: {0}", ex.Message));
            }
        }


    }

    enum SeatCode8Compartment
    {
        LWL = 1,
        LMM = 2,
        LAU = 3,
        RAU = 4,
        RMM = 5,
        RWL = 6,
        SL = 7,
        SU = 0
    }

    enum SeatCode6Compartment
    {
        LWL = 1,
        LMM = 2,
        LAU = 3,
        RAU = 4,
        RMM = 5,
        RWL = 0
    }
}
