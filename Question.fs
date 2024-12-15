namespace QuizApp

type QuestionType =
    | MultipleChoice of string list
    | WrittenAnswer

type Question = {
    QuestionText: string
    QuestionType: QuestionType
    CorrectAnswer: string
}
