namespace Task.Server.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public bool QuickPickUp { get; set; }
        public int Days { get; set; }
        public decimal Price { get; set; }
    }
}
