## What is the same between the two stores, and what is different?

الـ Two Stores عندهم نفس الـ Methods وبياخدوا نفس الـ Parameters وكمان بيرجعوا نفس الـ Return Types

لكن الاختلاف بينهم في نوع البيانات اللي كل Store بيتعامل معاها لو كل واحد بيخزن Type مختلف


## Why the compiler rejects it? 
'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found (are you missing a using directive or an assembly reference?)  Error

لان الـ T هو Generic Type Parameter والـ Compiler مش عارف الـ Type الحقيقي اللي هيتبعت مكانه وكمان مفيش اي Constraint يضمن ان الـ T عنده Property اسمها Id

وكمان الCompiler  معندوش اي ضمان ان كل Type ممكن نستخدمه مكان T هيكون عنده Id