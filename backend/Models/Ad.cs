// Ad.cs בתיקיית Models

public class Ad
{
  // מזהה ייחודי למודעה.
  public Guid Id { get; set; } = Guid.NewGuid();

  // מזהה יוצר המודעה (לצורך אימות עריכה/מחיקה)
  public string AuthorId { get; set; }

  // פרטים בסיסיים של המודעה
  public string Title { get; set; }
  public string Content { get; set; }
  public string Category { get; set; } // לדוגמה: "BUY & SELL", "EVENTS", "RENT"

  // מיקום (לצורך הבונוס)
  public double Latitude { get; set; }
  public double Longitude { get; set; }

  // תאריך יצירה
  public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}