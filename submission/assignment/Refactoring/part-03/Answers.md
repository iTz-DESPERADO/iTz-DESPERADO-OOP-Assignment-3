<div dir="rtl" align="right">

# Part 03 — answers

---

## BlockedUsers

- **Time complexity before:** O(N × M)
- **Time (ms) before:** 14 ms
- **What did you change?**
- غيرت `List.Contains()` لان  مشكلتها اننا بنضطر نمشي على الـ List بالكامل يعني هيكون عندنا `Linear Search` وهذا مش افضل حاجة

غيرتها بـ `HashSet` وسبب اختياري ليها ان الـ IDs بطبيعتها `Unique` ومفيش اي `Duplicates` وفي نفس الوقت لما اعمل `Lookup` بيكون `O(1)` في المتوسط يعني تقريبًا `Instant` بدل ما امشي على الـ List بالكامل
- **Time complexity after:** O(N + M)
- **Time (ms) after:** 0 - 1 ms

## Students

**What was the problem?**
- المشكلة كانت  انشاء لمليون Student مع ان احنا محتاجين اول 3 بس وده بيستهلك Memory ووقت تنفيذ على الفاضي وده بسبب اننا بنستخدم Eager Evaluation

**What did you change?**
- استخدمت `yield return` مع `IEnumerable<Student>` لتطبيق Lazy Evaluation بحيث يتم انشاء الطلاب عند طلبهم فقط بدل ما كل مره نعمل الطلاب كلهم مره وحده  


</div>
