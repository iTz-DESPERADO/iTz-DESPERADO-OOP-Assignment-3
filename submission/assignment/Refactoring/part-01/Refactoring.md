<div dir="rtl" align="right">

# Part 01 — answers
---

## ShippingCostCalculator

- What was the problem?
- استخدام switch جعل اضافة شركة شحن جديدة تتطلب تعديل الكلاس مما يخالف مبدا OCP


- What did you change?
- استخدمت Strategy Pattern مع IShippingCost وDictionary وطبّقت Constructor Injection لفصل طرق الحساب

---

## OrderProcessor

- What was the problem?
- الاعتماد المباشر على SqlOrderRepository وSmtpEmailSender سبب ارتباطا قويا (Tight Coupling) وخالف مبدا DIP


- What did you change?
- انشات IOrderRepository وIEmailSender واستخدمت Constructor Injection لفصل الاعتماديات

---

## Notifications

- What was the problem?
- استخدام الوراثة ادى الى تضخم عدد الكلاسات وتكرار الكود لكل تركيب من نوع الاشعار وسلوكه
- What did you change?
- استخدمت Decorator Pattern لتطبيق Composition Over Inheritance وفصلت Urgent Scheduled عن قنوات الارسال

---

## Proof

- New carrier file(s): UpsShippingCostcs
- New notification channel file(s): PushNotificationcs
- Existing classes left unchanged? (yes/no): yes

</div>
