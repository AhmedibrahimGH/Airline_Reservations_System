using System;

public class AirlineReservationSystem
{
    private const int PlaneCapacity = 10;
    private bool[] seats = new bool[PlaneCapacity];
    private int reservedSeatsCount = 0;
    private int totalIncome = 0;

    public static void Main(string[] args)
    {
        AirlineReservationSystem reservationSystem = new AirlineReservationSystem();
        reservationSystem.Run();
    }

    public void Run()
    {
        int seatNumber;

        do
        {
            Console.Write("Enter seat number (1-10) to reserve (-1 to end): ");
            seatNumber = GetSeatNumber();

            if (seatNumber == -1)
            {
                DisplaySummary();
                break;
            }

            if (IsValidSeat(seatNumber))
            {
                ReserveSeat(seatNumber);
            }
        } while (true);
    }

    private int GetSeatNumber()
    {
        int seatNumber;
        while (!int.TryParse(Console.ReadLine(), out seatNumber))
        {
            Console.WriteLine("Invalid input. Please enter a valid seat number.");
            Console.Write("Enter seat number (1-10) to reserve (-1 to end): ");
        }
        return seatNumber;
    }

    private bool IsValidSeat(int seatNumber)
    {
        if (seatNumber < 1 || seatNumber > PlaneCapacity)
        {
            Console.WriteLine("Invalid seat number. Please enter a number between 1 and 10.");
            return false;
        }

        if (seats[seatNumber - 1])
        {
            Console.WriteLine("Reservation cancelled: Seat number already reserved.");
            return false;
        }

        return true;
    }

    private void ReserveSeat(int seatNumber)
    {
        Console.Write("Enter the weight of the bag (in kg): ");
        int bagWeight = GetBagWeight();

        if (bagWeight > 20)
        {
            Console.WriteLine("Reservation cancelled: Excess baggage weight is not allowed.");
            return;
        }

        int excessWeightFee = CalculateExcessWeightFee(bagWeight);
        int totalFee = 500 + excessWeightFee;

        seats[seatNumber - 1] = true;
        reservedSeatsCount++;
        totalIncome += totalFee;

        Console.WriteLine($"Reservation confirmed for seat number {seatNumber}.");
        Console.WriteLine($"Extra weight fee: {excessWeightFee} $");
        Console.WriteLine($"Total fees: {totalFee} $");
    }

    private int GetBagWeight()
    {
        int bagWeight;
        while (!int.TryParse(Console.ReadLine(), out bagWeight) || bagWeight < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid bag weight (non-negative).");
            Console.Write("Enter the weight of the bag (in kg): ");
        }
        return bagWeight;
    }

    private int CalculateExcessWeightFee(int bagWeight)
    {
        return (bagWeight > 10) ? (bagWeight - 10) * 5 : 0;
    }

    private void DisplaySummary()
    {
        Console.WriteLine($"The flight has {reservedSeatsCount} reserved seats with a total income of {totalIncome} $.");
    }
}
