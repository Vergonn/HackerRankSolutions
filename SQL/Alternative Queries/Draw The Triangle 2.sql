SET @number = 0;
SELECT IF(@number < 20, REPEAT('* ', @number := @number + 1), '') FROM information_schema.tables;