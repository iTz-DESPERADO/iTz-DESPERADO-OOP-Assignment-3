# Collections Research Answers

## 1 What are IReadOnlyDictionary and SortedDictionary

### IReadOnlyDictionary<TKey, TValue>

الـ `IReadOnlyDictionary` هو `Interface` بيخليني اتعامل مع البيانات اللي عندي على شكل `Key` و `Value`

الفكرة هنا اني اقدر اقرا البيانات وابحث عنها لكن مش هقدر اعمل `Add` او `Remove` او اغير الـ `Value` من خلال الـ `Interface` نفسه

لكن في نقطة مهمة ان `IReadOnlyDictionary` مش معناها ان البيانات نفسها بقت `Immutable`

يعني لو عندي `Dictionary` اصلي وعملت عليه تعديل من مكان تاني فالتعديل ده هيظهر عندي في الـ `IReadOnlyDictionary` طالما الاتنين بيشاوروا على نفس الـ `Object`

يعني باختصار هو بيحدد العمليات اللي اقدر استخدمها لكن مش بيمنع تعديل الـ `Object` الاصلي

### SortedDictionary<TKey, TValue>

الـ `SortedDictionary` شبه الـ `Dictionary` العادي لانه برضو بيخزن البيانات على شكل `Key` و `Value`

واقدر اعمل عليه `Add` و `Remove` و `ContainsKey` واعدل البيانات اثناء الـ `Runtime`

لكن الفرق ان الـ `SortedDictionary` بيحافظ على ترتيب العناصر حسب الـ `Key`

يعني حتى لو اضفت البيانات بترتيب عشوائي لما اجي اعمل عليها `Iteration` هلاقيها مرتبة حسب الـ `Key`

والترتيب ده بيكون باستخدام الـ `Default Comparer` او ممكن انا احدد `Comparer` بنفسي

وكمان الفرق المهم ان `Dictionary` يستخدم Hash Table اما ال `SortedDictionary` بيستخدم Balanced Binary sreach tree

## 2 How is IReadOnlyDictionary different from Dictionary

الـ `Dictionary` بيديني الحرية اني اقرا البيانات واعدل عليها

يعني اقدر اضيف عناصر جديدة او امسح عناصر او اغير الـ `Values`

اما الـ `IReadOnlyDictionary` فهو `Interface` بيسمحلي اقرا البيانات فقط من خلاله

يعني اقدر استخدم `Count` و `ContainsKey` و `TryGetValue` واوصل للـ `Value` باستخدام الـ `Key`

لكن مش هقدر اعمل `Add` او `Remove` من خلال الـ `Interface`

وده مش معناه ان الـ `Dictionary` الاصلي مش هيتعدل

لان الـ `Object` الحقيقي ممكن يكون لسه `Dictionary` عادي وقابل للتعديل من مكان تاني

الفكرة مش اني منعت التعديل على البيانات نفسها

الفكرة اني حددت ايه العمليات اللي الكود يقدر يستخدمها من خلال الـ `Interface`

## 3 Why would a public method return IReadOnlyDictionary instead of Dictionary

انا هنا هرجع `IReadOnlyDictionary` بدل `Dictionary` لما اكون عايز المستخدم يقرا البيانات لكن مش عايزه يضيف او يمسح او يغير فيها من خلال الـ `Public Method` اللي انا موفره

وده بيساعدني في الـ `Encapsulation`

لاني مش محتاج اظهر للمستخدم كل العمليات الموجودة في الـ `Dictionary`

انا هظهرله بس الحاجات اللي هو محتاج يستخدمها

لكن حاجة مهمة الـ `IReadOnlyDictionary` مش بيعمل حماية كاملة للبيانات

يعني لو رجعت نفس الـ `Dictionary` الاصلي فممكن يتعدل من مكان تاني وكمان ممكن حد يعمل `Cast` للنوع الحقيقي ويعدل عليه

ولو انا محتاج حماية اقوى ممكن استخدم `ReadOnlyDictionary` كـ `Wrapper`

لكن حتى الـ `Wrapper` مش هيمنع التعديل من خلال الـ `Dictionary` الاصلي

ولو انا محتاج نسخة مستقلة مش تتاثر بالتعديلات اللي بتحصل على الاصل ساعتها ممكن اعمل `Copy` او استخدم `ImmutableDictionary` حسب احتياجي

## 4 How is SortedDictionary different from Dictionary in ordering and lookup speed

الـ `Dictionary` بيستخدم `Hash Table`

وعشان كده لما اعمل `Lookup` باستخدام الـ `Key` بيكون في المتوسط `O(1)`

يعني مش محتاج امشي على كل العناصر عشان اوصل للعنصر اللي بدور عليه

لكن في نفس الوقت الـ `Dictionary` مش بيضمن ترتيب معين للعناصر

اما الـ `SortedDictionary` فهو بيستخدم `Balanced Binary Search Tree`

وده بيخليه يحافظ على ترتيب العناصر حسب الـ `Key`

لكن هنا في مقابل للترتيب ده

لان الـ `Lookup` بيكون `O(log n)` بدل `O(1)` في المتوسط

وكمان عمليات الـ `Add` و `Remove` بتكون `O(log n)`

يعني لو انا مش محتاج ترتيب معين فغالبا الـ `Dictionary` هيكون افضل بالنسبة لي

لكن لو محتاج البيانات تكون مرتبة باستمرار فالـ `SortedDictionary` هيكون مناسب اكتر

### Time Complexity

`Dictionary<TKey, TValue>`

`Lookup` بيكون `O(1)` في المتوسط

`Add` بيكون `O(1)` في المتوسط

`Remove` بيكون `O(1)` في المتوسط

ومفيش ترتيب مضمون للـ `Keys`

`SortedDictionary<TKey, TValue>`

`Lookup` بيكون `O(log n)`

`Add` بيكون `O(log n)`

`Remove` بيكون `O(log n)`

وبيحافظ على ترتيب العناصر حسب الـ `Keys`

حتى لو الـ `Key` مش موجود البحث في الـ `SortedDictionary` برضو بيكون `O(log n)` في اسوا حالة لاننا بنمشي على مستويات الشجرة لحد ما نتاكد ان العنصر مش موجود

## 5 When would you choose SortedDictionary

انا هختار `SortedDictionary` لما اكون محتاج البيانات عندي تكون مرتبة حسب الـ `Key` بشكل مستمر

يعني مثلا لو عندي بيانات بتتضاف وتتمسح اثناء الـ `Runtime` وفي نفس الوقت محتاج اعرضها دايما بترتيب معين

هنا الـ `SortedDictionary` هيساعدني لان مش هحتاج اعمل `OrderBy` كل مرة عشان ارتب البيانات

لكن لو انا مش محتاج الترتيب وكل اللي يهمني اني اعمل `Lookup` بسرعة فهختار `Dictionary`

ولو محتاج ارتب البيانات مرة واحدة او على فترات قليلة ممكن استخدم `Dictionary` عادي واعمل `OrderBy` وقت ما احتاج

يعني الاختيار هنا بيعتمد على انا محتاج ترتيب مستمر ولا محتاج سرعة في البحث

# Task 2.2 Pick the Collection

## S1 Find a student by national ID

`Dictionary<string, Student>`

هستخدم `Dictionary` لان عندي الـ `National ID` مميز لكل طالب

فممكن استخدمه كـ `Key` واخزن الـ `Student` كـ `Value`

وفي نفس الوقت لما اعمل `Lookup` باستخدام الـ `National ID` هيكون في المتوسط `O(1)`

وده مناسب  لان ممكن احتاج ابحث عن الطلاب الاف المرات في اليوم

## S2 Keep unique course tags

`HashSet<string>`

هستخدم `HashSet` لان الـ `Tags` عندي المفروض تكون `Unique` ومش محتاج اي `Duplicates`

والـ `HashSet` بطبيعته مش بيسمح بتخزين نفس العنصر مرتين

وفي نفس الوقت لو محتاج اعمل `Lookup` باستخدام `Contains` هيكون في المتوسط `O(1)`

يعني مناسب  للحالة دي

## S3 Grades in entry order duplicates allowed

`List<Grade>`

هستخدم `List` لان انا  محتاج احافظ على ترتيب الدرجات بنفس الترتيب اللي اتضافت بيه

وفي نفس الوقت عادي يكون عندي اكتر من طالب جايب نفس الدرجة او حتى نفس الدرجة متكررة اكتر من مرة

فانا هنا مش محتاج `Unique Values`

ومش محتاج ارتب البيانات حسب قيمتها

عشان كده الـ `List` مناسبة اكتر

## S4 Public course price list read only access

`IReadOnlyDictionary<int, decimal>`

هستخدم `IReadOnlyDictionary` لان انا  عايز المستخدم يقدر يقرا سعر الكورس باستخدام الـ `Course ID`

لكن مش عايزه يقدر يضيف اسعار جديدة او يغير الاسعار الموجودة من خلال الـ `Interface`

وده بيساعدني في الـ `Encapsulation` لاني بحدد ايه العمليات اللي المستخدم يقدر يعملها

لكن زي ما وضحت قبل كده ده مش معناه ان البيانات الاصلية بقت `Immutable`

## S5 Timetable always ordered by start time

`SortedDictionary<DateTime, Session>`

هستخدم `SortedDictionary` لان انا  الـ `Sessions` تكون مرتبة حسب وقت البداية

يعني حتى لو ضفت `Session` جديدة اثناء الـ `Runtime` هيفضل الترتيب موجود

وده هيخليني اعرض الجدول بالترتيب من غير ما احتاج اعمل `OrderBy` كل مرة




## S6 Results consumed once may stop early

`IEnumerable<Result>`

هستخدم `IEnumerable` لان هنا انا مش محتاج اجهز كل النتائج من البداية

انا محتاج امر على النتائج وممكن اوقف بدري لو وصلت للحاجة اللي بدور عليها

وممكن استخدم `yield return` عشان ارجع النتائج واحدة واحدة وقت ما احتاجها

وده بيساعدني اقلل استهلاك الـ `Memory` لان مش لازم اعمل انشاء لكل النتائج مرة واحدة

لكن لازم ناخد بالنا ان `IEnumerable` مش معناه ان التنفيذ هيكون `Lazy` بشكل تلقائي

لان ده بيعتمد على طريقة الـ `Implementation`

يعني لو رجعت `List` جاهزة فهي اتعملها انشاء بالفعل

لكن لو استخدمت `yield return` فالنتائج ممكن تتولد وقت الـ `Iteration`



# Sources

**Microsoft Learn IReadOnlyDictionary**

https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2?view=net-10.0

**Microsoft Learn SortedDictionary**

https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-10.0

**Microsoft Learn Dictionary**

https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-10.0

**dotnet runtime IReadOnlyDictionary Source**

https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Collections/Generic/IReadOnlyDictionary.cs

**dotnet runtime SortedDictionary Source**

https://github.com/dotnet/runtime/blob/main/src/libraries/System.Collections/src/System/Collections/Generic/SortedDictionary.cs