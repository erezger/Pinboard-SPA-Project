using Microsoft.AspNetCore.Mvc;

namespace PinboardSPA.Controllers;

[ApiController]
[Route("api/[controller]")] // הנתיב יהיה: /api/Ad
public class AdController : ControllerBase
{
    private readonly JsonDataService _dataService;

    // הזרקת JsonDataService
    public AdController(JsonDataService dataService)
    {
        _dataService = dataService;
    }

    // GET /api/ad
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ad>>> GetAds()
    {
        var ads = await _dataService.GetAllAsync();
        return Ok(ads); // מחזיר קוד 200 OK עם רשימת המודעות
    }
    // GET /api/ad/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Ad>> GetAd(Guid id)
    {
        var ads = await _dataService.GetAllAsync();
        var ad = ads.FirstOrDefault(a => a.Id == id);

        if (ad == null)
        {
            return NotFound(); // מחזיר קוד 404 אם המודעה לא נמצאה
        }

        return Ok(ad);
    }
    // POST /api/ad
    [HttpPost]
    public async Task<ActionResult<Ad>> PostAd(Ad ad)
    {
        // ודא שהאובייקט שהתקבל תקין
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // מחזיר קוד 400 Bad Request
        }

        // הגדרת מזהה חדש, ומוסיף AuthorId דמה לצרכי בדיקה (ביישום אמיתי זה יגיע מאימות)
        ad.AuthorId = "test-user-1";

        var createdAd = await _dataService.CreateAsync(ad);

        // מחזיר קוד 201 Created עם ה-URI שבו נוצר המשאב החדש
        return CreatedAtAction(nameof(GetAd), new { id = createdAd.Id }, createdAd);
    }
    // PUT /api/ad/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAd(Guid id, Ad ad)
    {
        if (id != ad.Id)
        {
            return BadRequest(); // המזהה ב-URL לא תואם למזהה בגוף הבקשה
        }

        // ביישום אמיתי, היינו בודקים כאן:
        // 1. האם המודעה קיימת.
        // 2. האם המשתמש המחובר (באמצעות ad.AuthorId) הוא היוצר של המודעה.

        var updatedAd = await _dataService.UpdateAsync(id, ad);

        if (updatedAd == null)
        {
            return NotFound(); // מחזיר 404
        }

        return NoContent(); // מחזיר קוד 204 No Content (עדכון מוצלח ללא גוף תגובה)
    }
    // DELETE /api/ad/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAd(Guid id)
    {
        // ביישום אמיתי, היינו בודקים כאן הרשאה למחיקה.

        var deleted = await _dataService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound(); // מחזיר 404
        }

        return NoContent(); // מחזיר קוד 204 No Content (מחיקה מוצלחת)
    }
}
