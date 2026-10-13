<div dir="rtl" align="right">

# Part 02 — Answers

---

## Reports

**What was the problem?**
- كررنا خطوات  `Load`, `Validate`, `Save` في الكلاسات التلاته  وده يخالف مبدا DRY

**What did you change?**
- استخدمت `Template Method Pattern` مع `abstract class` لتوحيد الخطوات  وتركت `Format()` لكل Exporter واضفت `FileExtension` لتحديد امتداد الملف

**Why did you choose that approach?**
- لان خطوات التصدير وترتيبها ثابته والاختلاف فقط في التنسيق اخترت `abstract class` بدل `interface` لمشاركة التنفيذ المشترك وتجنب تكرار الكود

---

## Enrollment

**What was the problem?**
- كان `Program.cs` مسؤولا عن انشاء اربع خدمات واستدعائها بالترتيب  سبب   (Tight Coupling) وكشف تفاصيل عملية التسجيل

**What did you change?**
- استخدمت `Facade Pattern` لانشاء `EnrollmentFacade` يجمع خطوات التسجيل في عملية واحدة `EnrollCourse()`

**Why did you choose that approach?**
- لتبسيط التعامل مع الخدمات واخفاء تفاصيل تنفيذها وترتيبها عن الـ Caller مما يجعل الكود اسهل في الاستخدام والصيانة


</div>