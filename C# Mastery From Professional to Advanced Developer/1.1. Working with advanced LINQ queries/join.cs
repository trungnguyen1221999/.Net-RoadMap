var students = new[]
{
    new
    {
        Id = 1,
        Name = "Alice",
        Age = 20,
    },
    new
    {
        Id = 2,
        Name = "Bob",
        Age = 22,
    },
    new
    {
        Id = 3,
        Name = "Charlie",
        Age = 21,
    },
    new
    {
        Id = 4,
        Name = "David",
        Age = 23,
    },
    new
    {
        Id = 5,
        Name = "Eve",
        Age = 20,
    },
};

var scores = new[]
{
    new { studentId = 1, score = 85 },
    new { studentId = 2, score = 90 },
    new { studentId = 3, score = 85 },
    new { studentId = 4, score = 85 },
};

// Inner Join

var innerJoinQuery =
    from student in students
    join score in scores on student.Id equals score.studentId
    select new
    {
        student.Id,
        student.Name,
        student.Age,
        score.score,
    };

//Printing the results of the inner join

foreach (var item in innerJoinQuery)
{
    Console.WriteLine(
        $"Inner Join: --- Id: {item.Id}, {item.Name}, Age: {item.Age}, Score: {item.score}"
    );
}
Console.WriteLine("--------------------------------------------------");

//Left Join

var leftJoinQuery =
    from student in students
    join score in scores on student.Id equals score.studentId into studentScores
    from Score in studentScores.DefaultIfEmpty()
    select new
    {
        student.Id,
        student.Name,
        student.Age,
        Score = Score?.score ?? 0,
    };
foreach (var item in leftJoinQuery)
{
    Console.WriteLine(
        $"LeftJoin: --- Id: {item.Id}, {item.Name}, Age: {item.Age}, Score: {item.Score}"
    );
}
