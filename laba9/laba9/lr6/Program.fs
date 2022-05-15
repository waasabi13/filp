open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
open System.Windows.Media.Imaging
//Главная форма
let mwXaml = " 
<Window 
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
 xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
 Title='F# WPF' Height='500' Width='500'>
 <Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width='156*' />
        <ColumnDefinition Width='163' />
    </Grid.ColumnDefinitions>
 <GroupBox Header='[Коэффициенты уравнения:]' Height='400' HorizontalAlignment='Left' Name='groupBox1' VerticalAlignment='Top' Width='400' 
 Grid.ColumnSpan='2'>
  <Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width='38*' />
        <ColumnDefinition Width='453*' />
    </Grid.ColumnDefinitions>
  <Label Content='a= ' Height = '92' HorizontalAlignment = 'Left' Margin = '6,-110,0,0' Name = 'label1' Width = '313' Grid.ColumnSpan='2' />
  <Label Content='b= ' Height = '92' HorizontalAlignment = 'Left' Margin = '6,-50,0,0' Name = 'label2' Width = '313' Grid.ColumnSpan='2' />
  <Label Content='c= ' Height = '92' HorizontalAlignment = 'Left' Margin = '6,10,0,0' Name = 'label3' Width = '313' Grid.ColumnSpan='2' />
  <TextBox Height = '20' HorizontalAlignment = 'Left' Margin = '30,-170,0,0' Name = 'textBox1' Width = '250' Grid.ColumnSpan='2' />
  <TextBox Height = '20' HorizontalAlignment = 'Left' Margin = '30,-110,0,0' Name = 'textBox2' Width = '250' Grid.ColumnSpan='2' />
  <TextBox Height = '20' HorizontalAlignment = 'Left' Margin = '30,-50,0,0' Name = 'textBox3' Width = '250' Grid.ColumnSpan='2' />
  <Label Content='Ответ = ' Height = '92' HorizontalAlignment = 'Left' Margin = '6,90,0,0' Name = 'label4' Width = '313' Grid.ColumnSpan='2' />
  <TextBox Height = '40' HorizontalAlignment = 'Left' Margin = '60,30,0,0' Name = 'textBox4' Width = '220' Grid.ColumnSpan='2' />
  </Grid>
  </GroupBox>
    <GroupBox Header='[Кнопки]' Height='92' HorizontalAlignment='Left' Margin='0,400,0,0' Name='groupBox2' VerticalAlignment='Top' 
Width='313' Grid.ColumnSpan='2'>
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width='74*' />
                <ColumnDefinition Width='227' />
            </Grid.ColumnDefinitions>
 <Button Content='Посчитать' Height='23' HorizontalAlignment='Left' 
Margin='6,6,0,0' Name='button5' VerticalAlignment='Top' Width='138' 
Grid.ColumnSpan='2' />
 </Grid>
 </GroupBox>
 
 
 </Grid>
</Window>
" 
let getWindow(mwXaml) =
    let xamlObj=XamlReader.Parse(mwXaml)
    xamlObj :?> Window

let win = getWindow(mwXaml)

let button5 = win.FindName("button5") :?> Button
let Label1 = win.FindName("label1") :?> Label
let Label2 = win.FindName("label2") :?> Label
let Label3 = win.FindName("label3") :?> Label
let TextBox1 = win.FindName("textBox1") :?> TextBox
let Label4 = win.FindName("label4") :?> Label
let TextBox4 = win.FindName("textBox4") :?> TextBox
let TextBox2 = win.FindName("textBox2") :?> TextBox
let TextBox3 = win.FindName("textBox3") :?> TextBox
let path1 = new BitmapImage()
let path2 = new BitmapImage()
let path3 = new BitmapImage()
let D a b c = b*b-4.0*a*c

let ClickButton _ = 
    let a = float(TextBox1.Text)
    let b = float(TextBox2.Text)
    let c = float(TextBox3.Text)
    let D a b c = b*b-4.0*a*c
    if (D a b c)>0.0 then 
        let x1 (a:float) (b:float) (c:float) = (-b + Math.Sqrt(D a b c))/(2.0*a)
        let x2 (a:float) (b:float) (c:float) = (-b - Math.Sqrt(D a b c))/(2.0*a)
        TextBox4.Text<-"x1="+string(x1 a b c)+"\n"+" x2="+string(x2 a b c)
    elif (D a b c)=0.0 then
        let x (a:float) (b:float) (c:float) = (-b + Math.Sqrt(D a b c))/(2.0*a)
        TextBox4.Text<-"x1,2="+string(x a b c)
    else 
        TextBox4.Text<-"Нет решений"
        
let _ = button5.Click.Add(ClickButton)

[<STAThread>] ignore <| (new Application()).Run win 
