Метою роботи є здобуття вмінь програмування прикладних додатків баз даних PostgreSQL.
Загальне завдання роботи полягає у наступному: 
1.	Реалізувати функції внесення, редагування та вилучення даних у таблицях бази даних, створених у лабораторній роботі №1, засобами консольного інтерфейсу. 
2.	Передбачити автоматичне пакетне генерування «рандомізованих» даних у базі. 
3.	Забезпечити реалізацію пошуку за декількома атрибутами з 2-х та більше сутностей одночасно: для числових атрибутів – у рамок діапазону, для рядкових – як шаблон функції LIKE оператора SELECT SQL, для логічного типу – значення True/False, для дат – у рамок діапазону дат.
4.	Програмний код виконати згідно шаблону MVC (модель-подання контролер). 

Деталізоване завдання: 
1.	Забезпечити можливість уведення/редагування/вилучення даних у таблицях бази даних з можливістю контролю відповідності типів даних атрибутів таблиць (рядків, чисел, дати/часу). Для контролю пропонується два варіанти:  
a.	контроль при введенні - валідація даних; 
b.	перехоплення помилок (try...except) від сервера PostgreSQL при виконанні відповідної команди SQL.  
Особливу увагу варто звернути на дані таблиць, що мають зв’язок 1:N.  З боку батьківської таблиці необхідно контролювати вилучення (ON DELETE) рядків за умови наявності даних у підлеглій таблиці. З боку підлеглої таблиці варто контролювати наявність відповідного рядка у батьківській таблиці при виконанні внесення до неї нових даних. Унеможливити виведення програмою на екрані системних помилок PostgreSQL шляхом їх перехоплення і адекватної обробки.  Внесення даних виконується користувачем у консольному вікні програми. 
2.	Забезпечити можливість автоматичної генерації великої кількості даних у таблицях за допомогою вбудованих у PostgreSQL функцій роботи з псевдовипадковими числами. Дані мають бути згенерованими не програмою, а відповідним SQL-запитом! Кількість даних для генерування має вводити користувач з клавіатури. 
3.	Для реалізації багатокритеріального пошуку необхідно підготувати 3 запити, що включають дані з декількох таблиць і фільтрують рядки за 3-4 атрибутами цих таблиць. Забезпечити можливість уведення конкретних значень констант для фільтрації з клавіатури користувачем. Після виведення даних вивести час виконання запиту у мілісекундах. Перевірити швидкодію роботи запитів на попередньо згенерованих даних. 
4.	Програмний код організувати згідно шаблону Model-ViewController (MVC). Приклад організації коду згідно шаблону доступний за даним посиланням. Модель, подання (представлення) та контролер мають бути реалізовані у окремих файлах. Для доступу до бази даних використовувати лише мову SQL (без ORM).
