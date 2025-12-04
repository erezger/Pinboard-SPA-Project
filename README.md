📌 Pinboard SPA — לוח מודעות קהילתי

Single Page Application (SPA) המממש לוח מודעות עם מערכת CRUD מלאה, מבוסס Backend ב־ASP.NET Core ו־Frontend ב־Angular.

🧩 מבנה הפרויקט

הפרויקט מחולק לשני חלקים עיקריים:

חלק	טכנולוגיה	מטרה עיקרית
Backend (Api/)	ASP.NET Core Web API (C#)	חשיפת REST API ושמירת נתונים בקובץ ads.json מקומי
Client (Client/)	Angular 12 (SPA)	UI מודרני מבוסס רכיבים, Routing ו־Reactive Forms
🚀 דרישות מוקדמות להפעלה

כדי להריץ את המערכת מקצה לקצה, ודא שהרכיבים הבאים מותקנים:

.NET SDK 6.0+

Node.js גרסה מומלצת: 14–16

npm

Angular CLI (מותקן גלובלית):

npm install -g @angular/cli

🛠️ הוראות התקנה והרצה — שלב אחר שלב

⚠️ שני הפרויקטים חייבים לרוץ במקביל — כל אחד בטרמינל נפרד.

🔹 שלב 1: הפעלת ה־Backend (API)

מעבר לתיקיית ה־API:

cd Api


בנייה והרצה:

dotnet run


ברירת מחדל לכתובות:

HTTPS: https://localhost:7005

HTTP: http://localhost:5052

השאר את הטרמינל פתוח — ה־API חייב לרוץ ברקע.

🔹 שלב 2: הפעלת ה־Client (Angular SPA)
א. התקנת תלויות ופתרון קונפליקטים

יש צורך בדגל מיוחד עקב אי־תאימות בין גרסאות Node.js ו־Angular:

cd ../Client
npm install --legacy-peer-deps

ב. הגדרת משתנה סביבה — תיקון שגיאות OpenSSL

PowerShell / Linux:

$env:NODE_OPTIONS="--openssl-legacy-provider"


CMD (Windows):

set NODE_OPTIONS=--openssl-legacy-provider

ג. הרצת האפליקציה
ng serve --open


ברירת המחדל ל־URL:
👉 http://localhost:4200/

✅ מימוש ותכונות
1. CRUD מלא (יצירה / קריאה / עדכון / מחיקה)
פעולה	רכיב Angular	שיטת API	נתיב
Read	AdListComponent	GET	/api/ad
Create	AdFormComponent	POST	/api/ad
Update	AdFormComponent	PUT	/api/ad/{id}
Delete	AdListComponent	DELETE	/api/ad/{id}
2. אילוצי מימוש חשובים

Author ID חובה ב־API
ה־Client מגדיר כברירת מחדל:

AuthorId = "test-user-1"


עיצוב מודרני
מבוסס SCSS + Card View אינטראקטיבי.

פונקציית בונוס Google Maps
הוסרה לשיפור יציבות הפרויקט.

📁 מבנה תיקיות (תמציתי)
/Api
   ├── Controllers/
   ├── ads.json
   └── Program.cs

/Client
   ├── src/app/components
   ├── src/app/services
   ├── src/styles.scss
   └── angular.json

🎯 מטרת הפרויקט

לספק לוח מודעות פשוט, מהיר ואינטואיטיבי, המבוסס על טכנולוגיות מודרניות Full Stack, תוך הדגמה של תקשורת בין Angular ל־.NET Web API.
