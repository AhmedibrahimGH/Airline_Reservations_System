using System;

public class My_program_AirLine
{
    public static void Main(string[] args)
    {
        int capabilityOfPlane = 10;
        bool[] seats = new bool[capabilityOfPlane];
        int Rs_Nm = 0, To_In = 0;
        int S_Nm, Bg_Wg, Ex_We, To_Fee;

        do
        {
            Console.Write("Enter seat Number (-1 to end): ");
            S_Nm = Convert.ToInt32(Console.ReadLine());

            switch (S_Nm)
            {
                case -1:
                    {
                        Console.WriteLine($"The flight has {Rs_Nm} reserved seats with total income {To_In} $");
                        break;
                    }
                case int x when x < 1 || x > 10:
                    {
                        Console.WriteLine("Invalid seat number");
                        break;
                    }
                case int x when (seats[x - 1]):
                    {
                        Console.WriteLine("Reservation cancelled due to unavailable seat number");
                        break;
                    }
                default:
                    {
                        Console.Write("Enter the weight of the bag: ");
                        Bg_Wg = Convert.ToInt32(Console.ReadLine());

                        if (Bg_Wg > 20)
                        {
                            Console.WriteLine("Reservation cancelled due to unallowed baggage weight");
                            break;
                        }

                        Ex_We = (Bg_Wg - 10) * 5;
                        To_Fee = 500 + Ex_We;

                        seats[S_Nm - 1] = true;
                        Rs_Nm = Rs_Nm + 1;
                        To_In = To_In + To_Fee;

                        Console.WriteLine($"Reservation is confirmed for seat no. {S_Nm}");
                        Console.WriteLine($"Fees of extra weight: {Ex_We} $");
                        Console.WriteLine($"Total fees: {To_Fee} $");

                        break;
                    }
            }
        } while (S_Nm != -1);
    }
}