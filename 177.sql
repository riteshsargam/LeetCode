CREATE FUNCTION getNthHighestSalary(@N INT) 
RETURNS INT AS
BEGIN
    RETURN(
            SELECT 
               MAX(salary) 
            FROM
                (
                    SELECT
                        salary,
                        DENSE_RANK() OVER(ORDER BY salary DESC) RankID
                    FROM
                        Employee
                )tbl
            WHERE
                RankID = @N
    )
END
