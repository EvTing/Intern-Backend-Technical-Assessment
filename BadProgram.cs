namespace TechnicalAssesmentBackendDeveloper;

class Booking
{
    public string GuestName { get; set; }
    public string RoomNumber { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int TotalDays { get; set; }
    public double RatePerDay { get; set; }
    public double Discount { get; set; }
    public double TotalAmount { get; set; }

    public async Task BookRoom(string name, string room, DateTime checkin, DateTime checkout, double rate, double discountRate)
    {
        GuestName = name;
        RoomNumber = room;
        CheckInDate = checkin;
        CheckOutDate = checkout;
        RatePerDay = rate;
        Discount = discountRate;

        TotalDays = (CheckOutDate - CheckInDate).Days;
        TotalAmount = TotalDays * RatePerDay;
        TotalAmount = TotalAmount - (TotalAmount * Discount / 100);

        await LogBookingDetailsAsync();

        Console.WriteLine($"Room Booked for {GuestName}");
        Console.WriteLine($"Room No: {RoomNumber}");
        Console.WriteLine($"Check-In: {CheckInDate:yyyy-MM-dd}");
        Console.WriteLine($"Check-Out: {CheckOutDate:yyyy-MM-dd}");
        Console.WriteLine($"Total Days: {TotalDays}");
        Console.WriteLine($"Amount: {TotalAmount:C}");
}

    public async Task LogBookingDetailsAsync()
    {
        // Simulate writing to a log file or remote system
        await Task.Delay(1000);
        Console.WriteLine("Booking log saved.");
    }

    public void Cancel()
    {
        GuestName = null;
        RoomNumber = null;
        CheckInDate = DateTime.MinValue;
        CheckOutDate = DateTime.MinValue;
        TotalDays = 0;
        RatePerDay = 0;
        Discount = 0;
        TotalAmount = 0;

        Console.WriteLine("Booking cancelled");
    }
}

public static class AppHost
{
    static async Task Main(string[] args)
    {
        Booking b = new Booking();
        await b.BookRoom("Alice", "101", DateTime.Now, DateTime.Now.AddDays(3), 150.5, 10);
        b.Cancel();
    }
}
