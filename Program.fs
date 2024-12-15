open System
open System.Windows.Forms
open QuizApp

let createQuizForm (quiz: Map<int, Question>) =
    let form = new Form(Text = "Quiz Application", Width = 600, Height = 400)
    
    let questionLabel = new Label(Text = "", Top = 50, Width = 500)
    let answerPanel = new Panel(Top = 100, Left = 100, Width = 400, Height = 100)
    let nextButton = new Button(Text = "Next", Top = 250, Left = 200, Width = 100)
    let finishButton = new Button(Text = "Finish", Top = 250, Left = 320, Width = 100)
    finishButton.Enabled <- false

    form.Controls.AddRange([| questionLabel; answerPanel; nextButton; finishButton |])

    let mutable currentQuestion = 1
    let mutable userAnswers = Map.empty<int, string>
