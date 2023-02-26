# В подключенном MySQL репозитории создать базу данных “Друзья человека”
sudo mysql
show databases;
CREATE DATABASE Друзья_человека;
use Друзья_человека;
# Создать таблицы с иерархией из диаграммы в БД
CREATE TABLE Животные ( id INT PRIMARY KEY AUTO_INCREMENT, type TEXT NOT NULL );
INSERT INTO Животные(type) VALUES('Домашнее животное'), ('Вьючное животное');
CREATE TABLE Домашние_животные ( id INT PRIMARY KEY AUTO_INCREMENT, typePet TEXT NOT NULL, typeId INT NOT NULL, FOREIGN KEY(typeId) REFERENCES Животные(id));
INSERT INTO Домашние_животные(typePet, typeId) VALUES('Собака', 1), ('Кошка', 1), ('Хомяк', 1);
CREATE TABLE Вьючные_животные ( id INT PRIMARY KEY AUTO_INCREMENT, typeBeastOfBurden TEXT NOT NULL, typeId INT NOT NULL, FOREIGN KEY(typeId) REFERENCES Животные(id));
INSERT INTO Вьючные_животные(typeBeastOfBurden, typeId) VALUES('Лошадь', 2), ('Верблюд', 2), ('Осёл', 2);
# Заполнить низкоуровневые таблицы именами(животных), командами которые они выполняют и датами рождения
CREATE TABLE Собаки (id INT PRIMARY KEY AUTO_INCREMENT, name TEXT NOT NULL, command TEXT NOT NULL, birthday DATETIME NOT NULL, typePetId INT NOT NULL, FOREIGN KEY(typePetId) REFERENCES Домашние_животные (id));
INSERT INTO Собаки(name, command, birthday, typePetId) VALUES ('Собака1', 'Лаять', '2010-01-20 00:00:00', 1), ('Собака2', 'Лаять', '2021-11-20 00:00:00', 1);
CREATE TABLE Кошки (id INT PRIMARY KEY AUTO_INCREMENT, name TEXT NOT NULL, command TEXT NOT NULL, birthday DATETIME NOT NULL, typePetId INT NOT NULL, FOREIGN KEY(typePetId) REFERENCES Домашние_животные (id));
INSERT INTO Кошки(name, command, birthday, typePetId) VALUES ('Кошка1', 'Мяукать', '2015-01-28 00:00:00', 2), ('Кошка2', 'Мяукать', '2020-12-20 00:00:00', 2);
CREATE TABLE Хомяки (id INT PRIMARY KEY AUTO_INCREMENT, name TEXT NOT NULL, command TEXT NOT NULL, birthday DATETIME NOT NULL, typePetId INT NOT NULL, FOREIGN KEY(typePetId) REFERENCES Домашние_животные (id));
INSERT INTO Хомяки(name, command, birthday, typePetId) VALUES ('Хомяк1', 'Бегать в колесе', '2022-11-28 00:00:00', 3);
CREATE TABLE Лошади (id INT PRIMARY KEY AUTO_INCREMENT, name TEXT NOT NULL, command TEXT NOT NULL, birthday DATETIME NOT NULL, typeBeastOfBurdenId INT NOT NULL, FOREIGN KEY(typeBeastOfBurdenId) REFERENCES Вьючные_животные (id));
INSERT INTO Лошади(name, command, birthday, typeBeastOfBurdenId) VALUES ('Лошадь1', 'Бить копытом', '2013-10-25 00:00:00', 1), ('Лошадь2', 'Бить копытом', '2015-10-20 00:00:00', 1);
CREATE TABLE Верблюды (id INT PRIMARY KEY AUTO_INCREMENT, name TEXT NOT NULL, command TEXT NOT NULL, birthday DATETIME NOT NULL, typeBeastOfBurdenId INT NOT NULL, FOREIGN KEY(typeBeastOfBurdenId) REFERENCES Вьючные_животные (id));
INSERT INTO Верблюды(name, command, birthday, typeBeastOfBurdenId) VALUES ('Верблюд1', 'Плюнуть', '2013-10-25 00:00:00', 2);
CREATE TABLE Ослы (id INT PRIMARY KEY AUTO_INCREMENT, name TEXT NOT NULL, command TEXT NOT NULL, birthday DATETIME NOT NULL, typeBeastOfBurdenId INT NOT NULL, FOREIGN KEY(typeBeastOfBurdenId) REFERENCES Вьючные_животные (id));
INSERT INTO Ослы(name, command, birthday, typeBeastOfBurdenId) VALUES ('Осёл1', 'Стоять', '2015-10-15 00:00:00', 3);
# Удалив из таблицы верблюдов, т.к. верблюдов решили перевезти в другой питомник на зимовку. Объединить таблицы лошади, и ослы в одну таблицу.
DROP TABLE Верблюды;
DELETE FROM Вьючные_животные WHERE id=2;
SELECT * FROM Лошади UNION ALL SELECT * FROM Ослы;
# Создать новую таблицу “молодые животные” в которую попадут все животные старше 1 года, но младше 3 лет и в отдельном столбце с точностью до месяца подсчитать возраст животных в новой таблице
CREATE TABLE Молодые_животные( SELECT *, DATEDIFF(CURDATE(), birthday) /30 as AgeMonths FROM Собаки WHERE birthday > DATE_SUB(CURDATE(), INTERVAL 3 YEAR) AND birthday < DATE_SUB(CURDATE(), INTERVAL 1 YEAR) UNION ALL SELECT *, DATEDIFF(CURDATE(), birthday) /30 as AgeMonths FROM Кошки WHERE birthday > DATE_SUB(CURDATE(), INTERVAL 3 YEAR) AND birthday < DATE_SUB(CURDATE(), INTERVAL 1 YEAR) UNION ALL SELECT *, DATEDIFF(CURDATE(), birthday) /30 as AgeMonths FROM Хомяки WHERE birthday > DATE_SUB(CURDATE(), INTERVAL 3 YEAR) AND birthday < DATE_SUB(CURDATE(), INTERVAL 1 YEAR) UNION ALL SELECT *, DATEDIFF(CURDATE(), birthday) /30 as AgeMonths FROM Лошади WHERE birthday > DATE_SUB(CURDATE(), INTERVAL 3 YEAR) AND birthday < DATE_SUB(CURDATE(), INTERVAL 1 YEAR) UNION ALL SELECT *, DATEDIFF(CURDATE(), birthday) /30 as AgeMonths FROM Ослы WHERE birthday > DATE_SUB(CURDATE(), INTERVAL 3 YEAR) AND birthday < DATE_SUB(CURDATE(), INTERVAL 1 YEAR));
# Объединить все таблицы в одну, при этом сохраняя поля, указывающие на прошлую принадлежность к старым таблицам.
SELECT *, 'Собака' AS type1,  'Домашнее животное' AS type2 FROM Собаки UNION ALL SELECT *, 'Кошка' AS type1,  'Домашнее животное' AS type2 FROM Кошки  UNION ALL SELECT *, 'Хомяк' AS type1,  'Домашнее животное' AS type2 FROM Хомяки UNION ALL SELECT *, 'Осёл' AS type1,  'Вьючное животное' AS type2 FROM Ослы UNION ALL SELECT *, 'Лошадь' AS type1,  'Вьючное животное' AS type2 FROM Лошади;
exit


