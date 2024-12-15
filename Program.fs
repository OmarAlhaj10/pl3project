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

let updateQuestion () =
        match quiz.TryFind currentQuestion with
        | Some q -> 
            questionLabel.Text <- sprintf "Q%d: %s" currentQuestion q.QuestionText
            answerPanel.Controls.Clear()  // Clear previous answers

            match q.QuestionType with
            | MultipleChoice options -> 
                options |> List.iter (fun option ->
                    let radioButton = new RadioButton(Text = option, Width = 150, Top = answerPanel.Controls.Count * 25)
                    radioButton.CheckedChanged.Add(fun _ ->
                        if radioButton.Checked then
                            userAnswers <- userAnswers.Add(currentQuestion, option)
                    )
                    answerPanel.Controls.Add(radioButton)
                )
            | WrittenAnswer -> 
                let textBox = new TextBox(Width = 300, Top = 0)
                textBox.TextChanged.Add(fun _ ->
                    userAnswers <- userAnswers.Add(currentQuestion, textBox.Text)
                )
                answerPanel.Controls.Add(textBox)
        | None -> ()

        let calculateScore () =
        userAnswers
        |> Map.fold (fun score questionId answer ->
            match quiz.TryFind questionId with
            | Some q when q.CorrectAnswer = answer -> score + 1
            | _ -> score
        ) 0
