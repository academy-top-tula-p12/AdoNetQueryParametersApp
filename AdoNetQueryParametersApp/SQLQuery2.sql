USE AcademyDB
GO

--ALTER PROCEDURE AddTeacher
--	@last_name NVARCHAR(50),
--	@first_name NVARCHAR(50) = NULL,
--	@birth_date DATE = NULL,
--	@phone VARCHAR(50) = NULL,
--	@department_id INT = NULL,
--	@salary DECIMAL(8, 2) = NULL
--AS
--BEGIN
--	IF @birth_date IS NOT NULL 
--		AND NOT ((YEAR(GETDATE()) - YEAR(@birth_date)) BETWEEN 16 AND 70)
--		SET @birth_date = NULL;

--	IF @salary < 0 OR @salary > 500000
--		SET @salary = NULL;
	
--	IF @department_id IS NOT NULL
--		AND NOT EXISTS (SELECT * FROM Department WHERE id = @department_id)
--		SET @department_id = NULL;

--	INSERT INTO Teacher
--		(last_name, first_name,
--		birth_date, phone,
--		department_id, salary)
--		VALUES
--		(@last_name,
--		@first_name,
--		@birth_date,
--		@phone,
--		@department_id,
--		@salary);

--	SELECT @@IDENTITY;

--END

ALTER PROCEDURE ViewTeachers
	@department_id INT = NULL
AS
BEGIN
	IF @department_id IS NULL
		BEGIN
			SELECT t.*, d.title 
				FROM Teacher AS t
				INNER JOIN Department AS d
					ON t.department_id = d.id;
		END
	ELSE
		BEGIN
			SELECT t.*, d.title 
				FROM Teacher AS t
				INNER JOIN Department AS d
					ON t.department_id = d.id
				WHERE t.department_id = @department_id;
		END		
END

--DECLARE @result INT
--EXEC @result = AddTeacher N'Авилов'
--SELECT @result

--ALTER PROCEDURE MaxSalary
--AS
--SELECT MAX(salary) FROM Teacher;
--GO

--EXEC MaxSalary
