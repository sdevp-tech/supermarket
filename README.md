# نظام سوبرماركت — نقاط بيع سطح المكتب (Windows Forms)

نظام نقاط بيع (POS) باللغة العربية مبني بـ C# باستخدام Windows Forms ويستهدف متاجر التجزئة (سوبرماركت/متاجر) لإدارة المبيعات، المخزون، العملاء، الموردين، المصروفات والتقارير.

## لمحة سريعة
- الحالة: تطبيق سطح مكتب (WinForms)
- لغة التطوير: C# (.NET Framework 4.5.2)
- مكان الكود الرئيسي: `LoginForm1/`
- نموذج التشغيل: نافذة تسجيل دخول → فتح شاشة POS أو واجهة إدارة حسب دور المستخدم

## الميزات الرئيسية
- تسجيل دخول مع تحقق من كلمة المرور (SHA-256)
- واجهة نقطة بيع (POS) لعمليات البيع السريعة
- إدارة المنتجات، الموردين، العملاء، الفئات
- تسجيل المصروفات والمدفوعات (موردون/عملاء)
- تقارير مبيعات وطباعة/تصدير (مراجع إلى PdfSharp وExcel Interop)
- نسخ احتياطي للقاعدة عند إغلاق التطبيق عبر الإجراء المخزن `BackupDatabaseNow`

## التقنيات والمكتبات
- **إطار العمل:** .NET Framework 4.5.2 (Windows Forms)
- **مكتبات بارزة:** PdfSharp, ZXing.Net, Microsoft.Office.Interop.Excel

## متطلبات قبل التشغيل
1. نظام تشغيل Windows مع Visual Studio (يفضل Visual Studio 2015 أو أحدث).
2. SQL Server محلي أو شبكة لاستضافة قاعدة بيانات `mini_supermarket` (أو اسم تختاره).
3. تثبيت المراجع التالية (يفضّل عبر NuGet أو وضع ملفات DLL في مجلد `lib/`):
   - PdfSharp
   - ZXing.Net
   - Microsoft.Office.Interop.Excel (قد يتطلب تثبيت Office أو المراجع المناسبة)
4. إزالة المفتاح المؤقت `LoginForm1_TemporaryKey.pfx` من المستودع قبل أي نشر عام.

## التجهيز (من نسخة نظيفة)
1. استنخِ المستودع:

```bash
git clone https://github.com/sdevp-tech/supermarket.git
cd supermarket
```

2. افتح الحل `سوبرماركت.sln` في Visual Studio.
3. استعادة المراجع:
   - افتح NuGet Package Manager وثبت الحزم المطلوبة أو ضع ملفات DLL في مجلد `lib/` وعدّل المراجع في المشروع إن لزم.
4. عدّل سلسلة الاتصال إلى قاعدة البيانات في الملف `LoginForm1/DatabaseHelper.cs` أو أضفها إلى `App.config`:

```csharp
// مثال في DatabaseHelper.cs
private const string _connectionString = "Data Source=YOUR_SERVER;Initial Catalog=mini_supermarket;Integrated Security=True";
```

ويُفضّل استخدام `App.config` و`ConfigurationManager` لتسهيل التهيئة دون إعادة بناء المشروع.

## إعداد قاعدة البيانات (نموذج)
تتطلب الشفرة وجود جداول وإجراءات مخزنة. أمثلة مبدئية:

```sql
-- جدول المستخدمين
CREATE TABLE Users (
  UserID INT IDENTITY(1,1) PRIMARY KEY,
  Username NVARCHAR(100) NOT NULL UNIQUE,
  PasswordHash NVARCHAR(256) NOT NULL,
  UserType NVARCHAR(50) NOT NULL
);

-- إجراء نسخ احتياطي بسيط (عدّل المسار والأذونات حسب بيئتك)
CREATE PROCEDURE BackupDatabaseNow
AS
BEGIN
  DECLARE @backupPath NVARCHAR(260) = N'C:\Backups\mini_supermarket.bak';
  BACKUP DATABASE [mini_supermarket] TO DISK = @backupPath WITH INIT;
END
```

تأكد من أن حساب خدمة SQL Server لديه صلاحية الكتابة إلى المجلد المحدد.

## كيفية التشغيل
- في Visual Studio: فتح `سوبرماركت.sln` → اختر المشروع `LoginForm1` → Build → Start Debugging (F5).
- بعد البناء، يمكن تشغيل الملف التنفيذي مباشرة:

```bash
./LoginForm1/bin/Debug/LoginForm1.exe
```

## أمان وتحسينات مقترحة
- لا تضمّن مفاتيح خاصة (*.pfx) أو ملفات إعدادات حساسة داخل المستودع العام.
- لا تخزن سلسلة الاتصال مباشرة في الكود؛ استخدم `App.config` مع إمكانية تشفير القيم الحساسة إذا لزم.
- تجزئة كلمات المرور باستخدام SHA-256 وحدها غير كافية؛ يُنصح باستخدام salt فريد لكل مستخدم وKDF قوي مثل PBKDF2 أو BCrypt أو Argon2.
- إضافة تسجيل مركزي للأخطاء (logging) بدلاً من MessageBox لتمكين تتبع الأخطاء وتحليلها.
- استبدال المراجع المطلقة في `.csproj` بمراجع عبر NuGet أو بمجلد `lib/` داخل المشروع.

## تنظيف المستودع المقترح
- إضافة ملف `.gitignore` مناسب لمشاريع Visual Studio (يتجاهل `bin/`, `obj/`, `*.user`, `*.pfx`, إلخ).
- إزالة `LoginForm1_TemporaryKey.pfx` من المستودع أو نقله إلى مخزن أسرار خارجي.
- تحديث مراجع DLL لاستخدام NuGet أو مسارات نسبية داخل المشروع.

## المساهمة
خطوات المساهمة المقترحة:
1. إنشاء فرع فرعي للاختبار: `git checkout -b fix/اسم-التعديل`
2. تنفيذ التعديلات مع إضافة اختبارات إن أمكن.
3. إرسال Pull Request مع وصف واضح للتغيير وأسبابه.

## أخطاء شائعة وحلول سريعة
- خطأ اتصال بقاعدة البيانات: تحقق من سلسلة الاتصال، وجود قاعدة البيانات، وصلاحيات الحساب.
- مراجع DLL مفقودة: ثبت الحزم عبر NuGet أو ضع ملفات DLL في المسارات المشار إليها.
- فشل النسخ الاحتياطي: تحقق من صلاحيات المجلد والمسارات في إجراء النسخ الاحتياطي.

## رخصة
لم يتم تضمين ملف LICENSE في المستودع. يُنصح بإضافة رخصة مناسبة (مثلاً MIT أو Apache-2.0) لتحديد شروط الاستخدام والمساهمة.
