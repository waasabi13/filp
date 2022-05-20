open System
open System.Windows.Forms
open System.Drawing
open System.IO

let form = new Form(Width=400, Height = 300, Text = "F# main form", Menu = new MainMenu())

let TextBox1= new TextBox(Top= 50,Width =30,Height = 10)
let TextBox2= new TextBox(Top= 70,Width =30,Height = 10)
let TextBox3= new TextBox(Top= 90,Width =30,Height = 10)
TextBox1.Left<-20
TextBox2.Left<-20
TextBox3.Left<-20

let Label1 = new Label(Text="a=",Top=50)
let Label2 = new Label(Text="b=",Top=70)
let Label3 = new Label(Text="c=",Top=90)

form.Controls.Add(TextBox1)
form.Controls.Add(TextBox2)
form.Controls.Add(TextBox3)

form.Controls.Add(Label1)
form.Controls.Add(Label2)
form.Controls.Add(Label3)

let button1 = new Button(Text="вычислить",Top=120,Width=200,Height=30)

let label = new Label(Top = 150,Width=200,Height=30)
form.Controls.Add(label)

form.Controls.Add(button1)
let D a b c = b*b-4.0*a*c


let ClickButton _ = 
    let a = float(TextBox1.Text)
    let b = float(TextBox2.Text)
    let c = float(TextBox3.Text)
    let D a b c = b*b-4.0*a*c
    if (D a b c)>0.0 then 
        let x1 (a:float) (b:float) (c:float) = (-b + Math.Sqrt(D a b c))/(2.0*a)
        let x2 (a:float) (b:float) (c:float) = (-b - Math.Sqrt(D a b c))/(2.0*a)
        label.Text<-"x1="+string(x1 a b c)+"\n"+" x2="+string(x2 a b c)
    elif (D a b c)=0.0 then
        let x (a:float) (b:float) (c:float) = (-b + Math.Sqrt(D a b c))/(2.0*a)
        label.Text<-"x1,2="+string(x a b c)
    else 
        label.Text<-"Нет решений"
        
let _ = button1.Click.Add(ClickButton)

Application.Run(form)

