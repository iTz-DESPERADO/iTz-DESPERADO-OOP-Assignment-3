## What is the same between the two stores, and what is different?

الـ Two Stores عندهم نفس الـ Methods وبياخدوا نفس الـ Parameters وكمان بيرجعوا نفس الـ Return Types

لكن الاختلاف بينهم في نوع البيانات اللي كل Store بيتعامل معاها لو كل واحد بيخزن Type مختلف


## Why the compiler rejects it? 
'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found (are you missing a using directive or an assembly reference?)  Error

لان الـ T هو Generic Type Parameter والـ Compiler مش عارف الـ Type الحقيقي اللي هيتبعت مكانه وكمان مفيش اي Constraint يضمن ان الـ T عنده Property اسمها Id

وكمان الCompiler  معندوش اي ضمان ان كل Type ممكن نستخدمه مكان T هيكون عنده Id

## Why does new Store<string>() not compile?

لان الـ Store<T> عنده Constraint اسمه where T : IHasId وده معناه ان اي Type هستخدمه مع الـ Store لازم يكون بيعمل Implement للـ IHasId

لكن الـ string مش بيعمل Implement للـ Interface ده وبالتالي الـ Compiler هيرفض الكود لانه مش قادر يضمن وجود الـ Id

## Why use yield return in Page?

استخدمت yield return علشان ارجع العناصر بشكل Lazy من غير ما احتاج انشئ Collection جديده واخزن فيها النتائج كلها

وكمان استخدمت yield break علشان اوقف الـ Iteration بمجرد ما اوصل لعدد العناصر المطلوب في الصفحة


## what is the common name for the kind of class you built in Steps 4 and 5?

**Generic Repository**