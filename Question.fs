namespace QuizApp

type QuestionType =
    | MultipleChoice of string list
    | WrittenAnswer

type Question = {
    QuestionText: string
    QuestionType: QuestionType
    CorrectAnswer: string
}

module QuizData =
    let sampleQuiz = 
        [
            1, { QuestionText = "What is 2 + 2?"; QuestionType = WrittenAnswer; CorrectAnswer = "4" }
            2, { QuestionText = "Which of these is a fruit?"; QuestionType = MultipleChoice ["apple"; "Car"; "Rock"]; CorrectAnswer = "apple" }
            3, { QuestionText = "What is the capital of France?"; QuestionType = WrittenAnswer; CorrectAnswer = "paris" }
            4, { QuestionText = "Which of these is a car?"; QuestionType = MultipleChoice ["bmw"; "audi"; "ferarri";"all the above"]; CorrectAnswer = "all the above" }
            5, { QuestionText = "whats the name of this project?"; QuestionType = WrittenAnswer; CorrectAnswer = "pl3" }
        ] |> Map.ofList
