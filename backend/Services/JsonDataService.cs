// JsonDataService.cs בתיקיית Services

using System.Text.Json;

public class JsonDataService
{
  // הנתיב לקובץ ה-JSON
  private readonly string _filePath = "ads.json";

  public JsonDataService()
  {
    // יצירת קובץ ה-JSON אם הוא לא קיים
    if (!File.Exists(_filePath))
    {
      File.WriteAllText(_filePath, "[]");
    }
  }

  // קריאת כל המודעות מקובץ ה-JSON
  public async Task<List<Ad>> GetAllAsync()
  {
    var json = await File.ReadAllTextAsync(_filePath);
    // Deserialization - המרה מטקסט JSON לאובייקטי C#
    return JsonSerializer.Deserialize<List<Ad>>(json) ?? new List<Ad>();
  }

  // שמירת כל המודעות לקובץ ה-JSON
  private async Task SaveAllAsync(List<Ad> ads)
  {
    // Serialization - המרה מאובייקטי C# לטקסט JSON
    var options = new JsonSerializerOptions { WriteIndented = true };
    var json = JsonSerializer.Serialize(ads, options);
    await File.WriteAllTextAsync(_filePath, json);
  }

  // יצירת מודעה חדשה
  public async Task<Ad> CreateAsync(Ad newAd)
  {
    var ads = await GetAllAsync();
    // ודא שה-Id הוא חדש (למרות שכבר הגדרנו Guid.NewGuid())
    newAd.Id = Guid.NewGuid();

    ads.Add(newAd);
    await SaveAllAsync(ads);

    return newAd;
  }
  // עדכון מודעה קיימת
  public async Task<Ad?> UpdateAsync(Guid id, Ad updatedAd)
  {
    var ads = await GetAllAsync();
    var existingAd = ads.FirstOrDefault(a => a.Id == id);

    if (existingAd == null)
    {
      return null; // המודעה לא נמצאה
    }

    // מעתיק את השדות המעודכנים
    existingAd.Title = updatedAd.Title;
    existingAd.Content = updatedAd.Content;
    existingAd.Category = updatedAd.Category;
    existingAd.Latitude = updatedAd.Latitude;
    existingAd.Longitude = updatedAd.Longitude;

    // *לא* מעדכן את AuthorId או DateCreated

    await SaveAllAsync(ads);
    return existingAd;
  }
  // מחיקת מודעה
  public async Task<bool> DeleteAsync(Guid id)
  {
    var ads = await GetAllAsync();
    var initialCount = ads.Count;

    // מסיר את המודעה עם ה-Id התואם
    var newAds = ads.Where(a => a.Id != id).ToList();

    if (newAds.Count == initialCount)
    {
      return false; // לא נמצאה מודעה למחיקה
    }

    await SaveAllAsync(newAds);
    return true;
  }
}