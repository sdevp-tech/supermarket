# نظام سوبرماركت — نقاط بيع سطح المكتب (Windows Forms)

نظام نقاط بيع (POS) باللغة العربية مبني بـ C# باستخدام Windows Forms ويستهدف محلات البيع بالتجزئة (سوبرماركت/متاجر) لإدارة المبيعات، المخزون، العملاء، الموردين، المصروفات والتقارير.

## لمحة سريعة
- الحالة: مشروع تطبيق سطح مكتب تقليدي (WinForms)
- لغة التطوير: C# (.NET Framework 4.5.2)
- مكان الكود الرئيسي: `LoginForm1/`
- نموذج التشغيل: نافذة تسجيل دخول → فتح شاشة POS أو واجهة إدارة حسب دور المستخدم

## الميزات الرئيسية
- تسجيل دخول مع تحقق من كلمة المرور (SHA-256)
- واجهة نقطة بيع (POS) لعمليات البيع السريعة
- إدارة المنتجات، الموردين، العملاء، الفئات
- تسجيل المصروفات والمدفوعات (موردين / عملاء)
- تقارير مبيعات وطباعة/تصدير (مراجع إلى PdfSharp وExcel Interop)
- نسخ احتياطي للقاعدة عند إغلاق التطبيق عبر الإجراء المخزن `BackupDatabaseNow`

## التقنيات والمكتبات
- **إطار العمل:** .NET Framework 4.5.2 (Windows Forms)
- **مكتبات بارزة:** PdfSharp, ZXing.Net, Microsoft.Office.Interop.Excel

## متطلبات قبل التشغيل
1. Windows + Visual Studio (يفضل Visual Studio 2015 أو أحدث).
2. SQL Server محلي أو شبكة لاستضافة قاعدة بيانات `mini_supermarket` (أو اسم تختاره).
3. تثبيت المراجع التالية (يفضّل عبر NuGet أو وضع ملفات DLL في مجلد `lib/`):
   - PdfSharp
   - ZXing.Net
   - Microsoft.Office.Interop.Excel (قد يتطلب تثبيت Office أو المراجع المناسبة)
4. تأكد من حذف أو استبدال المفتاح المضمّن `LoginForm1_TemporaryKey.pfx` قبل أي نشر.

## التجهيز (من نسخة نظيفة)
1. استنخِ المستودع:

```bash
git clone https://github.com/sdevp-tech/supermarket.git
cd supermarket
```

2. افتح الحل `سوبرماركت.sln` في Visual Studio.
3. استعادة المراجع:
   - افتح NuGet Package Manager وثبت المكتبات المفقودة أو ضع ملفات DLL المطلوبة في مجلد مرجعي داخل المشروع وعدّل المراجع في `سوبرماركت.csproj` إن لزم.
4. عدّل سلسلة الاتصال إلى قاعدة البيانات في الملف `LoginForm1/DatabaseHelper.cs` أو قم بإضافتها إلى `App.config`:

```csharp
// مثال: DatabaseHelper.cs
private const string _connectionString = "Data Source=YOUR_SERVER;Initial Catalog=mini_supermarket;Integrated Security=True";
```

أو (مستحسن) عبر `App.config` و `ConfigurationManager`.

## إعداد قاعدة البيانات (نموذج)
إن الشفرة تفترض وجود جداول وإجراءات مخزنة معينة. فيما يلي أمثلة مبدئية لإنشاء جدول المستخدمين وإجراء النسخ الاحتياطي:

```sql
-- جدول المستخدمين الأساسي
CREATE TABLE Users (
  UserID INT IDENTITY(1,1) PRIMARY KEY,
  Username NVARCHAR(100) NOT NULL UNIQUE,
  PasswordHash NVARCHAR(256) NOT NULL,
  UserType NVARCHAR(50) NOT NULL
);

-- إجراء نسخ احتياطي بسيط (عدل المسار والأذونات حسب بيئتك)
CREATE PROCEDURE BackupDatabaseNow
AS
BEGIN
  DECLARE @backupPath NVARCHAR(260) = N'C:\Backups\mini_supermarket.bak';
  BACKUP DATABASE [mini_supermarket] TO DISK = @backupPath WITH INIT;
END
```

ملاحظة: تأكد من أن خدمة SQL Server لديها صلاحيات الكتابة إلى المجلد المحدد.

## كيفية التشغيل
- في Visual Studio: افتح `سوبرماركت.sln` → اختر المشروع `LoginForm1` → Build → Start Debugging (F5).
- بعد البناء، يمكنك تشغيل الملف التنفيذي:

```bash
./LoginForm1/bin/Debug/LoginForm1.exe
```

## أمان وتحسينات مقترحة
- لا تترك مفاتيح خاصة (*.pfx) أو ملفات إعدادات حساسة داخل المستودع العام.
- لا تخزن سلسلة الاتصال مباشرة في الكود: استخدم `App.config` مع تشفير إن لزم.
- لا تستخدم تجزئة SHA-256 فقط بدون salt؛ من الأفضل استخدام KDF قوي (PBKDF2, BCrypt, Argon2) مع salt فريد لكل مستخدم.
- أضف تسجيل أخطاء (Logging) بدلًا من MessageBox عند التعامل مع الاستثناءات لتسهيل التصحيح.
- استبدل المسارات المطلقة في `.csproj` بمراجع NuGet أو بمجلد `lib/` داخل المشروع.

## تنظيف المستودع المقترح
- إضافة `.gitignore` يتجاهل `bin/`, `obj/`, `*.user`, `*.pfx`, وملفات النشر المؤقتة.
- إزالة `LoginForm1_TemporaryKey.pfx` من المستودع أو نقله لمكان أكثر أمانًا.
- تحديث مراجع DLL لتكون عبر NuGet أو مجلد `lib/` ومسارات نسبية.

## المساهمة
إذا أردت المساهمة أو تطوير المشروع:
1. أنشئ فرعًا جديدًا: `git checkout -b fix/your-change`
2. نفّذ التعديلات مع اختبارات إن أمكن.
3. أرسل Pull Request مع وصف للتغيير والسبب.

## أخطاء شائعة وحلول سريعة
- خطأ اتصال بقاعدة البيانات: تأكد من اسم السيرفر، اسم القاعدة، وأن حساب Windows/SQL لديه صلاحيات الوصول.
- مراجع DLL مفقودة: ثبت الحزم عبر NuGet أو ضع ملفات DLL في المسارات المشار إليها في `.csproj`.
- خطأ أثناء النسخ الاحتياطي: تأكد من وجود مجلد النسخ وأن SQL Server service account يملك صلاحية الكتابة.

## رخصة
لم يتم تضمين ملف LICENSE في المستودع. أضف ملف LICENSE مناسب (مثلاً MIT أو GPL) إذا رغبت بمشاركة الكود علنياً مع شروط واضحة.

---

.
