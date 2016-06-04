/*
If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.
The sum of these multiples is 23.

Find the sum of all the multiples of 3 or 5 below 1000.

*/

DECLARE @Max INT = 1000;

SET NOCOUNT ON;

WITH [Numbers]( N ) AS
(
	SELECT 1 AS [N]
	
	UNION ALL
	
	SELECT
		[N] + 1 AS [N]
	FROM
		[Numbers]
	WHERE
		( [N] + 1 ) < @Max
)
SELECT
	SUM( N ) AS [Answer]
FROM
	[Numbers]
WHERE
(
	[N] % 3 = 0
	OR
	[N] % 5 = 0
)
OPTION
(
	MAXRECURSION 0
);

GO