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
            2, { QuestionText = "Which of these is a fruit?"; QuestionType = MultipleChoice ["Apple"; "Car"; "Rock"]; CorrectAnswer = "Apple" }
            3, { QuestionText = "What is the capital of France?"; QuestionType = WrittenAnswer; CorrectAnswer = "Paris" }
        ] |> Map.ofList
